using ServerApp.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.AppConnection
{
    public static class MessageProcessor
    {
        #region Methods
        public static string ProcessMessage(string recMessage)
        {
            List<string> words = new List<string>();
            words = SplitMessage(recMessage);
            List<string> interpretedList = InterpretMessage(words);
            string message = ConstructMessage(interpretedList);
            return message;
        }

        public static List<string> SplitMessage(string message)
        {
            List<string> messageList = new List<string>();
            string [] words = message.Split(';');
            if (words.Count() == 1)
                messageList.Add("ERROR");
            for(int iter = 0; iter < words.Count() - 1 ; iter++)
            {
                messageList.Add(words[iter]);
            }
            return messageList;
        }

        public static string ConstructMessage(List<string> list)
        {
            string message = string.Empty;
            foreach(string item in list)
            {
                message += item ;
            }
            return message;
        }

        public static List<string> InterpretMessage(List<string> list)
        {
            switch(list[0])
            {
                case "LOGIN":
                    return DataManager.Login(list[1], list[2]);
                case "REGISTER":
                    return DataManager.Insert_User(list[1], list[2], list[3], list[4]); ;
                case "INSERT_CATEGORY":
                    return DataManager.Insert_Category(list[1]);
                case "INSERT_COURIER":
                    return DataManager.Insert_Courier(list[1], list[2]);
                case "CREATE_ORDER":
                    return DataManager.Insert_Order(list); 
                case "INSERT_PRODUCT":
                    return DataManager.Insert_Product(list[1], list[2], Convert.ToDouble(list[3]), Convert.ToInt32(list[4]), list[5]);
                case "CREATE_REVIEW":
                    return DataManager.Insert_Review(new Guid(list[1]), Convert.ToInt32(list[2]), list[3]); //
                case "REQUEST_CATEGORY":
                    return DataManager.GetCategories();
                case "REQUEST_CATEGORY_PRODUCTS":
                    return DataManager.CategoryProducts(list[1]);
                case "REQUEST_ORDERS": 
                    return DataManager.GetOrders();
                case "CHANGE_STATUS":
                    return DataManager.ChangeStatus(new Guid(list[1]), list[2], list);
                case "REQUEST_ORDER_DETAILS":
                    return DataManager.GetOrderDetails(new Guid(list[1]));
                case "REQUEST_COURIERS":
                    return DataManager.GetCouriers(); 
                default:
                    return new List<string>() { "UNRECOGNIZED MESSAGE"};

            }
        }

        #endregion
    }
}
