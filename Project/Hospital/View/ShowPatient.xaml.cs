using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Controller;
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for ShowPatient.xaml
    /// </summary>
    public partial class ShowPatient : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PatientAccountController patientAccountController;
        public AppointmentController appointmentController;
        private Appointment appointment;
        public ObservableCollection<ComboItem<String>> Allergies { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public ShowPatient(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;

            appointmentController = app.appointmentController;

            Appointment = appointment;

            GetAppointmentData(appointment);
        }

        public void GetAppointmentData(Appointment appointment) 
        {

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
            //allergies.Text = appointment.PatientAccount.Allergies;
            Allergies = new ObservableCollection<ComboItem<String>>();
        }

    }
}
