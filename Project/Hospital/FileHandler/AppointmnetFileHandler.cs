using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class AppointmnetFileHandler
   {

        private readonly string path = @"../../Resources/SelfAppointment.txt";

        public List<Appointment> Read()
        {

            string serializedOperations = System.IO.File.ReadAllText(path);
            List<Appointment> appointments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Appointment>>(serializedOperations);
            return appointments;
        }

        public void Write(List<Appointment> appointments)
        {
            string serializedOperations = Newtonsoft.Json.JsonConvert.SerializeObject(appointments);
            System.IO.File.WriteAllText(path, serializedOperations);

        }
   
   }
}