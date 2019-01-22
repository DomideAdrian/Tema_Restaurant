using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		public IstoricComenzi(ObservableCollection<DataProcessorModel> pvaluesDataGrid)
		{
			InitializeComponent();



			if (pvaluesDataGrid != null)
			{


				foreach (var value in pvaluesDataGrid)
				{
					if (value.StagiuComanda == "Delivered")
					{
						DataGridIstoricComenzi.Items.Add(value);
					}
				}
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
