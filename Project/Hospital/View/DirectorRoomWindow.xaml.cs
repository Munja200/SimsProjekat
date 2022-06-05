using Controller;
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
    public class MTObservableCollection<T> : ObservableCollection<T>
    {
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler CollectionChanged = this.CollectionChanged;
            if (CollectionChanged != null)
                foreach (NotifyCollectionChangedEventHandler nh in CollectionChanged.GetInvocationList())
                {
                    DispatcherObject dispObj = nh.Target as DispatcherObject;
                    if (dispObj != null)
                    {
                        Dispatcher dispatcher = dispObj.Dispatcher;
                        if (dispatcher != null && !dispatcher.CheckAccess())
                        {
                            dispatcher.BeginInvoke(
                                (Action)(() => nh.Invoke(this,
                                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))),
                                DispatcherPriority.DataBind);
                            continue;
                        }
                    }
                    nh.Invoke(this, e);
                }
        }
    }
    public partial class DirectorRoomWindow : Window, INotifyPropertyChanged
    {
        private RoomController roomController;
        private RoomEquipmentController roomEquipmentController;
        private MTObservableCollection<Room> rooms;
        public MTObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value; OnPropertyChanged("Rooms");
            }
        }
        public DirectorRoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomController = app.roomController;
            roomEquipmentController = app.roomEquimpentController;
            rooms = roomController.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new DirectorAddRoom().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)viewRoomsWindow.dataGridRooms.SelectedItem;
            if (room != null)
            {
                roomEquipmentController.DeleteByRoomId(room.Id);
                roomController.DeleteRoom(room.Id);
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
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
            new LogIn().Show();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
