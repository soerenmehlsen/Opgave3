using System;
using System.Data;
using System.IO;
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

            command = new SqlCommand("select * from RegisteredUsers where SocSecNb ='" + socSecNb + "'", connection);

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.Read())
            {
                if (Convert.ToString(reader["SocSecNb"]) == socSecNb && Convert.ToString(reader["PW"]) == pw)
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

            int height = 0;

            command = new SqlCommand("select * from RegisteredUsers where SocSecNb ='" + socSecNb + "'", connection);

            connection.Open();

            reader = command.ExecuteReader();

            if (reader.Read())
            {
                height = Convert.ToInt32(reader["Height"]);
            }

            connection.Close();
            return height;
        }

        public List<DTO_Weight> getWeightData(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<DTO_Weight> weightList = new List<DTO_Weight>();

            SqlDataAdapter command = new SqlDataAdapter("select * from WeightData where SocSecNb ='" + socSecNb + "'", connection);
            connection.Open();

            DataTable dt = new DataTable();
            command.Fill(dt);


            foreach (DataRow row in dt.Rows)
            {
                weightList.Add(new DTO_Weight(Convert.ToDouble(row["Weight"]), 0, Convert.ToDateTime(row["Date"])));
            }
            connection.Close();
            return weightList;

            //metode 2
            //command = new SqlCommand("select * from WeightData where SocSecNb ='" + socSecNb + "'", connection);

            //connection.Open();

            //reader = command.ExecuteReader();

            //while(reader.Read())
            //{
            //    if (Convert.ToString(reader["SocSecNb"]) == socSecNb)
            //    {
            //        weightList.Add(new DTO_Weight(Convert.ToDouble(reader["Weight"]), 0, Convert.ToDateTime(reader["Date"])));
            //    }
            //}
            //connection.Close();
            //return weightList;
        }

        public List<DTO_BSugar> getBSugarData(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<DTO_BSugar> bsList = new List<DTO_BSugar>();

            //metode 1
            SqlDataAdapter command = new SqlDataAdapter("select * from BloodSugarData where SocSecNb ='" + socSecNb + "'", connection);

            connection.Open();

            DataTable dt = new DataTable();
            command.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                bsList.Add(new DTO_BSugar(Convert.ToDouble(row["BloodSugar"]), Convert.ToDateTime(row["Date"])));
            }

            connection.Close();

            return bsList;

            //metode 2
            //command = new SqlCommand("select * from BloodSugarData where SocSecNb ='" + socSecNb + "'", connection);

            //connection.Open();

            //reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    if (Convert.ToString(reader["SocSecNb"]) == socSecNb)
            //    {
            //        bsList.Add(new DTO_BSugar(Convert.ToDouble(reader["BloodSugar"]), Convert.ToDateTime(reader["Date"])));
            //    }
            //}
            //connection.Close();
            //return bsList;
        }

        public List<DTO_BPressure> getBPressureData(String socSecNb)
        {
            connection = new SqlConnection("Data Source=st-i4dab.uni.au.dk;Initial Catalog=" + DBlogin + ";User ID=" + DBlogin + ";Password=" + DBlogin + ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<DTO_BPressure> bpList = new List<DTO_BPressure>();

            //metode 1
            SqlDataAdapter command = new SqlDataAdapter("select * from BloodPressure where SocSecNb ='" + socSecNb + "'", connection);

            connection.Open();

            DataTable dt = new DataTable();
            command.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                bpList.Add(new DTO_BPressure(Convert.ToInt32(row["Systolic"]), Convert.ToInt32(row["Diastolic"]), Convert.ToDateTime(row["Date"])));
            }

            connection.Close();

            return bpList;

            //metode 2
            //command = new SqlCommand("select * from BloodPressure where SocSecNb ='" + socSecNb + "'", connection);

            //connection.Open();

            //reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    if (Convert.ToString(reader["SocSecNb"]) == socSecNb)
            //    {
            //        bpList.Add(new DTO_BPressure(Convert.ToInt32(reader["Systolic"]), Convert.ToInt32(reader["Diastolic"]), Convert.ToDateTime(reader["Date"])));
            //    }
            //}
            //connection.Close();
            //return bpList;
        }
    }
}
