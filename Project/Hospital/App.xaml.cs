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

        public ReportController reportController { get; set; }
        public ExaminationController examinationController { get; set; }
        public DrugController drugController { get; set; }


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

            ReportRepository reportRepository = new ReportRepository();
            ReportService reportService = new ReportService(reportRepository);
            reportController = new ReportController(reportService);

            ExaminationRepository examinationRepository = new ExaminationRepository();
            ExaminationService examinationService = new ExaminationService(examinationRepository);
            examinationController = new ExaminationController(examinationService);

            DrugRepository drugRepository = new DrugRepository();
            DrugService drugService = new DrugService(drugRepository);  
            drugController = new DrugController(drugService);

        }
    }
}
