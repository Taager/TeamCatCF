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
    /// Interaction logic for Statistics_Customers.xaml
    /// </summary>
    public partial class Statistics_Customers : Page
    {
        StatCustomer statCustomer = new StatCustomer();
        public Statistics_Customers()
        {
            StatisticCalculations();
            InitializeComponent();
            DataContext = statCustomer;
            
        }
        private void StatisticCalculations()
        {
            List<Customer> customerList = DB.SelectAllCustomers();
            statCustomer.CustomersTotal = customerList.Count;
            List<Subscription> subscriptionList = DB.SelectAllSubscriptions();
            statCustomer.CustomersWithSubTotal = subscriptionList.Count;
            subscriptionList = DB.SelectActiveSubscriptions();
            statCustomer.SubscriptionsActive = subscriptionList.Count;
            subscriptionList = DB.SelectInactiveSubscriptions();
            statCustomer.SubscriptionsInactive = subscriptionList.Count;
        }
    }
}
