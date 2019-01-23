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
    /// Interaction logic for UserControlDrinks.xaml
    /// </summary>
    public partial class UserControlDrinks : UserControl
    {
        private ObservableDrink selectdDrink;
        public ObservableDrink SelectedDrink
        {
            get
            {
                return selectdDrink;
            }
            set
            {
                selectdDrink = value;
            }
        }
        
        ObservableCollection<ObservableDrink> drinks = new ObservableCollection<ObservableDrink>();

        public ObservableCollection<ObservableDrink> DrinkingList
        {
            get
            {
                if (drinks == null)
                {
                    drinks = new ObservableCollection<ObservableDrink>();
                    drinks = GetDrink();
                }
                return GetDrink();
            }
            set
            {
                drinks = value;
            }
        }

        public UserControlDrinks()
        {
            InitializeComponent();
            DataContext = GetDrink();
            //DataContext = this;

        }
        public ObservableCollection<ObservableDrink> GetDrink()
        {

            WriteMessage loginRequest = new WriteMessage();
            ReadMessage loginAck = new ReadMessage();

            List<string> categoryName = new List<string>
            {
                "Drinks"
            };

            string requestString = loginRequest.WeldPhrase("REQUEST_CATEGORY_PRODUCTS", categoryName); //cer categoria mancare

            Connection toServerConnection = new Connection();
            string response = toServerConnection.Send(requestString);

            string ackString = loginAck.GetPhrase(response); //primesc mesaj de la server
            string accept = loginAck.SplitPhrase(response, 0);

            if (accept != "REQUEST_CATEGORY_PRODUCTS")
            {
                MessageBox.Show("Error from server!");
            }
            else
            {
                for (int i = 1; i < ackString.Count(); i++)
                {
                    string nameOfItem = loginAck.SplitPhrase(response, i);
                    string descriptionOfItem = loginAck.SplitPhrase(response, i + 1);
                    string priceOfItem = loginAck.SplitPhrase(response, i + 2);
                    drinks.Add(new ObservableDrink()
                    {
                        DrinkName = nameOfItem,
                        ImageSource = "Assets/Pizza1.png",
                        DrinkDescription = descriptionOfItem,
                        DrinkPrice = priceOfItem
                    });
                }
            }

            /*
            drinks.Add(new ObservableDrink()
            {
                DrinkName = "Cola",
                ImageSource = "Assets/Cola.png",
                DrinkDescription = "GOOOOOOOD COLA",
                DrinkPrice = "3$",
                IsCheked = false

            });

            drinks.Add(new ObservableDrink()
            {
                DrinkName = "Jack Daniels",
                ImageSource = "Assets/JD.png",
                DrinkDescription = "DDD",
                DrinkPrice = "10$",
                IsCheked = false
            });
            drinks.Add(new ObservableDrink()
            {
                DrinkName = "Tea",
                ImageSource = "Assets/Tea.png",
                DrinkDescription = "TEA",
                DrinkPrice = "4$",
                IsCheked = false
            });*/

            return drinks;
        }

        private void ButtonAddToBasket_Click(object sender, RoutedEventArgs e)
        {
           // BasketList itemsToBuy = new BasketList();
            foreach(var item in drinks)
            {
                if(item.IsCheked==true)
                {
                    BasketList.ShoppingItems.Add(item.DrinkName);
                    BasketList.PriceOfItem.Add(item.DrinkPrice);
                }
            }
        }


        //private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
