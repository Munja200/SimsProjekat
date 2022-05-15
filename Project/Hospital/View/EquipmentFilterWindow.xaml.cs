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
    /// <summary>
    /// Interaction logic for EquipmentFilterWindow.xaml
    /// </summary>
    public partial class EquipmentFilterWindow : Window
    {
        private RoomEquipmentController roomEquipmenController;
        private EquipmentController equipmenController;
        public ObservableCollection<RoomEquipment> roomEquipments;
        public ObservableCollection<Equipment> Equipment { get; set; }

        public EquipmentFilterWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomEquipmenController = app.roomEquimpentController;
            equipmenController = app.equipmentController;
            roomEquipments = new ObservableCollection<RoomEquipment>();
            foreach (RoomEquipment roomEquipment in roomEquipmenController.GetAll())
            { 
                roomEquipments.Add(roomEquipment); 
            }
            dataGridRoomEquipment.ItemsSource = roomEquipments;
            Equipment = new ObservableCollection<Equipment>();
            foreach (Equipment equipment in equipmenController.GetAll()) 
            { 
                Equipment.Add(equipment);
            }
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            if (idEquip.Text.Equals(""))
            {
                roomEquipments.Clear();
                foreach (RoomEquipment roomEquipment in roomEquipmenController.GetAll())
                { roomEquipments.Add(roomEquipment); }

                return;
            }
            FilteringByEquipmentId();
        }

        public void FilteringByEquipmentId() {
            int ids = (int)idEquip.SelectedValue;
            int minQuantity = 0;
            int maxQuantity = int.MaxValue;

            if (!mink.Text.Equals(""))
            {
                minQuantity = int.Parse(mink.Text);
            }

            if (!maxk.Text.Equals(""))
            {
                maxQuantity = int.Parse(maxk.Text);
            }
            roomEquipments.Clear();
            foreach (RoomEquipment roomEquipment in roomEquipmenController.GetByEquipmentIdAndQuantity(ids, minQuantity, maxQuantity))
            { roomEquipments.Add(roomEquipment); }
        }
    }
}
