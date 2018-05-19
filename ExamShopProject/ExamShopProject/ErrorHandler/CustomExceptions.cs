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
    #region User
    // Made by Mikkel Glerup
    class UserWasAdded : Exception
    {
        public UserWasAdded(User user) : base($"The following user have been created: {user.Username} ")
        { }
    }
    class UserWasEdited : Exception
    {
        // add current user later when login system is made
        public UserWasEdited(User user) : base($"The following user have been edited: {user.Username}")
        { }
    }
    // Made by Mikkel Glerup
    class UserWasDeleted : Exception
    {
        public UserWasDeleted(User user) : base($"The following user have been deleted: {user.Username} ")
        { }
    }
    #endregion
    #region Customer
    class CustomerWasAdded : Exception
    {
        public CustomerWasAdded(Customer customer) : base($"The following customer has been created: {customer.Name} ")
        { }
    }
    class CustomerWasDeleted : Exception
    {
        public CustomerWasDeleted(Customer customer) : base($"The following customer have been deleted: {customer.Name} ")
        { }
    }
    // Made by Helena Brunsgaard Madsen
    class CustomerWasEdited : Exception
    {
        // add current user later when login system is made
        public CustomerWasEdited(Customer customer) : base($"The following customer have been edited: {customer.Name}")
        { }
    }
    #endregion
    #region Product
    class ProductWasAdded : Exception
    {
        // add current user later when login system is made
        public ProductWasAdded(Product product) : base($"The following Product have been added: {product.Name}")
        { }
    }
    // Made by Helena Brunsgaard Madsen
    class ProductWasEdited : Exception
    {
        // add current user later when login system is made
        public ProductWasEdited(Product product) : base($"The following customer have been edited: {product.Name}")
        { }
    }
    // Made by Helena Brunsgaard Madsen
    class ProductWasDeleted : Exception
    {
        public ProductWasDeleted(Product product) : base($"The following customer have been deleted: {product.Name} ")
        { }
    }
    #endregion
    #region Subscription
    //Made by Mikkel E.R. Glerup

    class SubscriptionWasAdded : Exception
    {
        public SubscriptionWasAdded(Subscription subscription) : base($"{subscription.CustomerName}'s subscription have been created by: PLACEHOLDER ")
        { }
    }
    class SubscriptionWasEdited : Exception
    {
        // add current user later when login system is made
        public SubscriptionWasEdited(Subscription subscription) : base($"{subscription.CustomerName}'s subscription have been edited by: PLACEHOLDER")
        { }
    }
    // Made by Mikkel Glerup
    class SubscriptionWasDeleted : Exception
    {
        public SubscriptionWasDeleted(Subscription subscription) : base($"{subscription.CustomerName}'s subscription have been deleted by: PLACEHOLDER ")
        { }
    }
    #endregion

}


