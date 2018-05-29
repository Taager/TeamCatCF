using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamShopProject
{
    //Made by Mikkel E.R. Glerup
    static class CreateMessage
    {
        public static void ShowCreateSuccesful(string callerClass)
        {
            MessageBox.Show($"{callerClass} was created succesfully");
        }
        public static void ShowNewUserPassword(string callerPassword)
        {
            MessageBox.Show($"The password is: {callerPassword}. Write it down, as it can't be recovered");
        }
        public static void ShowFailureMessage()
        {
            MessageBox.Show("Something went wrong, try again. If this problem persists contact admin.");
        }
        public static void ShowEditSuccesful(string callerClass)
        {
            MessageBox.Show($"{callerClass} was edited successfully.");
        }
        public static void ShowDeleteSuccesful(string callerClass)
        {
            MessageBox.Show($"{callerClass} was deleted successfully.");
        }
        public static void ShowInputNotValid()
        {
            MessageBox.Show("Information was wrong, please try again");
        }
        public static void ShowSuccesfulLogin()
        {
            MessageBox.Show("Login succesful");    
        }
        public static void ShowUnsuccesfulLogin()
        {
            MessageBox.Show("Username or Password is wrong");
        }
    }
}
