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

namespace Opgave2
{
    /// <summary>
    /// Interaction logic for Bloodpressure.xaml
    /// </summary>
    public partial class BPWindow : Window
    {
        private Logic logicRef;
        private string SocSecNb;
        public ChartValues<double> YValues1 { get; set; }
        public ChartValues<double> YValues2 { get; set; }
        public List<String> XValues2 { get; set; }
        public BPWindow(string SocSecNb, Logic logicRef)
        {
            InitializeComponent();
            this.SocSecNb = SocSecNb;
            this.logicRef = logicRef;

            YValues1 = new ChartValues<double>();
            YValues2 = new ChartValues<double>();
            XValues2 = new List<String>();
            
        }

        private void BPChart_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<DTO_BPressure> bpList = logicRef.getBPressureData(SocSecNb);

            foreach (var x in bpList)
            {
                YValues1.Add(Convert.ToDouble($"{x.Systolic}"));
                YValues2.Add(Convert.ToDouble($"{x.Diastolic}"));
                XValues2.Add(Convert.ToString($"{x.Date}"));
            }
        }

        private void BPressureWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void exitBPBT_Click(object sender, RoutedEventArgs e)
        {
            BPressureWindow.Hide();
        }
    }
}
