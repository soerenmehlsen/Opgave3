using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DataBase : IData
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;
        private String const DBlogin;
        
        public DataBase() { }

        public bool isUserRegistered(String socSecNb, String pw)
        {
            return true; 
        }

        public int getHeight(String socSecNb)
        {
            return 1;
        }

        public List<DTO_Weight> getWeightData(String socSecNb)
        {
            return;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            return;
        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            return;
        }
    }


}
