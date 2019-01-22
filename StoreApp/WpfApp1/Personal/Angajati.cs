using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Personal
{
	public class Angajati
	{
		private int _Bucatar;

		public  int Bucatar
		{
			get { return _Bucatar; }
			set {

				if (value < 5)

					_Bucatar = value;
				else
					_Bucatar = 4;
			}
		}

		//private int _PersonalLivrare;

		//public int PersonalLivrare 
		//{
		//	get { return _PersonalLivrare; }
		//	set { _PersonalLivrare = value; }
		//}
		public Angajati()
		{
			Bucatar = 1;
			
		}
		





	}
}
