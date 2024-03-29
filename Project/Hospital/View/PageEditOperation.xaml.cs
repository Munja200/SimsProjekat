﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controller;
using Hospital.Controller;
using Hospital.Model;
using Model;

namespace Hospital.View
{
    /// <summary>
    /// Interaction logic for PageEditOperationxaml.xaml
    /// </summary>
    public partial class PageEditOperation : Page
    {
        private OperationController operationController;
        private OperationTypeController operationTypeController;
        private SpecialistController specialistController;
        private AppointmentController appointmentController;
        private RoomController roomController;
        private Operation operation;

        public ObservableCollection<ComboItem<OperationType>> OperationTypes { get; set; }
        public ObservableCollection<ComboItem<Specialist>> Specialists { get; set; }
        public ObservableCollection<ComboItem<Room>> Rooms { get; set; }
        public ObservableCollection<ComboItem<Appointment>> Appointments { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Operation Operation
        {
            get { return operation; }
            set
            {
                operation = value;
                OnPropertyChanged(nameof(Operation));
            }
        }

        public PageEditOperation(Operation operation)
        {
            InitializeComponent();
            this.DataContext = this;
            App app = Application.Current as App;
            var operationW = Application.Current.Windows.OfType<DoctorOperationWindow>().FirstOrDefault();
            Operation = operation;

            durationO.Text = operation.Duration.ToString();

            GetControllers(app);

            Load();
        }

        public void GetControllers(App app)
        {
            operationController = app.operationController;
            operationTypeController = app.operationTypeController;
            specialistController = app.specialistController;
            appointmentController = app.appointmentController;
            roomController = app.roomController;
        }

        public void Load()
        {
            OperationTypes = new ObservableCollection<ComboItem<OperationType>>();
            Specialists = new ObservableCollection<ComboItem<Specialist>>();
            Rooms = new ObservableCollection<ComboItem<Room>>();
            Appointments = new ObservableCollection<ComboItem<Appointment>>();

            GetAllOperationTypes();
            GetAllSpecialists();
            GetAllRooms();
            GetAllAppointments();

        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            operationController.EditOperation(operation.Id, operation.Duration, operation.OperationType, operation.Specialist, operation.Room, operation.Appointment);
            NavigationService.GoBack();

        }

        public void GetAllOperationTypes()
        {
            foreach (OperationType operationType in operationTypeController.GetAll())
            {
                OperationTypes.Add(new ComboItem<OperationType> { Name = operationType.OperationDescription, Value = operationType });
            }
        }

        public void GetAllSpecialists()
        {
            foreach (Specialist specialist in specialistController.GetAll())
            {

                if (specialist.WorkingTime.StartTime.Hour > DateTime.Now.Hour && specialist.WorkingTime.EndTime.Hour < DateTime.Now.Hour)
                {
                    continue;
                }

                Specialists.Add(new ComboItem<Specialist> { Name = specialist.Speciality.ToString(), Value = specialist });
            }

        }

        public void GetAllRooms()
        {
            foreach (Room room in roomController.GetAll())
            {

                if (room.RoomType != RoomType.operationRoom)
                {
                    continue;
                }

                Rooms.Add(new ComboItem<Room> { Name = room.Name, Value = room });
            }

        }

        public void GetAllAppointments()
        {
            foreach (Appointment appointment in appointmentController.GetAll())
            {

                if (appointment.Scheduled)
                {
                    continue;
                }

                Appointments.Add(new ComboItem<Appointment> { Name = appointment.StartTime.ToString(), Value = appointment });
            }

        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            PageOperationDoctor page = new PageOperationDoctor();
            this.NavigationService.Navigate(page);
        }

        public void ImageBackClick(object sender, RoutedEventArgs e)
        {
            PageOperationDoctor page = new PageOperationDoctor();
            this.NavigationService.Navigate(page);
        }
    }
}
