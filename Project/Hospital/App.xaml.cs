using Controller;
using Hospital.Controller;
using Hospital.Repository;
using Hospital.Service;
using Model;
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


        public ReportController reportController { get; set; }
        public ExaminationController examinationController { get; set; }
        public DrugController drugController { get; set; }

        public EquipmentController equipmentController { get; set; }
        public RoomEquipmentController roomEquimpentController { get; set; }
        public EquipmentTransferController equipmentTransferController { get; set; }
        public WeekRequestController weekRequestController { get; set; }

        public InstructionsController instructionsController { get; set; }
        
        public LogInController logInController { get; set; }
        public Employee Employee { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int i { get; set; }


        public App()
        {
            RoomRepository roomRepository = new RoomRepository();
            PatientAccountRepository patientAccountRepository = new PatientAccountRepository();
            RoomService roomService = new RoomService(roomRepository);
            PatientAccountService patientAccountService = new PatientAccountService(patientAccountRepository);
            roomController = new RoomController(roomService);
            i = 0;

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


            ReportRepository reportRepository = new ReportRepository();
            ReportService reportService = new ReportService(reportRepository);
            reportController = new ReportController(reportService);

            ExaminationRepository examinationRepository = new ExaminationRepository();
            ExaminationService examinationService = new ExaminationService(examinationRepository);
            examinationController = new ExaminationController(examinationService);

            DrugRepository drugRepository = new DrugRepository();
            DrugService drugService = new DrugService(drugRepository);  
            drugController = new DrugController(drugService);

            EquipmentRepository equipmentRepository = new EquipmentRepository();
            RoomEquipmentRepository roomEquipmentRepository = new RoomEquipmentRepository();
            EquipmentTransferRepository equipmentTransferRepository = new EquipmentTransferRepository();

            EquipmentService equipmentService = new EquipmentService(equipmentRepository);
            RoomEquipmentService roomEquipmentService = new RoomEquipmentService(roomEquipmentRepository);
            EquipmentTransferService equipmentTransferService = new EquipmentTransferService(equipmentTransferRepository, roomEquipmentRepository);

            equipmentController = new EquipmentController(equipmentService);
            roomEquimpentController = new RoomEquipmentController(roomEquipmentService);
            equipmentTransferController = new EquipmentTransferController(equipmentTransferService);
            new ThreadEquipmentService(roomEquipmentRepository, equipmentTransferRepository);

            InstructionsRepository instructionsRepository = new InstructionsRepository();
            InstructionsService instructionsService = new InstructionsService(instructionsRepository);
            instructionsController = new InstructionsController(instructionsService);

            WeekRequestRepository weekRequestRepository = new WeekRequestRepository();
            WeekRequestService weekRequestService = new WeekRequestService(weekRequestRepository);
            weekRequestController = new WeekRequestController(weekRequestService);

            LogInRepository logInRepository = new LogInRepository();
            LogInService logInService = new LogInService(logInRepository);
            logInController = new LogInController(logInService);


        }
    }
}
