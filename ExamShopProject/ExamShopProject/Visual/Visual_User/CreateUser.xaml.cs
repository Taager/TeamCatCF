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
    // Made By Helena Brunsgaard Madsen
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {
        User user = new User();
        public CreateUser()
        {
            InitializeComponent();
            DataContext = user;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
