using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;

namespace ExamShopProject.ErrorHandler
{
    #region LogInMessages
    // made by Mikkel. E.R. Glerup
    class UserLogInMessage : Exception
    {
        public UserLogInMessage() : base("User has logged in: ")
        { }
    }
    class UserLogInFail : Exception
    {
        public UserLogInFail() : base("A failed attempt at login has been made: ")
        { }
    }
    #endregion
    class UserWasAdded : Exception
    {
        public UserWasAdded(User user) : base($"The following user have been created: {user.Username} ")
        { }
        //public CustomerWasAdded(Customer customer) : base($"The following customer has been created: {customer.Name} ")
        //{ }
    }
    class UserWasEdited : Exception
    {
        // add current user later when login system is made
        public UserWasEdited(User user) : base($"The following user have been edited: {user.Username}")
        { }
    }
    class UserWasDeleted : Exception
    {
        public UserWasDeleted(User user) : base($"The following user have been deleted: {user.Username} ")
        { }

    }
}


