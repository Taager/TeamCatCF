using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ExamShopProject.ErrorHandler
{
    class TextBoxCheck
    {
        public bool CheckTextBoxInputInteger(string textboxInput)
        {
            int parsedValue;
            if (!int.TryParse(textboxInput, out parsedValue)) //checks if the textbax contains numbers
            {
                return true;
            }
            return false;
        }
        public bool CheckTextBoxInputChars(string textboxInput)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            bool containsChars = regex.IsMatch(textboxInput); //checks if there are any chars in the textbox
            if (containsChars == true)
            {
                return true;
            }
            return false;
        }
    }
}
