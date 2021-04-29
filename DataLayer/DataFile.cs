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
        // Herunder KAN du skrive en sti til den mappe hvori er gemt.
        // MEN i fht. OPGAVE 3 SKAL filerne placeres korrekt i PROJEKTET - ellers virker det ikke når du afleverer opgaven.
        //private const String filepath = @"\\C:\Users\Søren Mehlsen\source\repos\Opgave2\Opgave2\bin\Debug";
        //Jeg har valgt at lade programmet gemme filerne i debug mappen, som er standard mappen..
        public DataFile() { }

        public override bool isUserRegistered(String socSecNb, String pw)
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

        public override int getHeight(String socSecNb)
        {
            int result = 0;
            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;

            input = new FileStream("Registered Users.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(input);

            // indlæs sålænge der er data i filen
            while ((inputRecord = reader.ReadLine()) != null)
            {
                // split data op i CPR-NR, adgangskode, højde
                inputFields = inputRecord.Split(';');

                // gem data i listen
                //contacts.Add(new People(inputFields[0], Convert.ToInt32(inputFields[2])));

                if (inputFields[0] == socSecNb)
                {
                    result = Convert.ToInt32(inputFields[2]);
                }
            }

            // luk adgang til filen
            reader.Close();

            return result;
        }

        public override List<DTO_Weight> getWeightData(String socSecNb)
        {
            List<DTO_Weight> weightList = new List<DTO_Weight>();

            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;


            // opret de nødvendige stream-objekter
            FileStream input = new FileStream("Weight Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);


            // indlæs sålænge der er data i filen
            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                // split data op i fornavn, efternavn og telefonnummer
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    // gem data i listen
                    weightList.Add(new DTO_Weight(Convert.ToDouble(inputFields[1]), 0, Convert.ToDateTime(inputFields[2])));
                }
            }
            // luk adgang til filen
            fileReader.Close();

            return weightList;
        }

        public override List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            List<DTO_BSugar> bsList = new List<DTO_BSugar>();

            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;


            // opret de nødvendige stream-objekter
            FileStream input = new FileStream("Blood Sugar Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);


            // indlæs sålænge der er data i filen
            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                // split data op i fornavn, efternavn og telefonnummer
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    // gem data i listen
                    bsList.Add(new DTO_BSugar(Convert.ToDouble(inputFields[1]), Convert.ToDateTime(inputFields[2])));
                }
            }
            // luk adgang til filen
            fileReader.Close();

            return bsList;
        }

        public override List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            List<DTO_BPressure> bpList = new List<DTO_BPressure>();

            // string-objekter til at gemme det som læses fra filen
            string inputRecord;
            string[] inputFields;


            // opret de nødvendige stream-objekter
            FileStream input = new FileStream("Blood Pressure Data.txt", FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(input);


            // indlæs sålænge der er data i filen
            while ((inputRecord = fileReader.ReadLine()) != null)
            {
                // split data op i fornavn, efternavn og telefonnummer
                inputFields = inputRecord.Split(';');

                if (inputFields[0] == socSecNb)
                {
                    // gem data i listen
                    bpList.Add(new DTO_BPressure(Convert.ToInt32(inputFields[1]), Convert.ToInt32(inputFields[2]), Convert.ToDateTime(inputFields[3])));
                }
            }
            // luk adgang til filen
            fileReader.Close();

            return bpList;
        }
    }
}