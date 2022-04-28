using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for SecretaryPatientAccountWindow.xaml
    /// </summary>
    public partial class SecretaryPatientAccountWindow : Window
    {
        private PatientAccountController patientAccountController;

        public SecretaryPatientAccountWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            patientAccountController = app.patientAccountController;
            dataGridPatients.ItemsSource = patientAccountController.GetValues();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new SecretaryAddPatientAccount().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var viewPatientAccountWindow = Application.Current.Windows.OfType<SecretaryPatientAccountWindow>().FirstOrDefault();
            PatientAccount pat = (PatientAccount)viewPatientAccountWindow.dataGridPatients.SelectedItem;

            if (pat != null)
            {
                SecretaryEditPatientAccount editWindow = new SecretaryEditPatientAccount();
                editWindow.DataChanged += edit_DataChanged;
                editWindow.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var viewPatientaccountWindow = Application.Current.Windows.OfType<SecretaryPatientAccountWindow>().FirstOrDefault();
            PatientAccount patient = (PatientAccount)viewPatientaccountWindow.dataGridPatients.SelectedItem;
            if (patient != null)
                patientAccountController.DeleteById(patient.CitizenId);
        }

        private void edit_DataChanged(object sender, EventArgs e)
        {
            App app = Application.Current as App;
            patientAccountController = app.patientAccountController;
            dataGridPatients.ItemsSource = patientAccountController.GetValues();
        }
    }
}
