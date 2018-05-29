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
using ExamShopProject.ErrorHandler;
using ExamShopProject.User_Interactions;
using System.Xaml;
using System.IO;


namespace ExamShopProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void btn_User_Click(object sender, RoutedEventArgs e) //=> _mainFrame.Navigate(new OpenUser()); overvej, om dette er bedre.
        {
            _mainFrame.Navigate(new OpenUser());
        }
        private void btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenCustomer());
        }

        private void btn_Subscriptions_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenSubscriptions());
        }

        private void btn_Statistics_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenStatistics());
        }

        private void btn_Catalogue_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenCatalogue());
        }

        private void btn_Deals_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenDeals());
        }

        private void btn_LogIn_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new LogIn());
        }

        private void btn_Products_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new OpenProducts());
        }
    }
}
