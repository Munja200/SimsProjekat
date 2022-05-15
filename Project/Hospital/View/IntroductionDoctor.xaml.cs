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
    /// Interaction logic for Introduction.xaml
    /// </summary>
    public partial class IntroductionDoctor : Window
    {
        public IntroductionDoctor()
        {
            InitializeComponent();
        }

        public void ImageBackClick(object sender, RoutedEventArgs e) 
        {
            new LogIn().Show();
            this.Close();
        }

        public void StartClick(object sender, RoutedEventArgs e)
        {
            new HomeDoctor().Show();
            this.Close();
        }
    }
}
