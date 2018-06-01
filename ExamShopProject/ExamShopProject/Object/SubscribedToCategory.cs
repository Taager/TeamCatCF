using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    class SubscribedToCategory
    {
        private int _subscriptionID;

        public int SubscriptionID
        {
            get { return _subscriptionID; }
            set { _subscriptionID = value; }
        }
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

    }
}
