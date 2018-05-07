using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    //lavet af Mikkel E.R. Glerup

    class Subscription
    {
        public DateTime endDate { get; set; }
        public Customer customer { get; set; }
        public int subscriptionID { get; set; }
        public bool renew { get; set; }
        public DateTime renewLength { get; set; }
    }
}
