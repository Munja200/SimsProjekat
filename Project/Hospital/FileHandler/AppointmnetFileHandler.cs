using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class AppointmnetFileHandler
   {

        private readonly string path = @"../../Resources/Appointment.txt";

        public List<Appointment> Read()
        {

            string serializedOperations = System.IO.File.ReadAllText(path);
            List<Appointment> appointments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Appointment>>(serializedOperations);
            return appointments;
        }

        public void Write(List<Appointment> appointments)
        {
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room != null)
                    appointment.Room.serialize = true;
                appointment.serialize = true;
            }

            //SupplyingThePatientViaId(appointments);

            string serializedOperations = Newtonsoft.Json.JsonConvert.SerializeObject(appointments);
            System.IO.File.WriteAllText(path, serializedOperations);

        }

        public void SupplyingThePatientViaId(List<Appointment>appointments) 
        {
            foreach (Appointment appointment in appointments)
            {
                if (appointment.PatientAccount != null)
                    appointment.PatientAccount.serialize = true;
                appointment.serialize = true;
            }
        }


   }
}