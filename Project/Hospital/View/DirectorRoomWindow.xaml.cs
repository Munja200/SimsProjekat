using Controller;
using Hospital.Util;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using System.Windows.Threading;

namespace Hospital.View
{
    public partial class DirectorRoomWindow : Window, INotifyPropertyChanged
    {
        private RoomController roomController;
        private RoomEquipmentController roomEquipmentController;
        private MTObservableCollection<Room> rooms;
        public event PropertyChangedEventHandler PropertyChanged;

        public DirectorRoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomController = app.roomController;
            roomEquipmentController = app.roomEquimpentController;
            rooms = roomController.GetAll();
        }
        public MTObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value; OnPropertyChanged("Rooms");
            }
        }

        private void AddRoom(object sender, RoutedEventArgs e)
        {
            new DirectorAddRoom().Show();
        }

        private void DeleteRoom(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)viewRoomsWindow.dataGridRooms.SelectedItem;
            if (room != null)
            {
                roomEquipmentController.DeleteByRoomId(room.Id);
                roomController.DeleteRoom(room.Id);
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)viewRoomsWindow.dataGridRooms.SelectedItem;

            if (room != null)
                new DirectorEditRoom().Show();
        }
        private void Equipment(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)viewRoomsWindow.dataGridRooms.SelectedItem;
            if (room != null)
                new EquipmentRoom(room).Show();
        }

        private void AddEquipment(object sender, RoutedEventArgs e)
        {
            new DirectorAddEquipment().Show();
        }

        private void Renovation(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)viewRoomsWindow.dataGridRooms.SelectedItem;

            if (room != null)
                new RoomRenovation(room).Show();
        }

        private void ClickLogOut(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void EquipmentFilter(object sender, RoutedEventArgs e) 
        {
            new EquipmentFilterWindow().Show();   
        }


        private void DrugReview(object sender, RoutedEventArgs e)
        {
            new DrugReview().Show();
        }

        private void AddDrug(object sender, RoutedEventArgs e)
        {
            new AddDrug().Show();
        }
        private void InvalidDeugsRewiew(object sender, RoutedEventArgs e)
        {
            new DefectiveDrugWindow().Show();
        }

        private void GradesRewiew(object sender, RoutedEventArgs e)
        {
            new GradesWindow().Show();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
