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
    /// Interaction logic for DoctorSelfTerms.xaml
    /// </summary>
    public partial class DoctorSelfTerms : Window
    {
        private AppointmentController appointmentController;
        public DoctorSelfTerms()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;

            appointmentController = app.appointmentController;

            Load();
        }

        public void Load()
        {
            List<Appointment> list = appointmentController.GetAll();
            ObservableCollection<Appointment> collection = new ObservableCollection<Appointment>(list);
            dataGridSelfTerms.ItemsSource = collection;
        }

        private void Show_Patient(object sender, RoutedEventArgs e)
        {
            var viewSelfTermsWindow = Application.Current.Windows.OfType<DoctorSelfTerms>().FirstOrDefault();
            Appointment appointment = (Appointment)viewSelfTermsWindow.dataGridSelfTerms.SelectedItem;

            if (appointment != null)
                new ShowPatient(appointment).ShowDialog();

        }
    }
}
