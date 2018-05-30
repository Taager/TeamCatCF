using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject
{
    // Made by Mikkel E.R. Glerup
    class GetRandomPassword
    {
        public string CreateRandomPassword()
        {
            string password = System.IO.Path.GetRandomFileName();
            CurrentUser.password = password.Replace(".", "");
            CreateMessage.ShowNewUserPassword(CurrentUser.password = CurrentUser.password.Substring(0, 8));
            return CurrentUser.password = CurrentUser.password.Substring(0, 8);
        }
    }
}
