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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for PageMenuDoctor.xaml
    /// </summary>
    public partial class PageMenuDoctor : Page
    {
        public PageMenuDoctor()
        {
            InitializeComponent();
        }
        public void HomeBackClick(object sender, RoutedEventArgs e)
        {
            PageHomeDoctor page = new PageHomeDoctor();
            this.NavigationService.Navigate(page);
        }

        public void OperationsClick(object sender, MouseButtonEventArgs e)
        {
            PageOperationDoctor page = new PageOperationDoctor();
            this.NavigationService.Navigate(page);
            //new DoctorOperationWindow().Show();
        }

        public void LogOutClick(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();

        }
    }
}
