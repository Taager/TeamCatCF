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
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class OpenCustomer : Page
    {
        public OpenCustomer()
        {
            InitializeComponent();
            _customer.Navigate(new ViewCustomer());
        }

        private void btn_ViewCustomer_Click(object sender, RoutedEventArgs e)
        {
            _customer.Navigate(new ViewCustomer());
        }

        private void btn_CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            _customer.Navigate(new CreateCustomer());
        }
    }
}
