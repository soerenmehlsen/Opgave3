using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Weight
    {
        public double Weight { get; set; }
        public int BMI { get; set; }
        public DateTime Date { get; set; }

        public DTO_Weight(double weight, int BMI, DateTime date)
        {
            Weight = weight;
            this.BMI = BMI;
            Date = date;
        }
    }
}