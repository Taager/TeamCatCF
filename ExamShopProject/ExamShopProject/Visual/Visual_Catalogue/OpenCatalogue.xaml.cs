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
    // Made by Mikkel E.R. Glerup
    /// <summary>
    /// Interaction logic for OpenCatalogue.xaml
    /// </summary>
    public partial class OpenCatalogue : Page
    {
        public OpenCatalogue()
        {
            InitializeComponent();
            _catalogue.Navigate(new ViewCatalogue());
        }
    }
}
