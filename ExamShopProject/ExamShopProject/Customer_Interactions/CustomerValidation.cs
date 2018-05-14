using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject
{
    class CustomerValidation
    {
        public bool ZipCodeValidation(int input)
        {
            if (input == 0)
                return false;
            return true;
        }
        public bool AnnualIncomeValidation(float input)
        {
            if (input == 0)
                return false;
            return true;
        }
    }
}
