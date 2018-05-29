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
    /// Interaction logic for ViewStatistics.xaml
    /// </summary>
    public partial class ViewStatistics : Page
    {
        public ViewStatistics()
        {
            InitializeComponent();
        }

        private void Btn_Customers_Click(object sender, RoutedEventArgs e)
        {
            Label_TopX.Opacity = 100;
            TxtBox_TopX.Opacity = 100;
            _statsFrame.Navigate(new Statistics_Customers());
        }

        private void Btn_Subscriptions_Click(object sender, RoutedEventArgs e)
        {
            Label_TopX.Opacity = 100;
            TxtBox_TopX.Opacity = 100;
            _statsFrame.Navigate(new Statistics_Subscriptions());
        }

        private void Btn_Deals_Click(object sender, RoutedEventArgs e)
        {
            Label_TopX.Opacity = 100;
            TxtBox_TopX.Opacity = 100;
            _statsFrame.Navigate(new Statistics_Deals());
        }
        private void Btn_Products_Click(object sender, RoutedEventArgs e)
        {
            Label_TopX.Opacity = 100;
            TxtBox_TopX.Opacity = 100;
            _statsFrame.Navigate(new Statistics_Products());
        }
    }
}
