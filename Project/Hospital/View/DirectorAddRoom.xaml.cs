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

        private RoomController roomController;

        public DirectorAddRoom()
        {
            InitializeComponent();
            DataContext = this;

            App app = Application.Current as App;
            roomController = app.roomController;

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
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            int floor = Int32.Parse(floorR.Text);
            RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), roomTypeR.Text);
            String name = nameR.Text;
            String availability = stateR.Text;
            Room r;

            if (availability.Equals("Aktivna"))
            {
                r = new Room(0, floor, roomType, name, true);
            }
            else 
            {
                r = new Room(0, floor, roomType, name, false);
            }

            if (!roomController.CreateRoom(r.Floor, r.Name, 0, r.Availability, r.RoomType))
            {
                MessageBox.Show("Nije uspelo dodavanje","Error");
            }
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
