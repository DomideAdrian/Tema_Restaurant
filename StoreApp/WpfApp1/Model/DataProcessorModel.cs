using System;
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

		private string _id_client;

		public string Id_client 
		{
			get { return _id_client; }
			set { _id_client = value; }
		}
		private string _preparetionTime;

		public string PreparetionTime
		{
			get { return _preparetionTime; }
			set { _preparetionTime = value; }
		}


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

		private int _nrCrt;

		public int NrCrt 
		{
			get { return _nrCrt; }
			set { _nrCrt = value; }
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
