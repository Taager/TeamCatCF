using System;
//using ExamShopProject.ErrorHandler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;
using System.Data;

namespace ExamShopProjectBackEnd
{
    // made by Brian K. Petersen
    static class DB
    {
        #region open and close connection
        //made by Mikkel. E.R. Glerup
        public static SqlConnection myConnection;
        private static bool OpenConnection()
        {
            try
            {
                myConnection = new SqlConnection(
                    "Data Source=.;Initial Catalog=Charlie-APE;Integrated Security=True"
                    );
                myConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                //Log.WriteFail(ex);
                return false;
            }
        }
        private static bool CloseConnection()
        {
            try
            {
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log.WriteFail(ex);
                return false;
            }
        }
        #endregion

        #region import/export catalogue
        public static bool ImportCatalogue(string fileName)
        {
            if (File.Exists(fileName))
            {
                OpenConnection();
                /*SqlCommand getUser = new SqlCommand(
                    "SELECT Price FROM [TempProductCatalogue]", myConnection);
                SqlDataReader reader = getUser.ExecuteReader();
                while (reader.Read())
                {
                    string dbPrice = reader.GetString(0);
                    float price = float.Parse(dbPrice);
                }*/
                SqlCommand import = new SqlCommand("BULK INSERT [Product] FROM '"+ @"C:\Users\8570W\ApEngros_PriCat_23042018.csv" + "' WITH(CODEPAGE = '1252', FIRSTROW = 2, ROWTERMINATOR = '0x0a', FIELDTERMINATOR = ';'); ", myConnection);
                import.Parameters.Add("@File", SqlDbType.Text);
                import.Parameters["@File"].Value = @"C:\Users\8570W\source\repos\TeamCatCF\ExamShopProject\ExamShopProjectBackEnd\bin\Debug\ApEngros_PriCat_23042018.csv";
                //import.Parameters["@File"].Value = fileName;
                import.ExecuteNonQuery();
                CloseConnection();

                
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
