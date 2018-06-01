using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject
{
    // Made by Mikkel E. R. Glerup
    class CustomerValidation
    {
        /// <summary>
        /// Function checks if user has been entered and entered correctly
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ZipCodeValidation(int input)
        {
            if (input == 0)
                return false;
            return true;
        }
        /// <summary>
        /// Function checks if user has been entered and entered correctly
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool AnnualIncomeValidation(double input)
        {
            if (input == 0)
                return false;
            return true;
        }
    }
}
