using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataLayer;

namespace LogicLayer
{
    public class Logic
    {
        private DataFile dataObject;
        static void Main(string[] args)
        {

        }
        public Logic()
        {
            dataObject = new DataFile();
        }

        public bool CheckLogin(String socSecNb, String pw)
        {
            if (dataObject.isUserRegistered(socSecNb, pw) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<DTO_Weight> getWeightAndBMIData(String socSecNb)
        {
            double height;
            List<DTO_Weight> weightList = dataObject.getWeightData(socSecNb);
            height = dataObject.getHeight(socSecNb);

            foreach (DTO_Weight x in weightList)
            {
                x.BMI = Convert.ToInt32(x.Weight) / Convert.ToInt32((height / 100) * (height / 100));
            }

            return weightList;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            return dataObject.getBSugarData(socSecNb);
        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            return dataObject.getBPressureData(socSecNb);
        }
    }
}
