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
        public Statistics_Customers()
        {
            List<Customer> customerList = DB.SelectAllCustomers();
            StatisticCalculations(customerList);
            InitializeComponent();
        }
        private void StatisticCalculations(List<Customer> customers)
        {
            int CustomersTotal = customers.Count;
            List<Customer> customerList = DB.SelectAllCustomers();
            List<Subscription> subscriptionList = DB.SelectAllSubscriptions();
            int CustomersWithSubTotal = subscriptionList.Count;
            int CustomersWithActiveSub;
            //noget for each snask
        }
    }
}
