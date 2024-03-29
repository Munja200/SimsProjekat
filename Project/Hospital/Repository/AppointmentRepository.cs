using System;
using System.Collections.Generic;
using Hospital.Repository;
using Model;

namespace Repository
{
    public class AppointmentRepository

    {
        public List<Appointment> appointments;
        public FileHandler.AppointmnetFileHandler appointmnetFileHandler;


        public AppointmentRepository()
        {
            appointmnetFileHandler = new FileHandler.AppointmnetFileHandler();
            appointments = new List<Appointment>();
            this.GetAll();
        }

        public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType,
            Doctor doctor, Room room, PatientAccount patientAccount)
        {
            appointments.Add(new Appointment(id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount));
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

        public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType,
            Doctor doctor, Room room, PatientAccount patientAccount)
        {

            foreach (Appointment appointment in appointments)
            {
                AppointmentIdEquals(appointment, id, startTime, endTime, duration, scheduled, appointmetntType, doctor, room, patientAccount);
            }

            return false;
        }

        public bool AppointmentIdEquals(Appointment appointment, int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, 
            AppointmentType appointmetntType, Doctor doctor, Room room, PatientAccount patientAccount) 
        {
            if (appointment.Id.Equals(id))
            {
                appointment.Id = id;
                appointment.StartTime = startTime;
                appointment.EndTime = endTime;
                appointment.Duration = duration;
                appointment.Scheduled = scheduled;
                appointment.AppointmetntType = appointmetntType;
                appointment.Doctor = doctor;
                appointment.Room = room;
                appointment.PatientAccount = patientAccount;

                appointmnetFileHandler.Write(appointments);

                return true;
            }
            return false;
        }

        public List<Appointment> GetAll()
        {

            if (appointmnetFileHandler.Read() == null)
                return appointments;
            RoomRepository roomRepository = new RoomRepository();

            appointments.Clear();

            List<Appointment> newAppointments = appointmnetFileHandler.Read();

            roomRepository.GetAll();

            foreach (Appointment newAppointment in newAppointments)
            {
                if (newAppointment.Room != null)
                {
                    newAppointment.Room = roomRepository.GetById(newAppointment.Room.Id);
                }
                appointments.Add(newAppointment);
            }
            return appointments;
        }

        public Appointment GetAppointmentById(int id)
        {
            this.GetAll();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id.Equals(id))
                    return appointment;
            }
            return null;
        }

        public bool CreateRenovation(Appointment appointment)
        {
            appointments.Add(appointment);
            appointmnetFileHandler.Write(appointments);
            return true;
        }
    }
}