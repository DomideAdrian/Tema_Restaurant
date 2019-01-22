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
using WpfApp1.Personal;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		ObservableCollection<DataProcessorModel> obsDataWainting= new ObservableCollection<DataProcessorModel>();
		//ObservableCollection<DataProcessorModel> obsDataPreparing=null;
		//ObservableCollection<DataProcessorModel> obsDataDelivering=null;
		//ObservableCollection<DataProcessorModel> obsDataDelivered=null;

		DataProcessorViewModel pProcessData = new DataProcessorViewModel();
		string received_string = "Orders;1555;mitica;076;bd Viilor;10;uiteceva;alteceva;...;144;ion;075;bd georgescu;4;piftele;ciorba;...";
		 Angajati bucatari = new Angajati();

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
			if (received_string != null)
			{
				List<string> received_flag = pProcessData.mDetectFlag(received_string);
				switch (received_flag[0])
				{
					case "Orders":
						received_flag.RemoveAt(0);
						
						obsDataWainting = pProcessData.mSplit(received_flag, obsDataWainting);
						received_string = null;
						break;

				}
			}

			foreach (var value2 in obsDataWainting)
			{
				if (bucatari.Bucatar == 0)
				{
					break;
				}
				else
				{
					if (value2.StagiuComanda == "Waiting")
					{
						value2.StagiuComanda = "Preparing";
						bucatari.Bucatar--;
					}
				}
			}


			FrameMain.Content = new AsteptareConfirmare(obsDataWainting, received_string);
			
		}

		private void ListViewItem_MouseDoubleClick_OpenPreparareComanda(object sender, MouseButtonEventArgs e)
		{
			if(obsDataWainting!=null)
			{

				foreach (var value2 in obsDataWainting)
				{
					if (bucatari.Bucatar != 0)
					{
						break;
					}
					else
					{
						if (value2.StagiuComanda == "Preparing")
						{
							value2.StagiuComanda = "Confirm To Be Delivered";
							bucatari.Bucatar++;
						}
					}
				}
			}

			//MessageBox.Show(bucatari.Bucatar.ToString());

			
			FrameMain.Content = new PreparareComanda(obsDataWainting);

		}

		private void ListViewItem_MouseDoubleClick_OpenLivrareComanda(object sender, MouseButtonEventArgs e)
		{
			if (obsDataWainting != null)
			{
				received_string = "Orders;1555;fasfasdsadasdasad;076;bd Viilor;10;uiteceva;alteceva;...;14;ionel;075;bd georgescu;4;piftefdsfsle;ciorfsdfaba;...";
				foreach (var value2 in obsDataWainting)
				{
					if (bucatari.Bucatar != 0)
					{
						break;
					}
					else
					{ 
						if (value2.StagiuComanda == "Waiting To Be Delivered")
						{
							value2.StagiuComanda = "Delivering";
						
						}
					}
				}
			}


			FrameMain.Content = new InCursDeLivrareComanda(obsDataWainting);
		}

		private void ListViewItem_MouseDoubleClick_OpenIstoric(object sender, MouseButtonEventArgs e)
		{
			FrameMain.Content = new IstoricComenzi(obsDataWainting);
		}
	}
}
