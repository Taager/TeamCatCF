using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.ErrorHandler
{
    #region LogInMessages
    // made by Mikkel. E.R. Glerup
    class UserLogInMessage : Exception
    {
        public UserLogInMessage() : base("User has logged in: ")
        {}
    }
    class UserLogInFail : Exception
    {
        public UserLogInFail() : base("A failed attempt at login has been made: ")
        { }
    }
    #endregion
}
