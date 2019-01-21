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
            List<string> result = InterpretMessage(words);
            return string.Empty;
        }

        public static List<string> SplitMessage(string message)
        {
            List<string> messageList = new List<string>();
            string [] words = message.Split(';');
            for(int iter = 0; iter < words.Count(); iter++)
            {
                messageList[iter] = words[iter];
            }
            return messageList;
        }

        public static string ConstructMessage(List<string> list)
        {
            string message = string.Empty;
            foreach(string item in list)
            {
                message += item + ";";
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
                    return DataManager.Register(list);
                case "INSERT_CATEGORY":
                    return DataManager.Insert_Category(list[1]);
                case "INSERT_COURIER":
                    return DataManager.Insert_Courier(list[1], list[2]);
                case "CREATE_ORDER":
                    return DataManager.Insert_Order(list);
                case "REQUEST_CATEGORY":
                    break;
                case "REQUEST_CATEGORY_NAME":
                    break;
                case "REQUEST_ORDERS":
                    break;
                case "CHANGE_STATUS":
                    break;
                case "GET_STATUS":
                    break;

            }
            return new List<string>();
        }

        #endregion
    }
}
