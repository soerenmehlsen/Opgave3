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
    /// Interaction logic for Weight.xaml
    /// </summary>
    public partial class WeightWindow : Window
    {
        private Logic logicRef;
        private String socSecNb;
        public ChartValues<double> YValues3 { get; set; }
        public ChartValues<double> YValues4 { get; set; }
        public List<string> XValues1 { get; set; }
        public WeightWindow(string SocSecNb, Logic logicRef)
        {
            InitializeComponent();
            this.socSecNb = SocSecNb;
            this.logicRef = logicRef;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            YValues3 = new ChartValues<double>();
            YValues4 = new ChartValues<double>();
            XValues1 = new List<string>();

            List<DTO_Weight> weightList = logicRef.getWeightAndBMIData(socSecNb);

            foreach (var x in weightList)
            {
                YValues3.Add(Convert.ToDouble($"{x.Weight}"));
                YValues4.Add(Convert.ToDouble($"{x.BMI}"));
                XValues1.Add(Convert.ToString($"{x.Date}"));
            }

            DataContext = this;
        }

        private void exitWeightBT_Click(object sender, RoutedEventArgs e)
        {
            WWindow.Hide();
        }

        private void WWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
