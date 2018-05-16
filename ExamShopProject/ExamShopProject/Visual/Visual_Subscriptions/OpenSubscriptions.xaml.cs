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
    /// Interaction logic for OpenSubscriptions.xaml
    /// </summary>
    public partial class OpenSubscriptions : Page
    {
        public OpenSubscriptions()
        {
            InitializeComponent();
            _subscription.Navigate(new ViewSubscriptions());
        }

        private void btn_View_Click(object sender, RoutedEventArgs e)
        {
            _subscription.Navigate(new ViewSubscriptions());
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            _subscription.Navigate(new CreateSubscriptions());
        }
    }
}
