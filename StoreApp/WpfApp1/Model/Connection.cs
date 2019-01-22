using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
	public class Connection
	{
		public TcpClient client = null;
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
