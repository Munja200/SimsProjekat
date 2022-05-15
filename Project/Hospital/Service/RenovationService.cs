using Hospital.Model;
using Hospital.Repository;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class RenovationService
    {
        public AppointmentService appointmentService;
        public RenovationService(RenovationRepository renovationRepository,AppointmentService appointmentService)
        {
            this.renovationRepository = renovationRepository;
            this.appointmentService = appointmentService;
        }
        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();
        }

        public bool Delete(Renovation renovation)
        {
            appointmentService.DeleteAppointment(renovation.Appointment.Id);
            return renovationRepository.Delete(renovation);
        }

        public bool Edit(Renovation renovation)
        {
            return renovationRepository.Edit(renovation);
        }

        public bool Create(Renovation renovation)
        {
            if (renovation.Appointment.Room == null) 
            {
                return false;
            }

            if (renovation.RenovationType == RenovationType.Merger) 
            {
                if (!CreateAppointmenForMergerRoom(renovation))
                    return false;
            }

            return renovationRepository.Create(renovation);
        }

        public bool CreateAppointmenForMergerRoom(Renovation renovation)
        {
            int ids = appointmentService.GetAll().Count() == 0 ? 0 : appointmentService.GetAll().Max(Appointment => Appointment.Id);
            if (renovation.Room == null)
            {
                appointmentService.DeleteAppointment(renovation.Appointment.Id);
                return false;
            }

            if (!appointmentService.CreateRenovation(++ids, renovation.Appointment.StartTime, renovation.Appointment.EndTime, 0, true, AppointmentType.renovationAppointment, null, null, renovation.Room))
            {
                appointmentService.DeleteAppointment(renovation.Appointment.Id);
                return false;
            }
            return true;
        }

        public Repository.RenovationRepository renovationRepository;
    }
}
