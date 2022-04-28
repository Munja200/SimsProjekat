using System;
using System.Collections.Generic;
using Model;
using Repository;

namespace Service
{
    public class AppointmentService
    {
        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType)
        {
            return appointmentRepository.CreateAppointment(id, startTime, endTime, duration, scheduled, appointmetntType);
        }

        public bool DeleteAppointment(int id)
        {
            return appointmentRepository.DeleteAppointment(id);
        }

        public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType)
        {
            return appointmentRepository.EditAppointment(id, startTime, endTime, duration, scheduled, appointmetntType);
        }

        public Appointment GetAppointmentById(int id)
        {
            return appointmentRepository.GetAppointmentById(id);

        }

        public bool IsAppointmentTaken(ref Appointment apointment)
        {
            throw new NotImplementedException();
        }

        public Repository.AppointmentRepository appointmentRepository;

    }
}