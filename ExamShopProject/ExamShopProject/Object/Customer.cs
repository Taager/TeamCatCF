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

    class Customer
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
        private string _streetAndNumber;
        public string StreetAndNumber
        {
            get { return _streetAndNumber; }
            set
            {
                _streetAndNumber = value;
                NotifyPropertyChanged();
            }
        }
        private int _zipCode;
        public int ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                NotifyPropertyChanged();
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyPropertyChanged();
            }
        }
        private string _contactInfo;
        public string ContactInfo
        {
            get { return _contactInfo; }
            set
            {
                _contactInfo = value;
                NotifyPropertyChanged();
            }
        }
        private string _spokesPeron;
        public string SpokesPerson
        {
            get { return _spokesPeron; }
            set
            {
                _spokesPeron = value;
                NotifyPropertyChanged();
            }
        }
        private float _annualIncome;
        public float AnnualIncome
        {
            get { return _annualIncome; }
            set
            {
                _annualIncome = value;
                NotifyPropertyChanged();
            }
        }
        public int  customerID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
