using Controller;
using Hospital.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for SecretaryAddPatientAccount.xaml
    /// </summary>
    public partial class SecretaryEditPatientAccount : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> Gender { get; set; }

        private PatientAccountController patientAccountController;

        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public event DataChangedEventHandler DataChanged;
        public SecretaryEditPatientAccount()
        {
            InitializeComponent();
            this.DataContext = this;

            App app = Application.Current as App;
            patientAccountController = app.patientAccountController;
            var patientW = Application.Current.Windows.OfType<SecretaryPatientAccountWindow>().FirstOrDefault();
            PatientAccount patient = (PatientAccount)patientW.dataGridPatients.SelectedItem;

            Gender = new ObservableCollection<string>();
            Gender.Add("M");
            Gender.Add("Ž");
            
            name.Text = patient.Name;
            surname.Text = patient.Surname;
            jmbg.Text = patient.CitizenId.ToString();
            dateOfBirth.Text = patient.DateOfBirth.ToLongDateString();
            email.Text = patient.Email;
            phoneNumber.Text = patient.PhoneNumber;
            ulica.Text = patient.Address.StreetName;
            brZgrade.Text = patient.Address.Number;
            grad.Text = patient.Address.city.name;
            drzava.Text = patient.Address.city.country.name;
            username.Text = patient.Username;
            password.Text = patient.Password;
            healthCardId.Text = patient.HealthCardId.ToString();
            if (patient.Gender.Equals(Model.Gender.male))
            {
                gender.SelectedValue = "M";
            }
            else
            {
                gender.SelectedValue = "Ž";
            }
        
            guest.IsChecked = patient.IsGuest;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DataChangedEventHandler handler = DataChanged;

            var patientW = Application.Current.Windows.OfType<SecretaryPatientAccountWindow>().FirstOrDefault();
            PatientAccount patient = (PatientAccount)patientW.dataGridPatients.SelectedItem;

            patient.Name = name.Text;
            patient.Surname = surname.Text;
            patient.CitizenId = Int32.Parse(jmbg.Text);
            patient.DateOfBirth = DateTime.Parse(dateOfBirth.Text);
            patient.Email = email.Text;
            patient.PhoneNumber = phoneNumber.Text;
            patient.Address.StreetName = ulica.Text;
            patient.Address.Number = brZgrade.Text;
            patient.Address.city.name = grad.Text;
            patient.Address.city.country.name = drzava.Text;
            patient.Username = username.Text;
            patient.Password = password.Text;
            patient.HealthCardId = int.Parse(healthCardId.Text);
            if (gender.Text.Equals("M"))
            {
                patient.Gender = Model.Gender.male;
            }
            else
            {
                patient.Gender = Model.Gender.female;
            }
       
            if ((bool)guest.IsChecked)
            {
                patient.IsGuest = true;
            }
            else
            {
                patient.IsGuest = false;
            }
            if (!patientAccountController.Update(patient.Name, patient.Surname, patient.CitizenId, patient.DateOfBirth, 
                patient.Email, patient.PhoneNumber, patient.Username, patient.Password, patient.IsGuest, 
                patient.HealthCardId, null, patient.Address, patient.Gender))
            {
                MessageBox.Show("Nije uspela izmena", "Error");
            }
            handler(this, new EventArgs());
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
