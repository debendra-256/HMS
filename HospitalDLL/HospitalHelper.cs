using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HMSMODEL;

namespace HospitalDLL
{
    public class HospitalHelper
    {

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter ad;
        public static SqlConnection connect()
        {
           
            string myconnection = ConfigurationManager.ConnectionStrings["connectHMS"].ToString();
            SqlConnection connection = new SqlConnection(myconnection);
            if(connection.State==ConnectionState.Open)
            {
                connection.Close();
            }
            else
            {
                connection.Open();
            }
            return connection;
        

        }

        public DataTable getData( string str)
        {
            ad = new SqlDataAdapter(str, HospitalHelper.connect());
            dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public bool DML(SqlCommand cmd)
        {

            using (connect())
            {
                
                using (cmd)
                {
                    cmd.Connection = connect();
                   
                    cmd.ExecuteScalar();
                    
                }
            }

            return true;

        }



        public DataTable GetALL(SqlCommand cmd)
        {
            ad = new SqlDataAdapter();
            DataTable dt = new DataTable();

            using (connect())
            {

                using (cmd)
                {
                    cmd.Connection = connect();
                    ad.SelectCommand = cmd;

                    ad.Fill(dt);

                }
            }

            return dt;

            
          
        }





    }
}
