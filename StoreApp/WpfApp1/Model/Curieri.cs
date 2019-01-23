using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
	public class Curieri
	{
		private string _NumeCurier;

		public  string NumeCurier
		{
			get { return _NumeCurier; }
			set { _NumeCurier = value; }
		}
		private string _NumarTelefon;

		public  string NumarTelefon
		{
			get { return _NumarTelefon; }
			set { _NumarTelefon = value; }
		}

		private	string _StagiuComandaCurier;

		public	string StagiuComandaCurier
		{
			get { return _StagiuComandaCurier; }
			set { _StagiuComandaCurier = value; }
		}


	}
}
