using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO;

namespace DataLayer
{
    public class DataFile : IData
    {
        private FileStream input;
        private StreamReader reader;
        //private const String filepath = @"\\C:\Users\Søren Mehlsen\source\repos\Opgave2\Opgave2\bin\Debug";
        //Jeg har valgt at lade programmet gemme filerne i debug mappen, som er standard mappen..

        static void Main(string[] args) { }
        public DataFile() { }

        public bool isUserRegistered(String socSecNb, String pw)
        {
            bool result = false;

            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            string inputRecord;
            string[] inputFields;

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb && inputFields[1] == pw)
                {
                    result = true;
                    break;
                }
            }

            reader.Close();

            return result;
        }

        public int getHeight(String socSecNb)
        {
            int result = 0;

            string inputRecord;
            string[] inputFields;

            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            while ((inputRecord = reader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    result = Convert.ToInt32(inputFields[2]);
                }
            }
            reader.Close();

            return result;
        }

        public List<DTO_Weight> getWeightData(String socSecNb)
        {
            List<DTO_Weight> weightList = new List<DTO_Weight>();

            string inputRecord;
            string[] inputFields;

            FileStream input = new FileStream("Weight Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);

            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    weightList.Add(new DTO_Weight(Convert.ToDouble(inputFields[1]), 0, Convert.ToDateTime(inputFields[2])));
                }
            }
            fileReader.Close();

            return weightList;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            List<DTO_BSugar> bsList = new List<DTO_BSugar>();

            string inputRecord;
            string[] inputFields;

            FileStream input = new FileStream("Blood Sugar Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);

            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    bsList.Add(new DTO_BSugar(Convert.ToDouble(inputFields[1]), Convert.ToDateTime(inputFields[2])));
                }
            }
            fileReader.Close();

            return bsList;
        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            List<DTO_BPressure> bpList = new List<DTO_BPressure>();

            string inputRecord;
            string[] inputFields;

            FileStream input = new FileStream("Blood Pressure Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);

            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    bpList.Add(new DTO_BPressure(Convert.ToInt32(inputFields[1]), Convert.ToInt32(inputFields[2]), Convert.ToDateTime(inputFields[3])));
                }
            }
            fileReader.Close();

            return bpList;
        }
    }
}