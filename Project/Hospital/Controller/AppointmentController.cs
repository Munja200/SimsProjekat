using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class AppointmentController
   {
      public bool CreateAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType)
      {
         return appointmentService.CreateAppointment(id, startTime, endTime, duration, scheduled, appointmetntType);
      }
      
      public bool DeleteAppointment(int id)
      {
       return appointmentService.DeleteAppointment(id);
      }
      
      public bool EditAppointment(int id, DateTime startTime, DateTime endTime, int duration, bool scheduled, AppointmentType appointmetntType)
      {
         return appointmentService.EditAppointment(id, startTime, endTime, duration, scheduled, appointmetntType);  
      }
      
      public List<Appointment> GetAll()
      {
         return appointmentService.GetAll();
      }
      
      public Appointment GetAppointmentById(int id)
      {
        return appointmentService.GetAppointmentById(id);
       }
      
      public Service.AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
    }
}