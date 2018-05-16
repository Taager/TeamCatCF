using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.ErrorHandler;

namespace ExamShopProject
{
    class DBOpenClose
    {
        //made by Mikkel. E.R. Glerup
        public static SqlConnection myConnection;
        public static bool OpenConnection()
        {
            try
            {
                myConnection = new SqlConnection(
                    "Data Source=.;Initial Catalog=Charlie-APE;Integrated Security=True"
                    );
                // skal tilgåes fra properties
                myConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
        }
        //Made by Mikkel E.R. Glerup
        public static bool CloseConnection()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteFail(ex);
                return false;
            }
        }
    }
}
