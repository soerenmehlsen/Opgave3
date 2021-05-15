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
        private const String DBlogin = "F21ST2ITS2au639422";


        public DataBase() { }

        public bool isUserRegistered(String socSecNb, String pw)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            bool result = false;

            command = new SqlCommand("select * from RegisteredUsers where SocSecNb ='" + socSecNb + "' AND PW = " + pw + "", connection);

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.Read())
            {
                if (Convert.ToBoolean(reader["SocSecNb"]) == true)
                    result = true; 
                else
                    result = false; 
            }
            connection.Close();
            return result; 
        }

        public int getHeight(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            int result = 0;

            command = new SqlCommand("select * from RegisteredUsers where SocSecNb ='" + socSecNb + "'", connection);

            connection.Open();

            reader = command.ExecuteReader();

            result = Convert.ToInt32(reader["Height"]);

            connection.Close();
            return result;
        }

        public List<DTO_Weight> getWeightData(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<DTO_Weight> weightList = new List<DTO_Weight>();

            command = new SqlCommand("select * from WeightData where SocSecNb ='" + socSecNb + "'", connection);

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.Read())
            {
                weightList.Add(new DTO_Weight(Convert.ToDouble(reader["Weight"]), 0, Convert.ToDateTime(reader["Date"])));
            }
            connection.Close();
            return weightList;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return;
        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return;
        }
    }


}
