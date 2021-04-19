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
using LogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic logicObj;
        private LoginWindow loginW;
        private BSWindow bloodsugarW;
        private BPWindow bloodpressureW;
        private WeightWindow weightW;
        public String SocSecNb { get; set; }
        public bool LoginOK { get; set; }
        public String Username { get; set; } //property (visning af brugernavn på hovedmenu)
        public MainWindow()
        {
            InitializeComponent();
            logicObj = new Logic();
            loginW = new LoginWindow(this, logicObj);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainW.Hide();
            loginW.ShowDialog();

            if (LoginOK == true)
            {
                MainW.Show();
                Username = SocSecNb; //Visning af brugernavn på hovedmenu

            }
            if (LoginOK == false)
            {
                MainW.Close();
            }
            DataContext = this;
        }

        private void bsButton_Click(object sender, RoutedEventArgs e)
        {
            bloodsugarW = new BSWindow(SocSecNb, logicObj);
            bloodsugarW.ShowDialog();
        }

        private void bpButton_Click(object sender, RoutedEventArgs e)
        {
            bloodpressureW = new BPWindow(SocSecNb, logicObj);
            bloodpressureW.ShowDialog();
        }

        private void weightButton_Click(object sender, RoutedEventArgs e)
        {
            weightW = new WeightWindow(SocSecNb, logicObj);
            weightW.ShowDialog();
        }


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (OneWeekRB.IsChecked == true)
            {
                MessageBox.Show("Dine oplysninger for 1 uge er sendt! :-)");
            }
            else if (TwoWeekRB.IsChecked == true)
            {
                MessageBox.Show("Dine oplysninger for 2 uger er sendt! :-)");
            }
            else if (FourWeekRB.IsChecked == true)
            {
                MessageBox.Show("Dine oplysninger for 4 uger er sendt! :-)");
            }
            else
            {
                MessageBox.Show("Du skal vælge en periode");
            }
        }

        private void MainW_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            loginW.Show();
            MainW.Hide();
        }

        private void exitBT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
