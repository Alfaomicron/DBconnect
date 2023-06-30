using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;

namespace database_connection
{
    public class dbconnection
    {
        //public SqlConnection connectdb = new SqlConnection();
        public MySqlConnection connectdb1 = new MySqlConnection();

        public dbconnection()
        {
            //string connargs = "Data Source="+configParams.dbURL+","+configParams.dbPort+";User ID="+configParams.dbUname+";Password="+configParams.dbPasswd;
            //connectdb.ConnectionString = connargs;

            string connargs1 = "Server = "+configParams.dbURL+"; Database = basensor; Uid = "+ configParams.dbUname+"; Pwd = " +configParams.dbPasswd;
            connectdb1.ConnectionString = connargs1;

            connectdb1.ConnectionString = "";
        }
        public bool open()
        {
            try
            {
                connectdb1.Open();
                //MessageBox.Show("Connection Open!");
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void close()
        {
            connectdb1.Close();
        }

        public String[] showdb(String query)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            ushort ncols;
            var listOfStrings = new List<String> { };

            command = new SqlCommand(query, connectdb);
            dataReader = command.ExecuteReader();

            listOfStrings.Add("" + dataReader.GetName(0).GetType() + dataReader.GetName(1));
            ncols = ((ushort)dataReader.FieldCount);
            while (dataReader.Read())
            {

                listOfStrings.Add("" + dataReader.GetValue(0) + dataReader.GetValue(1));
            }

            dataReader.Close();
            String[] output = listOfStrings.ToArray();

            return output;

        }

        public String[,] getdata()
        {
            SqlCommand command;
            SqlDataReader dataReader;

            String[,] samples = new String[2,graphdata.nsamples];

            command = new SqlCommand("Select top("+graphdata.nsamples.ToString()+") sample,value from getdata.dbo.sensor order by convert(int,sample) desc", connectdb);
            dataReader = command.ExecuteReader();

            int i = 0;
            while (dataReader.Read())
            {

                samples[0,graphdata.nsamples-i-1] = dataReader.GetValue(0).ToString();
                samples[1, graphdata.nsamples - i-1] = dataReader.GetValue(1).ToString();
                i += 1;
            }

            dataReader.Close();
            
            return samples;
        }
    }
}