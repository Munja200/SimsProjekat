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
    public partial class DirectorAddEquipment : Window
    {
        private EquipmentController equipmentController;
        private RoomController roomController;
        private RoomEquipmentController roomEquipmentController;
        public ObservableCollection<int> IDR { get; set; }

        public DirectorAddEquipment()
        {
            InitializeComponent();
            DataContext = this;

            App app = Application.Current as App;
            equipmentController = app.equipmentController;
            roomController = app.roomController;
            roomEquipmentController = app.roomEquimpentController;
            IDR = new ObservableCollection<int>();

            foreach (Room r in roomController.GetAll())
            {
                IDR.Add(r.Id);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            int quantity;
            try
            {
                quantity = Int32.Parse(quant.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }
            CreateEquipment(quantity);
         
            this.Close();
        }
        private void CreateEquipment(int quantity) {
            if (!equipmentController.Create(new Equipment(0, name.Text, mname.Text, quantity, descript.Text)))
            {
                MessageBox.Show("Nije uspelo dodavanje", "Error");
                this.Close();
                return;
            }
            Room rooom = roomController.GetById(Int32.Parse(room.Text));
            roomEquipmentController.Create(new RoomEquipment(rooom, equipmentController.GetByName(name.Text), quantity, 0));
        }
    }
}
