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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			
			try
			{







			}
			catch(Exception e)
			{
				Console.WriteLine("Conexiunea cu serverula  esuat!");
			}
					   			 		  		  		 
        }
		public int j = 0;
		private ObservableCollection<DataProcessorModel> obsData = new ObservableCollection<DataProcessorModel>();


		private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
	

			
		}

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;

			
		}

		private void ListViewItem_MouseDoubleClick_OpenAsteptareConformareComanda(object sender, MouseButtonEventArgs e)
		{
			string pep = "ana" + j.ToString();
			j++;

			FrameMain.Content = new AsteptareConfirmare(pep);
			
		}

		private void ListViewItem_MouseDoubleClick_OpenPreparareComanda(object sender, MouseButtonEventArgs e)
		{
			FrameMain.Content = new PreparareComanda();
		}

		private void ListViewItem_MouseDoubleClick_OpenLivrareComanda(object sender, MouseButtonEventArgs e)
		{
			FrameMain.Content = new InCursDeLivrareComanda();
		}

		private void ListViewItem_MouseDoubleClick_OpenIstoric(object sender, MouseButtonEventArgs e)
		{
			FrameMain.Content = new IstoricComenzi();
		}
	}
}
