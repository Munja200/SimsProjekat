using Controller;
using Hospital.Controller;
using Hospital.Model;
using Model;
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

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for RoomRenovation.xaml
    /// </summary>
    public partial class RoomRenovation : Window
    {
        private AppointmentController appointmentController;
        private RenovationController renovationController;
        private RoomController roomController;
        private Room room;
        public ObservableCollection<Room> Rooms { get; set; }
        public RoomRenovation(Room room)
        {
            InitializeComponent();
            DataContext = this;

            App app = Application.Current as App;
            appointmentController = app.appointmentController;
            this.renovationController = app.renovationController;
            this.roomController = app.roomController;
            this.room = room;

            Rooms = new ObservableCollection<Room>();
            foreach (Room newRoom in roomController.GetAllByFloor(room.Floor)) { Rooms.Add(newRoom); }
            Rooms.Remove(room);
        }
        private void AddRenovation(object sender, RoutedEventArgs e)
        {
            if (start.Text.Equals("") || end.Text.Equals(""))
            {
                MessageBox.Show("Unesite ispravno datume", "Error");
                return;
            }
                                   
            int id = appointmentController.GetAll().Count() == 0 ? 0 : appointmentController.GetAll().Max(Appointment => Appointment.Id);

            if (!appointmentController.CreateRenovation(++id, Convert.ToDateTime(start.Text), Convert.ToDateTime(end.Text), 0, true, AppointmentType.renovationAppointment, null, null, room))
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }
            CreateRenovationType(id);

            this.Close();

        }

        public void CreateRenovationType(int id) {
            if (OneRoom.IsChecked == true)
            {
                renovationController.Create(new Renovation(null, new Appointment(id, Convert.ToDateTime(start.Text), Convert.ToDateTime(end.Text), 0, true, AppointmentType.renovationAppointment, null, room, null), RenovationType.Sharing));
            }
            else if (TwoRoom.IsChecked == true)
            {
                if (SecondRoom.Text.Equals(""))
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    return;
                }
                if (!renovationController.Create(new Renovation(roomController.GetById((int)SecondRoom.SelectedValue), new Appointment(id, Convert.ToDateTime(start.Text), Convert.ToDateTime(end.Text), 0, true, AppointmentType.renovationAppointment, null, room, null), RenovationType.Merger)))
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    return;
                }
            }
            else
            {
                renovationController.Create(new Renovation(null, new Appointment(id, Convert.ToDateTime(start.Text), Convert.ToDateTime(end.Text), 0, true, AppointmentType.renovationAppointment, null, room, null), RenovationType.Repair));
            }
        }
    }
}
