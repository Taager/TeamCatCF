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
    /// Interaction logic for OpenDeals.xaml
    /// </summary>
    public partial class OpenDeals : Page
    {
        public OpenDeals()
        {
            InitializeComponent();
            _deals.Navigate(new ViewDeals());
        }

        private void btn_CreateDeals_Click(object sender, RoutedEventArgs e)
        {
            _deals.Navigate(new CreateDeal());
        }
    }
}
