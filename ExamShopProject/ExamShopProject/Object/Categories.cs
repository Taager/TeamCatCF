using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    // Madse by Helena Brunsgaard Madsen
    class Categories
    {
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private long _amountOfProducts;
        public long AmountOfProducts
        {
            get { return _amountOfProducts; }
            set { _amountOfProducts = value; }
        }
        private string _MostPopulatedCategory;
        public string MostPopulatedCategory
        {
            get { return _MostPopulatedCategory; }
            set
            {
                _MostPopulatedCategory = value;
            }
        }
        private int _TotalProducts;

        public int TotalProducts
        {
            get { return _TotalProducts; }
            set { _TotalProducts = value; }
        }
    }
}
