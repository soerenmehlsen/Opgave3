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
using Logic_tier;

namespace Opgave2
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
        public string SocSecNb { get; set; } //property
        public bool LoginOK { get; set; } //property
        public MainWindow()
        {
            InitializeComponent();
            logicObj = new Logic();
            loginW = new LoginWindow(this, logicObj);
            

            bloodsugarW = new BSWindow(SocSecNb, logicObj);
            bloodpressureW = new BPWindow(SocSecNb, logicObj);
            weightW = new WeightWindow(SocSecNb, logicObj);

        }

        private void exitBT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BSugarButton_Click(object sender, RoutedEventArgs e)
        {
            
            bloodsugarW.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainW.Hide();
            loginW.ShowDialog();

            if (LoginOK == true)
            {
                MainW.Show();
                
            }
            if (LoginOK == false)
            {
                MainW.Close();
            }

        }

        private void BPressureButton_Click(object sender, RoutedEventArgs e)
        {
            bloodpressureW.ShowDialog();
        }

        private void WeightButton_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
