using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamShopProject.Object;

namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for Statistics_Deals.xaml
    /// </summary>
    public partial class Statistics_Deals : Page
    {
        StatDeals statDeals = new StatDeals();
        public Statistics_Deals()
        {
            StatisticCalculations();
            InitializeComponent();
            DataContext = statDeals;
        }

        private void StatisticCalculations()
        {
            StatDeals tempStatDeals = new StatDeals();
            statDeals.TotalDeals = DB.SelectAllDeals().Count;
            List<StatDeals> statDealBucket = DB.SelectCustomersWithDeals();
            statDealBucket = statDealBucket.OrderBy(o => o.NumberOfDeals).ToList();
            tempStatDeals = statDealBucket[statDealBucket.Count - 1];
            Customer tempCustomer = DB.SelectCustomer(tempStatDeals.statCustomerID);
            statDeals.CustomerMostDeals = tempCustomer.Name;
            tempStatDeals = statDealBucket[0];
            statDeals.DealsActive = DB.SelectActiveDeals().Count;
            statDeals.DealsInactive = DB.SelectInactiveDeals().Count;
            statDealBucket = DB.SelectDealTypes();
            statDealBucket = statDealBucket.OrderBy(o => o.NumberOfDealTypes).ToList();
            tempStatDeals = statDealBucket[statDealBucket.Count - 1];
            statDeals.MostUsedDealType = tempStatDeals.MostUsedDealType;
        }
    }
}
