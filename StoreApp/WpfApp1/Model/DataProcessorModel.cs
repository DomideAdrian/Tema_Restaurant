﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
	public class DataProcessorModel
	{

		private string _NumeClient;

		public string NumeClient 
		{
			get { return _NumeClient; }
			set { _NumeClient = value; }
		}

		private string _Adresa	;

		public  string Adresa
		{
			get { return _Adresa; }
			set { _Adresa = value; }
		}
		private string _Comanda;

		public string Comanda 
		{
			get { return _Comanda; }
			set { _Comanda = value; }
		}
		private string _StagiuComanda;

		public string StagiuComanda 
		{
			get { return _StagiuComanda; }
			set { _StagiuComanda = value; }
		}
		private string _NrTelefon;

		public string NrTelefon 
		{
			get { return _NrTelefon; }
			set { _NrTelefon = value; }
		}

		



		//private ObservableCollection<string> _enterString;



		//public ObservableCollection<string> sir
		//{
		//	get { return _enterString; }
		//	set
		//	{
		//		_enterString = value;
		//	}
		//}



	}
}
