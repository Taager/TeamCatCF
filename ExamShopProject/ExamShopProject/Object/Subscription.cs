using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    //lavet af Mikkel E.R. Glerup

    class Subscription
    {
        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                NotifyPropertyChanged();
            }
        }
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                NotifyPropertyChanged();
            }
        }
        private int _subscriptionID;
        public int SubscriptionID
        {
            get { return _subscriptionID; }
            set
            {
                _subscriptionID = value;
                NotifyPropertyChanged();
            }
        }
        private bool _renew;
        public bool Renew
        {
            get { return _renew; }
            set
            {
                _renew = value;
                NotifyPropertyChanged();
            }
        }
        private int _renewLength;

        public int RenewLength
        {
            get { return _renewLength; }
            set
            { _renewLength = value;
                NotifyPropertyChanged();
            }
        }
        private int _customerID;

        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
