using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    class Product
    {
        public int price { get; set; }
        public int ID { get; set; }
        public string name { get; set; }
        //public enum category { get; set; }
        //We need to fill in categories for the enum
        public string description { get; set; }
    }
}
