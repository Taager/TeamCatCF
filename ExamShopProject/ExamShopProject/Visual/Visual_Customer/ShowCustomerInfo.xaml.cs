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
    // Made by Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for ShowCustomerInfo.xaml
    /// </summary>
    public partial class ShowCustomerInfo : Page
    {
        Customer cusObj = new Customer();
        CustomerLogic customerLogic = new CustomerLogic();

        public ShowCustomerInfo()
        {
            InitializeComponent();
            DataContext = cusObj;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
