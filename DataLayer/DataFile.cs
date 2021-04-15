using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO;

namespace DataLayer
{
    class DataFile : IData
    {
        private FileStream input;
        private StreamReader reader;
        // Herunder KAN du skrive en sti til den mappe hvori er gemt.
        // MEN i fht. OPGAVE 3 SKAL filerne placeres korrekt i PROJEKTET - ellers virker det ikke når du afleverer opgaven.
        private const String filepath = @"\\C:\Users\Søren Mehlsen\source\repos\Opgave2\DataLayer\bin\Debug\";

        public DataFile() {}

        public override bool isUserRegistered(String socSecNb, String pw)
        {
            bool result = false;

            input = new FileStream(filepath + "Registered Users.txt", FileMode.Open, FileAccess.Read);
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

        public override int getHeight(String socSecNb)
        {
            input = new FileStream(filepath + "Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);
        }

        public override List<DTO_Weight> getWeightData(String socSecNb)
        {
        }

        public override List<DTO_BSugar> getBSugarData(String socSecNb)
        {
        }

        public override List<DTO_BPressure> getBPressureData(String socSecNb)
        {
        }
    }
}