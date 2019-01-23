using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1
{
	public static class MyUtils
	{
		public static string Insert_order { get; set; } //used

		public static string Insert_curier { get; set; } //

		public static string Insert_categorie { get; set; } //

		public static string schimba_status { get; set; } //

		public static List<Curieri> listaCurieri { get; set; } //used

		public static string Receive_message { get; set; }//used

		private static string _request_order;

		public static string Request_Order
		{
			get { return _request_order; }
			set { _request_order = "REQUEST_ORDERS"; }
				
		}
		private static string _request_curier;

		public static string Request_Couriers
		{
			get { return _request_curier; }
			set { _request_curier = "REQUEST_COURIERS"; }

		}


		//	public static string Insert_order { get; set; }





	}
}
