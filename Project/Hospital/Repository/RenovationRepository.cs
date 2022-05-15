using Hospital.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class RenovationRepository
    {
        public List<Renovation> renovations;
        public FileHandler.RenovationFileHandler renovationFileHandler;
        public RoomRepository roomRepository;
        public AppointmentRepository appointmentRepository;


        public RenovationRepository(AppointmentRepository appointmentRepository, RoomRepository roomRepository) {
            this.renovationFileHandler = new FileHandler.RenovationFileHandler();
            this.renovations = new List<Renovation>();
            this.roomRepository = roomRepository;
            this.appointmentRepository = appointmentRepository;
            this.GetAll();
        }

        public List<Renovation> GetAll()
        {
            if (renovationFileHandler.Read() == null)
                return renovations;
            
            renovations.Clear();
            SetRenovationsRoomAndAppointment();
          
            return renovations;
        }

        public void SetRenovationsRoomAndAppointment() 
        {
            foreach (Renovation newRenovation in renovationFileHandler.Read())
            {
                if (newRenovation.Room != null)
                {
                    newRenovation.Room = roomRepository.GetById(newRenovation.Room.Id);
                }
                if(newRenovation.Appointment != null)
                    newRenovation.Appointment = appointmentRepository.GetAppointmentById(newRenovation.Appointment.Id);
                renovations.Add(newRenovation);
            }
        }

        public bool Delete(Renovation renovation)
        {
            foreach (Renovation renovationTemp in renovations)
            {
                if (renovationTemp.Equals(renovation))
                {
                    renovations.Remove(renovationTemp);
                    renovationFileHandler.Write(renovations);
                    return true;
                }
            }
            return false;
        }

        public bool Edit(Renovation renovation)
        {
            return true;
        }

        public bool Create(Renovation renovation)
        {


            renovations.Add(new Renovation(renovation.Room,renovation.Appointment,renovation.RenovationType));
            renovationFileHandler.Write(renovations);
            return true;
        }

    }
}
