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

            new SecretaryPatientAccountWindow().Show();
            this.Close();

        }

        private void Doctor(object sender, RoutedEventArgs e)
        {
            new DoctorOperationWindow().Show();
            this.Close();
        }

        private void SelfTerms(object sender, RoutedEventArgs e)
        {
            new DoctorSelfTerms().Show();
            this.Close();
        }
        

        private void Examination(object sender, RoutedEventArgs e)
        {
            new ShowExamination().Show();
            this.Close();
        }

        private void Drugs(object sender, RoutedEventArgs e)
        {
            new ListDrugs().Show();
            this.Close();
        }
    }
}
