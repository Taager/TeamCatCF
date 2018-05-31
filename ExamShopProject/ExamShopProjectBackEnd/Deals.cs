using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProjectBackEnd
{
    // Made by Brian K. Petersen
    class Deals
    {
        private int _dealsID;

        public int DealsID
        {
            get { return _dealsID; }
            set
            {
                _dealsID = value;
            }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
        private double _priceDecrease;

        public double PriceDecrease
        {
            get { return _priceDecrease; }
            set
            {
                _priceDecrease = value;
            }
        }
        private string _dealType;
        public string DealType
        {
            get { return _dealType; }
            set
            {
                _dealType = value;
            }
        }
        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
            }
        }
        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
            }
        }
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
                _categoryID = value;
            }
        }
        private int _productID;

        public int ProductID
        {
            get { return _productID; }
            set
            {
                _productID = value;
            }
        }
        private int _customerID;

        public int CustomerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
            }
        }

    }
}
