using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamShopProject.Object
{
    class StatProductCategory
    {
        private int _TotalProducts;

        public int TotalProducts
        {
            get { return _TotalProducts; }
            set { _TotalProducts = value; }
        }
        private int _TotalCategories;

        public int TotalCategories
        {
            get { return _TotalCategories; }
            set
            {
                _TotalCategories = value;
            }
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
        private string _LeastPopulatedCategory;

        public string LeastPopulatedCategory
        {
            get { return _LeastPopulatedCategory; }
            set { _LeastPopulatedCategory = value; }
        }
    }
}
