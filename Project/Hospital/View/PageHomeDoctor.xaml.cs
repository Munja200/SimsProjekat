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
    /// Interaction logic for PageHomeDoctor.xaml
    /// </summary>
    public partial class PageHomeDoctor : Page
    {
        public PageHomeDoctor()
        {
            InitializeComponent();
        }
        public void ImageExaminationClick(object sender, RoutedEventArgs e)
        {
            new ShowExamination().Show();
        }

        public void ImageWeekRequestClick(object sender, RoutedEventArgs e)
        {
            new ShowWeekRequest().Show();
        }

        public void ImageSelfTermsClick(object sender, RoutedEventArgs e)
        {
            new DoctorSelfTerms().Show();
        }

        public void ImageDrugsClick(object sender, RoutedEventArgs e)
        {
            new ListDrugs().Show();
        }
    }
}
