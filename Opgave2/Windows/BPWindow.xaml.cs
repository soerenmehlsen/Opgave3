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
using LogicLayer;
using DTO;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Bloodpressure.xaml
    /// </summary>
    public partial class BPWindow : Window
    {
        private Logic logicRef;
        private String socSecNb;
        public ChartValues<double> YValues1 { get; set; }
        public ChartValues<double> YValues2 { get; set; }
        public List<string> XValues2 { get; set; }
        
        public BPWindow(string SocSecNb, Logic logicRef)
        {
            InitializeComponent();
            this.socSecNb = SocSecNb;
            this.logicRef = logicRef;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            YValues1 = new ChartValues<double>();
            YValues2 = new ChartValues<double>();
            XValues2 = new List<string>();

            List<DTO_BPressure> bpList = logicRef.getBPressureData(socSecNb);

            foreach (var x in bpList)
            {
                YValues1.Add(Convert.ToDouble($"{x.Systolic}"));
                YValues2.Add(Convert.ToDouble($"{x.Diastolic}"));
                XValues2.Add(Convert.ToString($"{x.Date}"));

            }
            DataContext = this;
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
