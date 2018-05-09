using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;

namespace ExamShopProject.ErrorHandler
{
    static class Log
    {
        // made by Mikkel. E.R. Glerup
        public static void WriteFail(System.Exception ex)
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine(currentTime + Environment.NewLine + ex.Message);
                writer.WriteLine( Environment.NewLine + ex);
            }
        }
        public static void WritEvent(System.Exception ex)
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter("Events.txt", true))
            {
                writer.WriteLine(currentTime + Environment.NewLine + ex.Message);
            }
        }
    }
}
