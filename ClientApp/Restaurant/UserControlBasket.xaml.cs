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

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for UserControlBasket.xaml
    /// </summary>
    public partial class UserControlBasket : UserControl
    {
        //ObservableCollection<string> test = new ObservableCollection<string>();
        ObservableCollection<ShowShopList> listOfItems = new ObservableCollection<ShowShopList>();
        public UserControlBasket()
        {
            InitializeComponent();
            DataContext = Function();
            //Function();
        }
        //public void Function()
        //{
        //    foreach(var i in BasketList.ShoppingItems)
        //    {
        //        test.Add(i);
        //    }
        //}
        public ObservableCollection<ShowShopList> Function()
        {
            foreach(var i in BasketList.ShoppingItems)
            {
                listOfItems.Add(new ShowShopList()
                {
                    NameOfItem = i,
                    PriceOfItem = BasketList.PriceOfItem[BasketList.ShoppingItems.IndexOf(i)]
                });
            }
            /*foreach(var j in BasketList.PriceOfItem)
            {
                listOfItems.Add(new ShowShopList()
                {
                    PriceOfItem = j
                });

            }*/
            return listOfItems;
        }
         
    }
}
