using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp1.Model;
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


		DataProcessorViewModel pProcessData = new DataProcessorViewModel();
		string received_string = "ORDERS;1555;mitica;076;bd Viilor;10;uiteceva;alteceva;...;144;ion;075;bd georgescu;4;piftele;ciorba;...";
		Angajati bucatari = new Angajati();

		List<string> received_flag;
	



	//	public Connection connect = new Connection();

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




		/// <summary>
		/// Pagini
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListViewItem_MouseDoubleClick_OpenAsteptareConformareComanda(object sender, MouseButtonEventArgs e)
		{
			
			//received_string = connect.Send(MyUtils.Request_Order);
			
			if (received_string != null)
			{
				received_flag = pProcessData.mDetectFlag(received_string);
			}
				if (received_flag[0] == "ORDERS")
				{
					received_flag.RemoveAt(0);

					obsDataWainting = pProcessData.mSplit(received_flag, obsDataWainting);
					received_string = null;
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

		/// <summary>
		/// Pagina in care sunt afisate comenzile ce sunt in stagiu de preparare sau sunt pregatite sa fie livrate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListViewItem_MouseDoubleClick_OpenPreparareComanda(object sender, MouseButtonEventArgs e)
		{

			//received_string = connect.Send(MyUtils.Insert_order);


			if (received_string != null )
			{
				received_flag = pProcessData.mDetectFlag(received_string);
				
			}
			if (received_flag[0] == "CURIERS")
			{
			
				received_flag.RemoveAt(0);
				MyUtils.listaCurieri=pProcessData.mSplitCurieri(received_flag);
				received_string = null;
				
			}


			


			if (obsDataWainting!=null)
			{
				foreach (var value2 in obsDataWainting)
				{
				
						if (value2.StagiuComanda == "Preparing")
						{

							value2.StagiuComanda = "Confirm To Be Delivered";
							bucatari.Bucatar++;
						}
				}
				
			}
			
				FrameMain.Content = new PreparareComanda(obsDataWainting);
			
		}


		/// <summary>
		/// page facuta pentru a afisa toate comenzile ce se livreaza curent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void ListViewItem_MouseDoubleClick_OpenLivrareComanda(object sender, MouseButtonEventArgs e)
		{
			if (obsDataWainting != null)
			{
			
				foreach (var value2 in obsDataWainting)
				{
				
						if (value2.StagiuComanda == "Confirm To Be Delivered" && MyUtils.listaCurieri!=null)
						{
							foreach (var value in MyUtils.listaCurieri)
							{
								if (value.StagiuComandaCurier == "Waiting")
								{

									value2.StagiuComanda = "Delivering";
									value.StagiuComandaCurier = "Delivering";
								    value.Id_comanda = value2.Id_comanda;
								}
							}
							
						
						}
					
				}
			}


			FrameMain.Content = new InCursDeLivrareComanda(obsDataWainting);
		}

		/// <summary>
		/// afiseaza toate comenzile ce au fost livrate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListViewItem_MouseDoubleClick_OpenIstoric(object sender, MouseButtonEventArgs e)
		{
			if (obsDataWainting != null)
			{
				foreach (var value2 in obsDataWainting)
				{
					
						if (value2.StagiuComanda == "Delivering")
						{
							value2.StagiuComanda = "Delivered";
							
						   foreach(var value in MyUtils.listaCurieri)
						{
							if(value.Id_comanda==value2.Id_comanda && value.StagiuComandaCurier=="Delivering")
							{
								value.StagiuComandaCurier = "Waiting";
							}
						}
						}
				}
			}
			FrameMain.Content = new IstoricComenzi(obsDataWainting);
		}


		/// <summary>
		/// Page Adaugare Meniu 
		/// se realizaeaza construirea sirului de trimitere a datelor pentru a inserarea unui unui produs
		/// cu datele aferente acestuia
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ListViewItem_MouseDoubleClick_openAddMeniu(object sender, MouseButtonEventArgs e)
		{

			FrameMain.Content = new AddMeniuPage();
		
			//MyUtils.Receive_message = connect.Send(MyUtils.Insert_order);

			

		}
	}
}
