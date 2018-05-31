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
        public bool ZipCodeValidation(int input)
        {
            if (input == 0)
                return false;
            return true;
        }
        public bool AnnualIncomeValidation(double input)
        {
            if (input == 0)
                return false;
            return true;
        }
    }
}
