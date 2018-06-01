using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProjectBackEnd
{
    // made by Mikkel. E.R. Glerup
    static class Log
    {
        public static void WriteFail(System.Exception ex)
        {
            DateTime currentTime = DateTime.Now;
            using (StreamWriter writer = new StreamWriter("BackedLog.txt", true))
            {
                writer.WriteLine(currentTime + Environment.NewLine + ex.Message);
                writer.WriteLine(Environment.NewLine + ex);
            }
        }
    }
}
