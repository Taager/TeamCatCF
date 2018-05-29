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
        private int _dealsID;

        public int DealsID
        {
            get { return _dealsID; }
            set
            {
                _dealsID = value;
                NotifyPropertyChanged();
            }
        }
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
        private double _priceDecrease;

        public double PriceDecrease
        {
            get { return _priceDecrease; }
            set
            {
                _priceDecrease = value;
                NotifyPropertyChanged();
            }
        }
        private string _dealType;
        public string DealType
        {
            get { return _dealType; }
            set
            {
                _dealType = value;
                NotifyPropertyChanged();
            }
        }
        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
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
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
                _categoryID = value;
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

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
