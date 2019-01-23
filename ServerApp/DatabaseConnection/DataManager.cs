using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServerApp.DatabaseConnection
{
    class DataManager
    {
        #region Methods 

        #region Methods Customer

        public static List<string> Login(string username, string password)
        {
            using (var context = new RestaurantEntities())
            {
                //Check if a user exist
                var result = from u in context.Users
                             where u.Username.Equals(username)
                             where u.User_Password.Equals(password)
                             select new
                             {
                                 u.Id_User,
                                 u.Phone
                             };
                //Generate message
                List<string> words = new List<string>();
                if (result.Count() != 0)
                {
                    //Succesfully connected
                    words.Add("LOGIN_OK;");
                    words.Add(result.First().Id_User.ToString() + ';');
                    words.Add(result.First().Phone.ToString() + ';');
                    var voucher = from r in result
                                  join v in context.Vouchers
                                  on r.Id_User equals v.Id_User
                                  select v;
                    if(voucher.Count() != 0)
                        words.Add(voucher.First().Value.ToString() + ';');
                    else
                        words.Add("0;");
                }
                else
                    //ERROR
                    words.Add("LOGIN_ERROR;");
                return words;
            }
        }

        public static List<string> GetCategories()
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>();
                words.Add("CATEGORY;");
                foreach (var item in context.Product_Category)
                {
                    words.Add(item.Category_Name.ToString() + ';');
                }
                return words;
            }
        }

        public static List<string> CategoryProducts(string categoryName)
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>();
                var results = from c in context.Product_Category
                            join r in context.Products
                            on c.Category_Id equals r.Product_Category
                            where c.Category_Name.Equals(categoryName)
                            select new
                            {
                                r.Product_Id,
                                r.Name,
                                r.Price,
                                r.Preparation_time,
                                r.Product_Description
                            };
                words.Add("CATEGORY_PRODUCTS;");
                foreach (var item in results)
                {
                    words.Add(item.Product_Id.ToString() + ';');
                    words.Add(item.Name.ToString() + ';');
                    words.Add(item.Price.ToString() + ';');
                    words.Add(item.Preparation_time.ToString() + ';');
                    words.Add(item.Product_Description.ToString() + ';');
                }
                return words;
            }
        }

        public static List<string> GetOrderDetails(Guid orderId)
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>() { "ORDER_DETAILS;"};
                var result = from s in context.Order_Status
                             join o in context.Orders
                             on s.Order_Id equals o.Order_Id
                             join c in context.Couriers
                             on o.Courier_Id equals c.Courier_Id
                             where s.Order_Id.Equals(orderId)
                             select new
                             {
                                 s.Order_Status1,
                                 s.Last_Update,
                                 c.Name,
                                 c.Phone
                             };
                foreach(var item in result)
                {
                    words.Add(item.Order_Status1.ToString() + ';');
                    words.Add(item.Last_Update.ToString() + ';');
                    words.Add(item.Name.ToString() + ';');
                    words.Add(item.Phone.ToString() + ';');
                }
                return words;
            }
        }
        #endregion

        #region Methods Store

        public static List<string> GetOrders()
        {
            using (var context = new RestaurantEntities())
            {
                //Select orders with Waiting status and get detail about user
                List<string> words = new List<string>() { "ORDERS;" };
                var results = from o in context.Orders
                            join s in context.Order_Status
                            on o.Order_Id equals s.Order_Id
                            join u in context.Users
                            on o.Id_User equals u.Id_User
                            where s.Order_Status1.Equals("Waiting")
                            select new
                            {
                                o.Order_Id,
                                u.Username,
                                u.Phone,
                                u.User_Address
                            };
                if(results.Count() == 0)
                {
                    words.Add("...;");
                    return words;
                }
                //For each comand get each product details and add to list
                foreach(var item in results)
                {
                    words.Add(item.Order_Id.ToString() + ';');
                    words.Add(item.Username.ToString() + ';');
                    words.Add(item.Phone.ToString() + ';');
                    words.Add(item.User_Address.ToString() + ';');
                    //Get product details foreach comand 
                    var rezProducts = from r in results
                                      join p in context.Processings
                                      on r.Order_Id equals p.Order_Id
                                      join prod in context.Products
                                      on p.Product_Id equals prod.Product_Id
                                      where r.Order_Id.Equals(item.Order_Id)
                                      select new
                                      {
                                         prod.Name,
                                         prod.Preparation_time
                                      };
                    int max = 0;
                    //Each product will be add to the list
                    foreach (var prod in rezProducts)
                    {
                        max = Math.Max(max,Convert.ToInt32(prod.Preparation_time));
                    }
                    words.Add(Convert.ToString(max) + ';');
                    foreach (var prod in rezProducts)
                    {
                        words.Add(prod.Name.ToString() + ';');
                    }
                    words.Add("...;");
                }
                return words;
            }
        }

        public static List<string> ChangeStatus(Guid orderId, string status, List<string> list)
        {
            using (var context = new RestaurantEntities())
            {
                //Generate status

                var result = (from c in context.Order_Status
                              where c.Order_Id.Equals(orderId)
                              select c).First();

                //If status change to In delivery will automaticaly generate bill
                if (status.Equals("In delivery"))
                {
                    GenerateBill(orderId);
                    var courier = (from c in context.Couriers
                                     where c.Name.Equals(list[3])
                                     select c).First();
                    var order = (from o in context.Orders
                                 where o.Order_Id.Equals(orderId)
                                 select o).First();
                    order.Courier_Id = courier.Courier_Id;
                }
                result.Order_Status1 = status;
                result.Last_Update = DateTime.Now;
                context.SaveChanges();
                return new List<string>() { "CHANGE_STATUS_OK;" };
            }
        }

        public static void GenerateBill(Guid orderId)
        {
            using (var context = new RestaurantEntities())
            {
                //Get orders products 
                var results = from c in context.Processings
                              join p in context.Products
                              on c.Product_Id equals p.Product_Id
                              where c.Order_Id.Equals(orderId)
                              select new
                              {
                                  p.Price
                              };
                double total = 0;
                //Calculate total
                foreach (var item in results)
                    total += Convert.ToDouble(item.Price);

                var userVoucher = from o in context.Orders
                           join u in context.Users
                           on o.Id_User equals u.Id_User
                           join v in context.Vouchers
                           on u.Id_User equals v.Id_User
                           where o.Order_Id.Equals(orderId)
                           select v;
                //Verify if user has vouchers
                if (userVoucher.Count() != 0)
                {
                    var voucher = userVoucher.First();

                    if (total >= Convert.ToDouble(voucher))
                    {
                        total -= Convert.ToDouble(voucher);
                        voucher.Value = 0;
                        context.SaveChanges();
                    }
                    else
                    {
                        total = 0;
                        voucher.Value = Convert.ToDouble(voucher) - total;
                        context.SaveChanges();
                    }
                }
                Insert_Bill(orderId, total, DateTime.Now);
            }
        }

        public static List<string>GetCouriers()
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>() { "COURIERS;" };
                var result =  from c in context.Couriers
                              select c;
                foreach(var item in result)
                {
                    words.Add(item.Name + ';');
                    words.Add(item.Phone + ';');
                }
                return words;
            }
        }
        #endregion

        #region Insert
        public static void Insert_Bill(Guid orderId, double total, DateTime data)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Bill(Guid.NewGuid(), orderId, total, data);
            }
        }
        
        public static void Insert_Loyal_Customer(Guid userId, DateTime data, double total)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Loyal_Customer(Guid.NewGuid(), userId, data, total);
            }
        }

        public static void Insert_Order_Status(Guid orderId, string status, DateTime date)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Order_Status(Guid.NewGuid(), orderId, status, date);
            }
        }

        public static void Insert_Processing(Guid productId, Guid orderId)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Processing(Guid.NewGuid(), productId, orderId);
            }
        }

        public static void Set_Voucher(Guid userId, double value)
        {
            using (var context = new RestaurantEntities())
            {
                context.Set_Voucher(userId, value);
            }
        }

        public static List<string> Insert_Category(string name)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Category(Guid.NewGuid(), name);
                return new List<string>() { "INSERT_CATEGORY_OK;" }; ;
            }
        }

        public static List<string> Insert_Courier(string name, string phone)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Courier(Guid.NewGuid(), name, phone);
                return new List<string> { "INSERT_COURIER_OK;" };
            }
        }

        public static List<string> Insert_Product(string name, string catName, double price, int time, string description)
        {
            using (var context = new RestaurantEntities())
            {
                var result = (from c in context.Product_Category
                                           where c.Category_Name.Equals(catName)
                                           select new { c.Category_Id }).First();
                context.Insert_Product(Guid.NewGuid(), name, new Guid(Convert.ToString(result.Category_Id)), price, time, description);
                return new List<string>() { "INSERT_PRODUCT_OK;" };
            }
        }

        public static List<string> Insert_Review(Guid orderId, int mark, string details)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Review(Guid.NewGuid(), orderId, mark, details);
                List<string> words = new List<string>()
                { "CREATE_REVIEW_OK;" };
                return words;
            }
        }

        public static List<string> Insert_User(string name, string password, string phone, string address)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_User(name, password, phone, address, Guid.NewGuid());
                List<string> words = new List<string>()
                { "REGISTER_OK;" };
                return words;
            }
        }

        public static List<string> Insert_Order(List<string> list)
        {
            using (var context = new RestaurantEntities())
            {
                //Create order id
                Guid orderId = Guid.NewGuid();
                //Insert order , new orderID, param userId, new guid
                context.Insert_Order(orderId, new Guid(list[1]), new Guid("B38EC0EA-4C70-4735-B258-AE566ABE0299"));
                //Insert status for order
                Insert_Order_Status(orderId, "Waiting", DateTime.Now);
                //for each product add row in processing table
                for (int iter = 2; iter < list.Count(); iter++)
                    Insert_Processing(new Guid(list[iter]), orderId);

                //Calculate total price
                var resTotal = from p in context.Processings
                               join prod in context.Products
                               on p.Product_Id equals prod.Product_Id
                               where p.Order_Id.Equals(orderId)
                               select prod;
                double total = 0;
                foreach (var item in resTotal)
                    total += item.Price;

                //Voucher
                if (total > 100)
                    Set_Voucher(new Guid(list[1]), 20);

                //verify if client exist in loyal custommers table
                Guid userId = new Guid(list[1]);
                var result = from l in context.Loyal_Customers
                             where l.Id_User == userId
                             select l;

                if (result.Count() == 0)
                    Insert_Loyal_Customer(new Guid(list[1]), DateTime.Now, total);
                else
                {
                    //Set Voucher if total comands > 1000 in last 30 days
                    result.First().Total += total;
                    DateTime initial = result.First().Period.Value;
                    if (result.First().Total >= 1000 && (DateTime.Now.Date - initial.Date).Days < 30)
                    {
                        Set_Voucher(orderId, 100);
                        result.First().Period = DateTime.Now;
                        result.First().Total = 0;
                        context.SaveChanges();
                    }
                    else
                    {
                        if (result.First().Total >= 1000)
                        {
                            Set_Voucher(orderId, 50);
                            result.First().Period = DateTime.Now;
                            result.First().Total = 0;
                            context.SaveChanges();
                        }
                    }

                }

                List<string> words = new List<string>
                {   "CREATE_COMMAND_OK;"  };
                return words;
            }
        }

        #endregion

        #endregion
    }
}
