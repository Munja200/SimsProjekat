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
       // private EquipmentTransferController equipmentTransferController;
        public ObservableCollection<Room> States { get; set; }
        public EquipmentRoom(Room idr)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomEquipmenController = app.roomEquimpentController;
            roomController = app.roomController;
//            equipmentTransferController = app.equipmentTransferController;

            dataGridRoomEquipment.ItemsSource = roomEquipmenController.GetByRoomId(idr.Id);
            States = new ObservableCollection<Room>();
            foreach (Room r in roomController.GetAll()) { States.Add(r); }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<EquipmentRoom>().FirstOrDefault();
            RoomEquipment room = (RoomEquipment)viewRoomsWindow.dataGridRoomEquipment.SelectedItem;
            if (room != null)
            {
                int kolicina = 0;
                try
                {
                    kolicina = Int32.Parse(Kolicina.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                    this.Close();
                    return;
                }
                if (kolicina > room.Quantity || kolicina <= 0)
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
            /*    if (!equipmentTransferController.Create(room.Room, ro, room.Equipment, kolicina, dt, 0))
                {
                    MessageBox.Show("Nije uspelo dodavanje", "Error");
                }
                
                if (DateTime.Compare(dt, DateTime.Today) == 0) 
                {
                    roomEquipmenController.MoveEquipment(new EquipmentTransfer(room.Room, ro, room.Equipment, kolicina, dt, 0));
                }
                */
                this.Close();

            }
        }

    }
}
