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
        public EquipmentRoom(Room idr)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomEquipmenController = app.roomEquimpentController;
            roomController = app.roomController;
            roomEquipments = new ObservableCollection<RoomEquipment>();
            equipmentTransferController = app.equipmentTransferController;
            foreach (RoomEquipment re in roomEquipmenController.GetByRoomId(idr.Id)) { roomEquipments.Add(re); }

            dataGridRoomEquipment.ItemsSource = roomEquipments; 
            States = new ObservableCollection<Room>();
            foreach (Room r in roomController.GetAll()) { States.Add(r); }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<EquipmentRoom>().FirstOrDefault();
            RoomEquipment room = (RoomEquipment)viewRoomsWindow.dataGridRoomEquipment.SelectedItem;
            if (room != null)
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
                if (quanty > room.Quantity || quanty <= 0)
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    this.Close();
                    return;
                }

                if (Datum.Text.Equals(""))
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    this.Close();
                    return;
                }

                if (Odrediste.Text.Equals(""))
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    this.Close();
                    return;
                }

                DateTime dt = Convert.ToDateTime(Datum.Text);
                int ids = (int)Odrediste.SelectedValue;
                Room ro = roomController.GetById(ids);

                int idse = equipmentTransferController.GetAll().Count() == 0 ? 0 : equipmentTransferController.GetAll().Max(EquipmentTransfer => EquipmentTransfer.Id);

                if (!equipmentTransferController.Create(room.Room, ro, room.Equipment, quanty, dt, 0))
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                }
               
               
                
                this.Close();

            }
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
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
