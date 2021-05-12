using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataLayer
{
    public interface IData
    {
        bool isUserRegistered(String socSecNb, String pw);

        int getHeight(String socSecNb);

        List<DTO_Weight> getWeightData(String socSecNb);

        List<DTO_BSugar> getBSugarData(String socSecNb);

        List<DTO_BPressure> getBPressureData(String socSecNb);
    }
}
