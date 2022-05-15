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

        public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, Doctor doctor, Room room, PatientAccount patientAccount)
        {
            return appointmentRepository.CreateAppointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
        }

        public bool DeleteAppointment(int id)
        {
            return appointmentRepository.DeleteAppointment(id);
        }

        public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, Doctor doctor, Room room, PatientAccount patientAccount)
        {
            return appointmentRepository.EditAppointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
        }

        public Appointment GetAppointmentById(int id)
        {
            return appointmentRepository.GetAppointmentById(id);

        }

        public bool IsAppointmentTaken(ref Appointment apointment)
        {
            throw new NotImplementedException();
        }

        public bool CreateRenovation(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType, PatientAccount patientAccount, Doctor doctor, Room room)
        {
            if ((DateTime.Compare(startTime.Date, DateTime.Today) < 0) ||(DateTime.Compare(endTime.Date, startTime.Date) < 0))
            {
                return false;
            }

            if (!this.IsTheRoomOccupied(startTime, endTime, room))
            {
                return appointmentRepository.CreateRenovation(id, startTime, endTime, duration, scheduled, appointmetntType, patientAccount, doctor, room);
            }
            else
                return false;

        }

        public bool IsTheRoomOccupied(DateTime startTime, DateTime endTime,Room room) {
            foreach (Appointment appointment in this.GetAll())
            {
                if (appointment.Room != null)
                {
                    if (appointment.Room.Id.Equals(room.Id))
                    {
                        if ((DateTime.Compare(startTime, appointment.StartTime) >= 0) && (DateTime.Compare(startTime, appointment.EndTime) < 0))
                            { return true;}
                        
                        if ((DateTime.Compare(endTime, appointment.StartTime) >= 0) && (DateTime.Compare(endTime, appointment.EndTime) < 0))
                            {return true;}

                        if ((DateTime.Compare(startTime, appointment.StartTime) <= 0) && (DateTime.Compare(endTime, appointment.EndTime) >= 0))
                            {return true;}
                    }
                }
            }

            return false;
        }

        public Repository.AppointmentRepository appointmentRepository;

    }
}