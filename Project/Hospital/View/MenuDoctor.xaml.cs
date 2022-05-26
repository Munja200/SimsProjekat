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
using System.Windows.Shapes;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for MenuDoctor.xaml
    /// </summary>
    public partial class MenuDoctor : Window
    {
        public MenuDoctor()
        {
            InitializeComponent();
        }
        public void HomeBackClick(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }

        public void ImageMenuClick(object sender, RoutedEventArgs e)
        {
            new MenuDoctor().Show();
            this.Close();
        }

        public void ImageHomeClick(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }

        public void ImageDoctorClick(object sender, RoutedEventArgs e)
        {

        }
        public void ImageCalendarClick(object sender, RoutedEventArgs e)
        {

        }
        public void ImageMessageClick(object sender, RoutedEventArgs e)
        {

        }
        public void ImageNotificationClick(object sender, RoutedEventArgs e)
        {

        }
        public void OperationsClick(object sender, MouseButtonEventArgs e)
        {
            new DoctorOperationWindow().Show();
            this.Close();
        }

        public void LogOutClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }


    }
}
