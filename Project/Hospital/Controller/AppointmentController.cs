using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
    public class AppointmentController
    {
        public List<Appointment> appointments;

        public Service.AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType,
            Doctor doctor, Room room, PatientAccount patientAccount)
        {
            return appointmentService.CreateAppointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
        }

        public bool DeleteAppointment(int id)
        {
            return appointmentService.DeleteAppointment(id);
        }

        public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType,
            Doctor doctor, Room room, PatientAccount patientAccount)
        {
            return appointmentService.EditAppointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
        }

        public List<Appointment> GetAll()
        {
            return appointmentService.GetAll();
        }

        public Appointment GetAppointmentById(int id)
        {
            return appointmentService.GetAppointmentById(id);
        }

        public List<Appointment> GetByDoctor(Doctor doctor)
        {
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Doctor.CitizenId.Equals(doctor.CitizenId))
                    return appointments;
            }
            return null;

        }

        public bool CreateRenovation(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, 
            PatientAccount patientAccount, Doctor doctor, Room room)
        {
            return appointmentService.CreateRenovation(id, startTime, endTime, duration, scheduled, appointmetntType, patientAccount, doctor, room);
        }

    }
}