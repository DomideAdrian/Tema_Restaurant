using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.AppConnection
{
    static class MessageProcessor
    {
        #region Methods
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

        public static void InterpretMessage(List<string> list)
        {
            switch(list[0])
            {
                case "LOGIN":
                    break;  
                case "REGISTER":
                    break;
                case "INSERT":
                    break;
                case "REQUEST_CATEGORY":
                    break;
                case "REQUEST_CATEGORY_NAME":
                    break;
                case "REQUEST_ORDERS":
                    break;
            }
        }

        #endregion
    }
}
