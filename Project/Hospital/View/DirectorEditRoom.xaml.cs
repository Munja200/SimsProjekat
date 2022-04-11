using Controller;
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
    /// Interaction logic for DirectorEditRoom.xaml
    /// </summary>
    public partial class DirectorEditRoom : Window
    {
        private RoomController roomController;
        public ObservableCollection<string> RoomT { get; set; }
        public ObservableCollection<string> State { get; set; }


        public DirectorEditRoom()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomController = app.roomController;
            var roomW = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)roomW.dataGridRooms.SelectedItem;

            floorR.Text = room.Floor.ToString();
            nameR.Text = room.Name;
            RoomT = new ObservableCollection<string>();
            RoomT.Add(" office");
            RoomT.Add("operationRoom");
            RoomT.Add("emergencyRoom");
            RoomT.Add("appointmentRoom");
            RoomT.Add("sickroom");
            RoomT.Add("storage");
            State = new ObservableCollection<string>();
            State.Add("Aktivna");
            State.Add("Neaktivna");

            roomTypeR.SelectedValue = room.RoomType.ToString();


            if (room.Availability == true)
                stateR.SelectedValue = "Aktivna";
            else
                stateR.SelectedValue = "Neaktivna";
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            var roomW = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)roomW.dataGridRooms.SelectedItem;

            room.Floor = Int32.Parse(floorR.Text);
            room.RoomType = (RoomType)Enum.Parse(typeof(RoomType), roomTypeR.Text);
            room.Name = nameR.Text;
            String availability = stateR.Text;

            if (availability.Equals("Aktivna"))
            {
                room.Availability = true;
            }
            else
            {
                room.Availability = false;
            }

            if (!roomController.EditRoom(room.Floor, room.Name, room.Id, room.Availability, room.RoomType))
            {
                MessageBox.Show("Nije uspela izmena", "Error");
            }
            this.Close();


        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
