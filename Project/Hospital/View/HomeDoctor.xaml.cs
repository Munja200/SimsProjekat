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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeDoctor : Window
    {
        public HomeDoctor()
        {
            InitializeComponent();
            Home.Content = new PageHomeDoctor();
            this.DataContext = this;
        }

        public void ImageMenuClick(object sender, RoutedEventArgs e)
        {
            //new MenuDoctor().Show();
            //this.Close();
            Home.Content = new PageMenuDoctor();

        }

        public void ImageNotificationClick(object sender, RoutedEventArgs e)
        {
            Home.Content = new PageNotification();

        }

        public void ImageMessageClick(object sender, RoutedEventArgs e)
        {
            Home.Content = new PageMessage();

        }

        public void ImageHomeClick(object sender, RoutedEventArgs e)
        {
            //new HomeDoctor().Show();
            //this.Close();

            Home.Content = new PageHomeDoctor();

        }

        public void ImageDoctorClick(object sender, RoutedEventArgs e)
        {
            Home.Content = new PageMyAccount();

        }

        public void ImageCalendarClick(object sender, RoutedEventArgs e)
        {

        }
        /*
        public void ImageExaminationClick(object sender, RoutedEventArgs e)
        {
            new ShowExamination().Show();
            this.Close();
        }

        public void ImageWeekRequestClick(object sender, RoutedEventArgs e)
        {
            new ShowWeekRequest().Show();
            this.Close();
        }

        public void ImageSelfTermsClick(object sender, RoutedEventArgs e)
        {
            new DoctorSelfTerms().Show();
            this.Close();
        }

        public void ImageDrugsClick(object sender, RoutedEventArgs e)
        {
            new ListDrugs().Show();
            this.Close();
        }
        */

    }
}
