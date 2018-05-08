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
    /// Interaction logic for OpenUser.xaml
    /// </summary>
    public partial class OpenUser : Page
    {
        public OpenUser()
        {
            InitializeComponent();
            _user.Navigate(new ViewUser());
        }

        private void btn_CreateUser_Click(object sender, RoutedEventArgs e)
        {
            _user.Navigate(new CreateUser());
        }

        private void btn_ViewUser_Click(object sender, RoutedEventArgs e)
        {
            _user.Navigate(new ViewUser());
        }
    }
}
