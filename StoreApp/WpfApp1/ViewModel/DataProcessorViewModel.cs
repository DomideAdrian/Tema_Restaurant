using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
	public class DataProcessorViewModel : ObservableCollection<DataProcessorModel>
	{
		
		public ObservableCollection<string> mSplit(string pEnterString)
		{
			var date2 = new List<string>();
			date2 = pEnterString.Split(';').ToList();

			ObservableCollection<string> date = new ObservableCollection<string>(date2);
			
			return date;
		}
		/// aici se face impartirea 
		



	}
}
