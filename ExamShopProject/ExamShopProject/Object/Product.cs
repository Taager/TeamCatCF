using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    //Made by Mikkel E.R. Glerup
    class Product
    {
        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
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
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
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
