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
using LiveCharts;
using LiveCharts.Wpf;
using Logic_tier;
using DTO;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Bloodsugar.xaml
    /// </summary>
    public partial class BSWindow : Window
    {
        private Logic logicRef;
        private string SocSecNb;
        public ChartValues<double> YValues { get; set; }
        public List<string> XValues { get; set; }


        public BSWindow(string SocSecNb, Logic logicRef)
        {
            InitializeComponent();
            this.SocSecNb = SocSecNb;
            this.logicRef = logicRef;

        }

        private void BSWindow_Loaded(object sender, RoutedEventArgs e)
        {
            YValues = new ChartValues<double>();
            XValues = new List<string>();

            List<DTO_BSugar> bsList = logicRef.getBSugarData(SocSecNb);

            foreach (var x in bsList)
            {
                YValues.Add(Convert.ToDouble(x.BloodSugar));
                XValues.Add(Convert.ToString(x.Date));
            }
            DataContext = this;
        }
        private void exitBSBT_Click(object sender, RoutedEventArgs e)
        {
            BSugarWindow.Hide();
        }

        private void BSugarWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
