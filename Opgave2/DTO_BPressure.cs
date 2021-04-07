using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BPressure
    {
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public DateTime Date { get; set; }

        public DTO_BPressure(int systolic, int diastolic, DateTime date)
        {
            Systolic = systolic;
            Diastolic = diastolic;
            Date = date;
        }
    }
}