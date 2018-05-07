using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ExamShopProject.Object;

namespace ExamShopProject.Customer_Interactions
{
    // Made by Helena Brunsgaard Madsen
    class Customers
    {
        Customer customer = new Customer();
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
        private string _adress;
        public string Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
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
        private double _annualIncome;
        public double AnnualIncome
        {
            get { return _annualIncome; }
            set
            {
                _annualIncome = value;
                NotifyPropertyChanged();
            }
        }

        public void CreateCustomer(string name, string adress, string contactInfo, string spokesPerson, double annualIncome)
        {
            // DB command (name, adress, contactInfo, spokesPerson)
        }
        private void EditCustomer(int IDToEdit)
        {
            // DB command(IDToEdit)
        }
        private void DeleteCustomer(int IDToDelete)
        {
            // DB command(IDToDelete)
        }
        private void ViewCustomer()
        {
            // DB command
        }
        private void ViewCustomerStat()
        {
            // Stat command
        }
        public void Log()
        {
            // Log command
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
