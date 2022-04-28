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
using Controller;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for SecretaryAddPatientAccount.xaml
    /// </summary>
    public partial class SecretaryAddPatientAccount : Window
    {
        public ObservableCollection<string> Gender { get; set; }

        private PatientAccountController patientAccountController;
        public SecretaryAddPatientAccount()
        {
            InitializeComponent();
            DataContext = this;

            App app = Application.Current as App;
            patientAccountController = app.patientAccountController;

            Gender = new ObservableCollection<string>();
            Gender.Add("M");
            Gender.Add("Ž");
            
            name.Text = "";
            surname.Text = "";
            jmbg.Text = "";
            dateOfBirth.Text = "";
            email.Text = "";
            phoneNumber.Text = "";
            ulica.Text = "";
            brZgrade.Text = "";
            grad.Text = "";
            drzava.Text = "";
            username.Text = "";
            password.Text = "";
            healthCardId.Text = "";
            gender.SelectedValue = "M";
            guest.IsChecked = false;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            String nameM = name.Text;
            String surnameM = surname.Text;
            int jmbgM = Int32.Parse(jmbg.Text);
            DateTime dateOfBirthM = DateTime.Parse(dateOfBirth.Text);
            String emailM = email.Text;
            String phoneNumberM = phoneNumber.Text;
            String nameStreet = ulica.Text;
            String numberBuilding = brZgrade.Text;
            String nameCity = grad.Text;
            String nameCountry = drzava.Text;
            String usernameM = username.Text;
            String passwordM = password.Text;
            int healthCardIdM = Int32.Parse(healthCardId.Text);
            Gender genderM;

            if (gender.Text.Equals("M"))
            {
                genderM = Model.Gender.male;
            }
            else
            {
                genderM = Model.Gender.female;
            }

            bool guestM;
            if ((bool)guest.IsChecked)
            {
                guestM = true;
            }
            else
            {
                guestM = false;
            }
            Country country = new Country(nameCountry);
            City city = new City(nameCity, country);
            Address address = new Address(nameStreet, numberBuilding, city);
            PatientAccount pat;
            pat = new PatientAccount(nameM, surnameM, jmbgM, genderM, dateOfBirthM, emailM, phoneNumberM, address, usernameM, passwordM, guestM, healthCardIdM, null);
            patientAccountController.Create(nameM, surnameM, jmbgM, dateOfBirthM, emailM, phoneNumberM, usernameM, passwordM, guestM, healthCardIdM, null, address, genderM);
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
