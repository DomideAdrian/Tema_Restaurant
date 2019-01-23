using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace ClientApp
{
    public class Connection
    {
        public TcpClient    client = null; 
        public StreamReader reader = null;
        public StreamWriter writer = null;

        public Connection()
        {
            client = new TcpClient("127.0.0.1", 8080);
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
        }
        
        public string Send(string toSend)
        {
            writer.WriteLine(toSend);
            writer.Flush();
            string received = reader.ReadLine();
            return received;
        }
    }
}
