using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.ErrorHandler
{
    static class Log
    {
        // made by Mikkel. E.R. Glerup
        public static void WriteFail()
        {
            DateTime currentTime = DateTime.Now;
            string path = @"C:\Users\Fluffy\source\repos\AP-EngrossBETA\MyTest";
            if (!File.Exists(path))
            {

                string createText = "Test" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            string appendText = "Test Exeption" + currentTime.ToString() + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }
    }
}
