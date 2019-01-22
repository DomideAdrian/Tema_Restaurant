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
using System.Windows.Shapes;
using Restaurant;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            WriteMessage loginRequest = new WriteMessage();
            ReadMessage loginAck = new ReadMessage();

            List<string> credentials = new List<string>
            {
                TextBoxUsername.Text,
                TextBoxPassword.Password.ToString()
            };
            string requestString = loginRequest.WeldPhrase("LOGIN", credentials); //creez mesajul pe care il trimit la server

            string ackString = loginAck.GetPhrase(requestString); //primesc mesaj de la server
            string accept = loginAck.SplitPhrase(ackString, 0);
            if (accept == "LOGIN_ERROR") //verific daca ma pot loga sau nu
            {
                MessageBox.Show("Server not working");
            }
            else
            {
                string username = loginAck.SplitPhrase(ackString, 1);
                string password = loginAck.SplitPhrase(ackString, 2);

                if (username == "1" && password == "1") //user si parola harcodate, trebuie modificat
                {
                    MainWindow app = new MainWindow
                    {
                        UsernameProperty = username
                    };
                    app.Show();
                    
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
