﻿using Controller;
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
    /// Interaction logic for DirectorRoomWindow.xaml
    /// </summary>
    public partial class DirectorRoomWindow : Window
    {
        private RoomController roomController;
        public DirectorRoomWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            roomController = app.roomController;
            List<Room> list = roomController.GetAll();
            ObservableCollection<Room> collection = new ObservableCollection<Room>(list);
            dataGridRooms.ItemsSource = collection;
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
                roomController.DeleteRoom(room.Id);
            
  
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            var viewRoomsWindow = Application.Current.Windows.OfType<DirectorRoomWindow>().FirstOrDefault();
            Room room = (Room)viewRoomsWindow.dataGridRooms.SelectedItem;

            if (room != null)
                new DirectorEditRoom().Show();
        }
    }
}