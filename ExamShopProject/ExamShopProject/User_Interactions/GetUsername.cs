using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject
{
    class GetUsername
    {
        Random rnd = new Random();
        public string GetRandomUsername(string name)
        {
            rnd.Next();
            if (name.Length < 3)
                name = name + GetRandomChar();
            //The above and below code is to make sure 2 letter names will be without a " " and not < 6 chars
            name = name.Replace(" ", "");
            return name = name.Substring(0, 3) + GetRandomNumber(); ;
        }
        public char GetRandomChar()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            int num = rnd.Next(0, chars.Length - 1);
            char rndChar = chars[num];
            return rndChar;
        }
        public string GetRandomNumber()
        {

            int rndNumb = rnd.Next(100, 999);
            string rndNumbString = rndNumb.ToString();
            return rndNumbString;
        }
    }
}
