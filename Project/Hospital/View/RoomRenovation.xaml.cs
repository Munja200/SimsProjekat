using Controller;
using Model;
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
    /// Interaction logic for RoomRenovation.xaml
    /// </summary>
    public partial class RoomRenovation : Window
    {
        private AppointmentController appointmentController;
        private Room room;
        public RoomRenovation(Room room)
        {
            InitializeComponent();
            DataContext = this;

            App app = Application.Current as App;
            appointmentController = app.appointmentController;
            this.room = room;
        }
        private void AddRenovation(object sender, RoutedEventArgs e)
        {
            if (start.Text.Equals(""))
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }

            if (end.Text.Equals(""))
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }

            DateTime dt1 = Convert.ToDateTime(start.Text);
            DateTime dt2 = Convert.ToDateTime(end.Text);
         
            int ids = appointmentController.GetAll().Count() == 0 ? 0 : appointmentController.GetAll().Max(Appointment => Appointment.Id);

            if (!appointmentController.CreateRenovation(ids, dt1, dt2, 0, true, AppointmentType.renovationAppointment, null, null, room))
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }

            this.Close();

        }
    }
}
