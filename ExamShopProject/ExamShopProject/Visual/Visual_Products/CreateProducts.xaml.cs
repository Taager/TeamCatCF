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
    /// <summary>
    /// Interaction logic for CreateProducts.xaml
    /// </summary>
    public partial class CreateProducts : Page
    {
        Product product = new Product();
        public CreateProducts()
        {
            InitializeComponent();
            DataContext = product;
        }
    }
}
