using Controller;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public RoomController roomController { get; set; }
        public PatientAccountController patientAccountController { get; set; }

        public App()
        {
            RoomRepository roomRepository = new RoomRepository();
            PatientAccountRepository patientAccountRepository = new PatientAccountRepository();
            RoomService roomService = new RoomService(roomRepository);
            PatientAccountService patientAccountService = new PatientAccountService(patientAccountRepository);
            roomController = new RoomController(roomService);
            patientAccountController = new PatientAccountController(patientAccountService);
        }
    }
}
