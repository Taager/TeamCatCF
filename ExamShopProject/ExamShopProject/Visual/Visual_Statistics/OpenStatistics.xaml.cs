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

namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for OpenStatistics.xaml
    /// </summary>
    public partial class OpenStatistics : Page
    {
        public OpenStatistics()
        {
            InitializeComponent();
        }

        private void btn_CustomerStats_Click(object sender, RoutedEventArgs e)
        {
            _statistics.Navigate(new Statistics_Customers());
        }

        private void btn_DealsStats_Click(object sender, RoutedEventArgs e)
        {
            _statistics.Navigate(new Statistics_Deals());
        }

        private void btn_ProductsStat_Click(object sender, RoutedEventArgs e)
        {
            _statistics.Navigate(new Statistics_ProductCategories());
        }

        private void btn_SubscriptionsStat_Click(object sender, RoutedEventArgs e)
        {
            _statistics.Navigate(new Statistics_Subscriptions());
        }
    }
}
