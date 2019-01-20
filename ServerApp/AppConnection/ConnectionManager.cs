using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp.AppConnection
{
    class ConnectionManager
    {
        static readonly TcpListener listener = null;

        #region Methods
        static ConnectionManager()
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
        }

        private static void ProcessClientRequests(object argument)
        {
            TcpClient client = (TcpClient)argument;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());

                string recived = String.Empty;
                while (!(recived = reader.ReadLine()).Equals("Exit") || (recived == null))
                {
                    Console.WriteLine("From client -> " + recived);
                    writer.WriteLine("From server -> " + recived);
                    writer.Flush();
                }
                reader.Close();
                writer.Close();
                client.Close();
                Console.WriteLine("Closing client connection");

            }
            catch (IOException)
            {
                Console.WriteLine("Problem with client communication.Exiting thread.");
            }
            finally
            {
                if (client != null)
                    client.Close();
            }
        }

        private static void InitializeServer()
        {
            try
            {
                listener.Start();
                Console.WriteLine("MultiThreadEchoServer started ...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections ...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accept new client connection ...");
                    Thread thread = new Thread(ProcessClientRequests);
                    thread.Start(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }

        #endregion
    }
}
