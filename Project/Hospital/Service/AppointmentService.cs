using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Repository;

namespace Service
{
    public class AppointmentService
    {
        public Repository.AppointmentRepository appointmentRepository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, 
            Doctor doctor, Room room, PatientAccount patientAccount)
        {
            return appointmentRepository.CreateAppointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
        }

        public bool DeleteAppointment(int id)
        {
            return appointmentRepository.DeleteAppointment(id);
        }

        public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, 
            Doctor doctor, Room room, PatientAccount patientAccount)
        {
            return appointmentRepository.EditAppointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
        }

        public Appointment GetAppointmentById(int id)
        {
            return appointmentRepository.GetAppointmentById(id);

        }

        public bool CreateRenovation(Appointment appointment)
        {
            if ((DateTime.Compare(appointment.StartTime.Date, DateTime.Today) < 0) ||(DateTime.Compare(appointment.EndTime.Date, appointment.StartTime.Date) < 0))
                return false;

            appointment.Id = GenerateAppointmentId();
            if (!this.IsTheRoomOccupied(appointment.StartTime, appointment.EndTime, appointment.Room))
                return appointmentRepository.CreateRenovation(appointment);
            else
                return false;

        }
        private int GenerateAppointmentId()
        {
            int id = appointmentRepository.GetAll().Count() == 0 ? 0 : appointmentRepository.GetAll().Max(Appointment => Appointment.Id);
            return ++id;
        }

        private bool IsTheRoomOccupied(DateTime startTime, DateTime endTime,Room room) {
            foreach (Appointment appointment in this.GetAll())
            {
                if (appointment.Room != null)
                {
                    if (appointment.Room.Id.Equals(room.Id))
                    {
                        if ((DateTime.Compare(startTime, appointment.StartTime) >= 0) && (DateTime.Compare(startTime, appointment.EndTime) < 0))
                             return true;
                        
                        if ((DateTime.Compare(endTime, appointment.StartTime) >= 0) && (DateTime.Compare(endTime, appointment.EndTime) < 0))
                            return true;

                        if ((DateTime.Compare(startTime, appointment.StartTime) <= 0) && (DateTime.Compare(endTime, appointment.EndTime) >= 0))
                            return true;
                    }
                }
            }
            return false;
        }


    }
}