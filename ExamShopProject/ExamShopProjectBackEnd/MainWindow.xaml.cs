using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ExamShopProjectBackEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var renewThread = new Thread(DB.RenewSubscriptions); // start the thread responsible for renewing subscriptions
            renewThread.Start();

            var importThread = new Thread(FileManager.FetchFile); // start the thread responsible for importing and exporting product catalogues
            importThread.Start();
        }
    }
}
