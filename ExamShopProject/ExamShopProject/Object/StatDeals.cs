using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    class StatDeals
    {
        private int _TotalDeals;

        public int TotalDeals //
        {
            get { return _TotalDeals; }
            set
            {
                _TotalDeals = value;
            }
        }
        private string _CustomerMostDeals;

        public string CustomerMostDeals //
        {
            get { return _CustomerMostDeals; }
            set { _CustomerMostDeals = value; }
        }
        private int _statCustomerID;

        public int statCustomerID //
        {
            get { return _statCustomerID; }
            set { _statCustomerID = value; }
        }
        private string _MostUsedDealType;

        public string MostUsedDealType //
        {
            get { return _MostUsedDealType; }
            set { _MostUsedDealType = value; }
        }
        private int _DealsActive;

        public int DealsActive //
        {
            get { return _DealsActive; }
            set
            {
                _DealsActive = value;
            }
        }
        private int _DealsInactive;

        public int DealsInactive //
        {
            get { return _DealsInactive; }
            set
            {
                _DealsInactive = value;
            }
        }
        //Helper variables
        private string _DealType;

        public string DealType
        {
            get { return _DealType; }
            set { _DealType = value; }
        }
        private long _NumberOfDealTypes;

        public long NumberOfDealTypes //
        {
            get { return _NumberOfDealTypes; }
            set { _NumberOfDealTypes = value; }
        }
        // created to order, see reference
        private int _NumberOfDeals;

        public int NumberOfDeals //
        {
            get { return _NumberOfDeals; }
            set { _NumberOfDeals = value; }
        }

    }
}
