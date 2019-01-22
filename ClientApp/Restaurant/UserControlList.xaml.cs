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
    /// Interaction logic for UserControlList.xaml
    /// </summary>
    public partial class UserControlList : UserControl
    {
        ObservableCollection<ObservableDrink> drinks = new ObservableCollection<ObservableDrink>();
        public UserControlList()
        {
            InitializeComponent();

            DataContext = GetDrink();
        }
        public ObservableCollection<ObservableDrink> GetDrink()
        {
            drinks.Add(new ObservableDrink()
            {
                DrinkName = "Pizza1",
                ImageSource = "Assets/Pizza1.png",
                DrinkDescription = "Nice Pizza",
                DrinkPrice = "22$"
            });
            drinks.Add(new ObservableDrink()
            {
                DrinkName = "Pizza2",
                ImageSource = "Assets/Pizza2.png",
                DrinkDescription = "Good Pizza",
                DrinkPrice = "33$"
            });
            drinks.Add(new ObservableDrink()
            {
                DrinkName = "Pizza3",
                ImageSource = "Assets/Pizza3.png",
                DrinkDescription = "Expensive Pizza",
                DrinkPrice = "40$"
            });

            return drinks;
        }

        private void ButtonAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in drinks)
            {
                if (item.IsCheked == true)
                {
                    BasketList.ShoppingItems.Add(item.DrinkName);
                    BasketList.PriceOfItem.Add(item.DrinkPrice);
                }
            }
        }
    }
}
