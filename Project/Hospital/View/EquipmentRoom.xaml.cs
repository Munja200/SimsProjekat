using Controller;
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
    public partial class EquipmentRoom : Window
    {
        private RoomEquipmentController roomEquipmenController;
        private RoomController roomController;
        private EquipmentTransferController equipmentTransferController;
        public ObservableCollection<Room> States { get; set; }
        public ObservableCollection<RoomEquipment> roomEquipments;
        public EquipmentRoom(Room room)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomEquipmenController = app.roomEquimpentController;
            roomController = app.roomController;
            equipmentTransferController = app.equipmentTransferController;
            Initialization(room);
        }
        private void Initialization(Room room) {
            roomEquipments = new ObservableCollection<RoomEquipment>();
            foreach (RoomEquipment re in roomEquipmenController.GetByRoomId(room.Id))  roomEquipments.Add(re); 
            dataGridRoomEquipment.ItemsSource = roomEquipments;
            States = new ObservableCollection<Room>();
            foreach (Room r in roomController.GetAll()) States.Add(r);

        }

        private void TransferButton(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<EquipmentRoom>().FirstOrDefault();
            RoomEquipment roomEquipment = (RoomEquipment)viewRoomsWindow.dataGridRoomEquipment.SelectedItem;
            if (roomEquipment != null)
            {
                int quanty = 0;
                try
                {
                    quanty = Int32.Parse(Kolicina.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    this.Close();
                    return;
                }
                CreateEquipmentTransfer(quanty,roomEquipment);

                this.Close();
            }
        }

        private void CreateEquipmentTransfer(int quanty,RoomEquipment roomEquipment) {
            if (quanty > roomEquipment.Quantity || quanty <= 0 || Datum.Text.Equals("") || Odrediste.Text.Equals(""))
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }

            DateTime dt = Convert.ToDateTime(Datum.Text);
            int ids = (int)Odrediste.SelectedValue;
            Room oldRoom = roomController.GetById(ids);

            if (!equipmentTransferController.Create(new EquipmentTransfer(roomEquipment.Room, oldRoom, roomEquipment.Equipment, quanty, dt, 0)))
                MessageBox.Show("Nije uspelo dodavanje", "Error");
        }
        
        private void Delete(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<EquipmentRoom>().FirstOrDefault();
            RoomEquipment room = (RoomEquipment)viewRoomsWindow.dataGridRoomEquipment.SelectedItem;
            if (room != null)
            {
                roomEquipments.Remove(room);
                roomEquipmenController.DeleteById(room.Id);
            }
        }
    }
}
