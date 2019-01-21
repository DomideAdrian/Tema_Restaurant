using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServerApp.AppConnection;

namespace ServerApp.AppConnection
{
    class ConnectionManager
    {
        #region Methods
        public ConnectionManager()
        {
            InitializeServer();
        }

        public void ProcessClientRequests(object argument)
        {
            TcpClient client = (TcpClient)argument;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());

                string received = String.Empty;
                while (!(received = reader.ReadLine()).Equals("Exit") || (received == null))
                {
                    writer.WriteLine(MessageProcessor.ProcessMessage(received));
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

        public void InitializeServer()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
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
