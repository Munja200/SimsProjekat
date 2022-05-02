using Controller;
using Hospital.Controller;
using Hospital.Repository;
using Hospital.Service;
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
        public SpecialistController specialistController { get; set; }
        public RoomController roomController { get; set; }

        public OperationController operationController { get; set; }
        public OperationTypeController operationTypeController { get; set; }
        public AppointmentController appointmentController { get; set; }

        public PatientAccountController patientAccountController { get; set; }

        public EquipmentController equipmentController { get; set; }
        //public RoomEquipmentController roomEquimpentController { get; set; }
        //public EquipmentTransferController equipmentTransferController { get; set; }



        public App()
        {
            RoomRepository roomRepository = new RoomRepository();
            PatientAccountRepository patientAccountRepository = new PatientAccountRepository();
            RoomService roomService = new RoomService(roomRepository);
            PatientAccountService patientAccountService = new PatientAccountService(patientAccountRepository);
            roomController = new RoomController(roomService);


            OperationRepository operationRepository = new OperationRepository();
            OperationService operationService = new OperationService(operationRepository);
            operationController = new OperationController(operationService);

            OperationTypeRepository operationTypeRepository = new OperationTypeRepository();
            OperationTypeService operationTypeService = new OperationTypeService(operationTypeRepository);
            operationTypeController = new OperationTypeController(operationTypeService);

            AppointmentRepository appointmentRepository = new AppointmentRepository();
            AppointmentService appointmentService = new AppointmentService(appointmentRepository);
            appointmentController = new AppointmentController(appointmentService);

            SpecialistRepository specialistRepository = new SpecialistRepository();
            SpecialistService specialistService = new SpecialistService(specialistRepository);
            specialistController = new SpecialistController(specialistService);

            patientAccountController = new PatientAccountController(patientAccountService);

            EquipmentRepository equipmentRepository = new EquipmentRepository();
        //    RoomEquipmentRepository roomEquipmentRepository = new RoomEquipmentRepository();
        //    EquipmentTransferRepository equipmentTransferRepository = new EquipmentTransferRepository();

            EquipmentService equipmentService = new EquipmentService(equipmentRepository);
        //    RoomEquipmentService roomEquipmentService = new RoomEquipmentService(roomEquipmentRepository);
        //    EquipmentTransferService equipmentTransferService = new EquipmentTransferService(equipmentTransferRepository);

            equipmentController = new EquipmentController(equipmentService);
         //   roomEquimpentController = new RoomEquipmentController(roomEquipmentService);
         //   equipmentTransferController = new EquipmentTransferController(equipmentTransferService);
          //  new Class1(roomEquipmentRepository, equipmentTransferRepository);

        }
    }
}
