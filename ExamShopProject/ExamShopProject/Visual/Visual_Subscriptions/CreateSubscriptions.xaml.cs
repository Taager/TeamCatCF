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
    /// Interaction logic for CreateSubscriptions.xaml
    /// </summary>
    public partial class CreateSubscriptions : Page
    {
        public CreateSubscriptions()
        {
            InitializeComponent();
            lstbx_Customer.ItemsSource = DB.SelectAllCustomers();
            lstbx_Customer.DisplayMemberPath = "Name";
            lstbx_Categories.ItemsSource = DB.SelectAllCategories();
            lstbx_Categories.DisplayMemberPath = "Name";
        }
    }
}
