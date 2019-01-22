using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for IstoricComenzi.xaml
	/// </summary>
	public partial class IstoricComenzi : Page
	{
		public IstoricComenzi()
		{
			InitializeComponent();
			for (int i = 0; i < 100; i++)
			{
				DataGridIstoricComenzi.Items.Add(new ComandaDetails()
				{
					NrCrt = i,

					NumeClient = "Aditu Domidutu" + i.ToString(),
					Comanda = "pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste pizza si paste " + i.ToString(),
					Adresa = "bd george cosbuc, nr 1-" + i.ToString(),
					NrTelefon = "0769745164",
				}

					);
			}



		}

		private void DataGridCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void DataGridRow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataGridRow row = sender as DataGridRow;
			if (row != null)
			{
				row.DetailsVisibility = row.IsSelected ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
			}
		}
	}
}
