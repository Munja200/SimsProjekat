using Model;
using System;
using System.Collections.Generic;

namespace Service
{
   public class AppointmentService
   {
      public List<Appointment> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool CreateAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Appointment GetAppointmentById(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool IsAppointmentTaken(ref Appointment apointment)
      {
         throw new NotImplementedException();
      }
      
      public Repository.AppointmentRepository appointmentRepository;
   
   }
}