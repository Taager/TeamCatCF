using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    class StatCustomer
    {
        private int _CustomersTotal;

        public int CustomersTotal
        {
            get { return _CustomersTotal; }
            set
            {
                _CustomersTotal = value;
                NotifyPropertyChanged();
            }
        }
        private int _CustomersWithSubTotal;

        public int CustomersWithSubTotal
        {
            get { return _CustomersWithSubTotal; }
            set
            {
                _CustomersWithSubTotal = value;
                NotifyPropertyChanged();
            }
        }
        private int _SubscriptionsActive;

        public int SubscriptionsActive
        {
            get { return _SubscriptionsActive; }
            set
            {
                _SubscriptionsActive = value;
                NotifyPropertyChanged();
            }
        }
        private int _SubScirptionsInactive;

        public int SubscriptionsInactive
        {
            get { return _SubScirptionsInactive; }
            set
            {
                _SubScirptionsInactive = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
