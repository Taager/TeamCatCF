using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    // MAde by Helena Brunsgaard Madsen
    class Deals
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        private int _priceDecrease;

        public int PriceDecrease
        {
            get { return _priceDecrease; }
            set
            {
                _priceDecrease = value;
                NotifyPropertyChanged();
            }
        }
        private int _productID;

        public int ProductID
        {
            get { return _productID; }
            set
            {
                _productID = value;
                NotifyPropertyChanged();
            }
        }
        private int _customerID;

        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                NotifyPropertyChanged();
            }
        }
        private int _percent;

        public int Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                String.Format("Value: {0:P2}.", _percent);
                NotifyPropertyChanged();
            }
        }
        private double _currency;
        public double Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
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
