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
    /// Interaction logic for Weight.xaml
    /// </summary>
    public partial class WeightWindow : Window
    {
        private Logic logicRef;
        private string SocSecNb;
        public ChartValues<double> YValues3 { get; set; }
        public ChartValues<double> YValues4 { get; set; }
        public List<String> XValues1 { get; set; }
        public WeightWindow(string SocSecNb, Logic logicRef)
        {
            InitializeComponent();
            this.SocSecNb = SocSecNb;
            this.logicRef = logicRef;

            YValues3 = new ChartValues<double>();
            YValues4 = new ChartValues<double>();
            XValues1 = new List<String>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<DTO_Weight> weightList = logicRef.getWeightAndBMIData("SocSecNb");

            foreach (var x in weightList)
            {
                YValues3.Add(Convert.ToDouble($"{x.Weight}"));
                YValues4.Add(Convert.ToDouble($"{x.BMI}"));
                XValues1.Add(Convert.ToString($"{x.Date}"));
            }

            DataContext = this;
        }
    }
}
