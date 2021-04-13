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
using Logic_tier;

namespace Opgave2
{
    /// <summary>
    /// Interaction logic for LoginUI.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Logic logicRef;
        private MainWindow mainWRef;
        public LoginWindow(MainWindow mainWRef, Logic logicRef)
        {
            InitializeComponent();
            this.mainWRef = mainWRef;
            this.logicRef = logicRef;

            UserNameTB.Focus();
            UserNameTB.SelectAll();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e) //Check brugernavn og password
        {
            if (logicRef.checkLogin(UserNameTB.Text, passswordBox.Password) == true)
            {
                LoginW.Hide();
                mainWRef.LoginOK = true;
            }
            else
            {
                MessageBox.Show("Forkert brugernavn eller password");
                UserNameTB.Clear();
                passswordBox.Clear();
                UserNameTB.Focus();
                mainWRef.LoginOK = false;
            }
        }

        private void LoginWindow_MouseDown(object sender, MouseButtonEventArgs e) //Flyt rundt på vinduet med mus
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void exitLoginBT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void passswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passswordBox.SelectAll();
        }
    }
}
