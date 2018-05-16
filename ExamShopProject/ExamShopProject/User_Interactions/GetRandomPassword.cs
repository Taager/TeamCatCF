using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject
{
    class GetRandomPassword
    {
        public string CreateRandomPassword()
        {
            string password = System.IO.Path.GetRandomFileName();
            password = password.Replace(".", "");
            return password = password.Substring(0, 8);
        }
    }
}
