using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject
{
    // MAde by Mikkel E. R. Glerup
    static class CurrentUser
    {
        public static int currentUserID { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string hashedPassword { get; set; }
        public static bool isAdmin { get; set; }
    }
}
