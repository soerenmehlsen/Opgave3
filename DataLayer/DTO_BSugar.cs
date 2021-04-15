using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BSugar
    {
        public double BloodSugar { get; set; }
        public DateTime Date { get; set; }

        public DTO_BSugar(double bloodSugar, DateTime date)
        {
            BloodSugar = bloodSugar;
            Date = date;
        }
    }
}