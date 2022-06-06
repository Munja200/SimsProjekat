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
    /// Interaction logic for DirectorAddRoom.xaml
    /// </summary>
    public partial class DirectorAddRoom : Window
    {

        public ObservableCollection<string> RoomT { get; set; }
        public ObservableCollection<string> State { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private RoomController roomController;

        public DirectorAddRoom()
        {
            InitializeComponent();
            DataContext = this;

            App app = Application.Current as App;
            roomController = app.roomController;

            Initialization();
        }

        private void Initialization() {
            RoomT = new ObservableCollection<string>();
            RoomT.Add("office");
            RoomT.Add("operationRoom");
            RoomT.Add("emergencyRoom");
            RoomT.Add("appointmentRoom");
            RoomT.Add("sickroom");
            RoomT.Add("storage");

            State = new ObservableCollection<string>();
            State.Add("Aktivna");
            State.Add("Neaktivna");

            roomTypeR.SelectedValue = "office";
            nameR.Text = "";
            floorR.Text = "";
            stateR.SelectedValue = "Aktivna";
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            int floor;
            try
            {
                floor = Int32.Parse(floorR.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }

            RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), roomTypeR.Text);
            Room room;

            if (!floorR.Text.Equals("") && !nameR.Text.Equals(""))
            {
                if (stateR.Text.Equals("Aktivna"))
                    room = new Room(0, floor, roomType, nameR.Text, true);
                else                
                    room = new Room(0, floor, roomType, nameR.Text, false);
                
                if (!roomController.CreateRoom(new Room(0, room.Floor, room.RoomType, room.Name, room.Availability)))
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                
                this.Close();
                return;
            }
            MessageBox.Show("Nije uspelo dodavanje", "Error");
            this.Close();
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
