﻿using System;
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

        public static List<string> GetOrderDetails(Guid orderId)
        {
            using (var context = new RestaurantEntities())
            {
                List<string> words = new List<string>();
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
                    words.Add(item.Order_Status1.ToString());
                    words.Add(item.Last_Update.ToString());
                    words.Add(item.Name.ToString());
                    words.Add(item.Phone.ToString());
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
                List<string> words = new List<string>();
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

                foreach(var item in results)
                {
                    words.Add(item.Order_Id.ToString());
                    words.Add(item.Username.ToString());
                    words.Add(item.Phone.ToString());
                    words.Add(item.User_Address.ToString());
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
                    foreach (var prod in rezProducts)
                    {
                        words.Add(prod.Name.ToString());
                        words.Add(prod.Preparation_time.ToString());
                    }
                }
                return words;
            }
        }

        public static void ChangeStatus(Guid orderId, string status)
        {
            using (var context = new RestaurantEntities())
            {
                var result = (from c in context.Order_Status
                             where c.Order_Id.Equals(orderId)
                             select c).First();
                result.Order_Status1 = status;
                result.Last_Update = DateTime.Now;
                context.SaveChanges();

            }
        }

        public static void GenerateBill(Guid orderId)
        {
            using (var context = new RestaurantEntities())
            {
                var results = from c in context.Processings
                              join p in context.Products
                              on c.Product_Id equals p.Product_Id
                              where c.Order_Id.Equals(orderId)
                              select new
                              {
                                  p.Price
                              };
                double total = 0;
                foreach (var item in results)
                    total += Convert.ToDouble(item.Price);
                Insert_Bill(orderId, total, DateTime.Now);
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
