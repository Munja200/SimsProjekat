using System;
using System.Collections.Generic;
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
    /// Interaction logic for ShowPatient.xaml
    /// </summary>
    public partial class ShowPatient : Window
    {
        public PatientAccountController patientAccountController;
        public AppointmentController appointmentController;
        private Appointment appointment;
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ShowPatient(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            appointmentController = app.appointmentController;
            Appointment = appointment;

            guest.IsChecked = appointment.PatientAccount.IsGuest;
            name.Content = appointment.PatientAccount.Name;
            address.Content = appointment.PatientAccount.Address;
            surname.Content = appointment.PatientAccount.Surname;
            username.Content = appointment.PatientAccount.Username;
            citid.Content = appointment.PatientAccount.CitizenId.ToString();
            password.Content = appointment.PatientAccount.Password;
            gender.Content = appointment.PatientAccount.Gender;
            email.Content = appointment.PatientAccount.Email;
            hcid.Content = appointment.PatientAccount.HealthCardId.ToString();
            phonenumber.Content = appointment.PatientAccount.PhoneNumber;
            allergies.Content = appointment.PatientAccount.Allergies;

        }


        public Appointment Appointment 
        {
            get { return appointment; }
            set
            {
                appointment = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }
    }
}
