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
	/// Interaction logic for AddMeniuPage.xaml
	/// </summary>
	public partial class AddMeniuPage : Page
	{
	
		public AddMeniuPage()
		{
			InitializeComponent();





		}




		private void AddMeniuButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string _NumeCategorie = NumeCategorieTextBox.Text;
			string _NumeMeniu = NumeCategorieTextBox.Text;
			string _Pret = PretTextBox.Text;
			string _Descriere= DescriereTextBox.Text;
			string _TimpDePreparare = TimpDePreparareTextBox.Text;
			
			if(_Pret==""||_NumeCategorie==""||_NumeMeniu==""||_Descriere==""||_TimpDePreparare=="")
			{
				MessageBox.Show("Va rugam completati toate spatiile");
				return;
			}
			
			MessageBox.Show("Meniu inserat");


			MyUtils.Insert_order = "INSERT_PRODUCT" + ';' + _NumeMeniu + ';' + _NumeCategorie + ';' + _Pret + ';' + _TimpDePreparare + ';' + _Descriere + ';';
			
		}
	}
}
