using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataLayer
{
      abstract public class IData
    {
        static void Main(string[] args)
        {
        }

        abstract public bool isUserRegistered(String socSecNb, String pw);

        abstract public int getHeight(String socSecNb);

        abstract public List<DTO_Weight> getWeightData(String socSecNb);

        abstract public List<DTO_BSugar> getBSugarData(String socSecNb);

        abstract public List<DTO_BPressure> getBPressureData(String socSecNb);
    }
}
