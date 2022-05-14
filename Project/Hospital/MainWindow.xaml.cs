using System.Windows;
using Hospital.View;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Director(object sender, RoutedEventArgs e)
        {
            new DirectorRoomWindow().Show();
            this.Close();
        }

        private void Secretary(object sender, RoutedEventArgs e)
        {

            new LogIn().Show();
            //this.Close();

        }

        private void Doctor(object sender, RoutedEventArgs e)
        {
            new DoctorOperationWindow().Show();
            this.Close();
        } 

    }
}
