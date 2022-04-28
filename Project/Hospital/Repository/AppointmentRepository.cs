using System;
using System.Collections.Generic;
using Model;

namespace Repository
{
    public class AppointmentRepository

    {
        public List<Appointment> appointments;

        public AppointmentRepository()
        {
            appointmnetFileHandler = new FileHandler.AppointmnetFileHandler();
            appointments = new List<Appointment>();
        }

        public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType)
        {
            appointments.Add(new Appointment(id, startTime, endTime, duration, scheduled, appointmetntType));
            appointmnetFileHandler.Write(appointments);
            return true;
        }

        public bool DeleteAppointment(int id)
        {
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id.Equals(id))
                {
                    appointments.Remove(appointment);
                    appointmnetFileHandler.Write(appointments);
                    return true;
                }
            }
          return false;
        }

        public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType)
        {

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id.Equals(id))
                {
                    appointment.Id = id;
                    appointment.StartTime = startTime;
                    appointment.EndTime = endTime;
                    appointment.Duration = duration;
                    appointment.Scheduled = scheduled;
                    appointment.AppointmetntType = appointmetntType;

                    appointmnetFileHandler.Write(appointments);

                    return true;
                }
            }

            return false;
        }

        public List<Appointment> GetAll()
        {

            if (appointmnetFileHandler.Read() == null)
                return appointments;

            appointments = appointmnetFileHandler.Read();

            return appointments;
        }

        public Appointment GetAppointmentById(int id)
        {
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id.Equals(id))
                    return appointment;
            }
            return null;
        }

        public FileHandler.AppointmnetFileHandler appointmnetFileHandler;

    }
}