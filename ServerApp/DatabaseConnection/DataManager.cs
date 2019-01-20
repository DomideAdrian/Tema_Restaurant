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

        public static List<string> GetCategories()
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>();
                foreach (var item in context.Product_Category)
                {
                    words.Add(item.Category_Name.ToString());
                }
                return words;
            }
        }

        #region Methods Customer
        public static void Login(string username, string password)
        {
            using (var ctx = new RestaurantEntities())
            {
                //Check if a user exits
                ObjectParameter userId = new ObjectParameter("UserId", new Guid());
                ObjectParameter phone = new ObjectParameter("Phone",string.Empty);
                ObjectParameter voucher = new ObjectParameter("Voucher", 0 );
                ctx.User_Login("Domide Adrian", "12345", userId, phone,voucher);

                //If exist a have the user guid id 
                Console.WriteLine(userId.Value.ToString());
                Console.WriteLine(phone.Value.ToString());
                Console.WriteLine(voucher.Value.ToString());
            }
        }

        public static List<string> CategoryName(string categoryName)
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
                                r.Name,
                                r.Price,
                                r.Preparation_time,
                                r.Product_Description
                            };
                foreach (var item in results)
                {
                    words.Add(item.Name.ToString());
                    words.Add(item.Price.ToString());
                    words.Add(item.Preparation_time.ToString());
                    words.Add(item.Product_Description.ToString());
                }
                return words;
            }
        }

        #endregion

        #region Methods Store
        public static List<string> GetOrders(string status)
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>();
                var results = from o in context.Orders
                            join s in context.Order_Status
                            on o.Order_Id equals s.Order_Id
                            join p in context.Processings
                            on o.Order_Id equals p.Order_Id
                            join c in context.Products
                            on p.Product_Id equals c.Product_Id
                            where s.Order_Status1.Equals(status)
                            select new

                            {
                                o.Order_Id,
                                s.Order_Status1,
                                //////////////////////////////////////////
                            };
                foreach(var item in results)
                {
                    words.Add(item.Order_Id.ToString());
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

        public static void Insert_Category(string name)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Category(Guid.NewGuid(), name);
            }
        }

        public static void Insert_Courier(string name, string phone)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Courier(Guid.NewGuid(), name, phone);
            }
        }

        public static void Insert_Loyal_Customer(Guid userId, DateTime data, double total)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Loyal_Customer(Guid.NewGuid(), userId, data, total);
            }
        }

        public static void Insert_Order(Guid userID, Guid courierId)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Order(Guid.NewGuid(), userID, courierId);

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

        public static void Insert_Product(string name, Guid categoryId, double price, int time, string description)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Product(Guid.NewGuid(), name, categoryId, price, time, description);
            }
        }

        public static void Insert_Review(Guid orderId, int mark, string details)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_Review(Guid.NewGuid(), orderId, mark, details);
            }
        }

        public static void Insert_User(string name, string password, string phone, string address)
        {
            using (var context = new RestaurantEntities())
            {
                context.Insert_User(name, password, phone, address, Guid.NewGuid());
            }
        }

        public static void Set_Voucher(Guid userId, double value)
        {
            using (var context = new RestaurantEntities())
            {
                context.Set_Voucher(userId, value);
            }
        }

        #endregion

        #endregion
    }
}
