using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class PatientAccountFileHandler
   {

        private readonly string path = @"../../Resources/Patient.txt";

        public void Write(List<PatientAccount> patients)
      {
            string serializedPatients = Newtonsoft.Json.JsonConvert.SerializeObject(patients);
            System.IO.File.WriteAllText(path, serializedPatients);
        }
      
      public List<PatientAccount> Read()
      {
            string serializedPatients = System.IO.File.ReadAllText(path);
            List<PatientAccount> patients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PatientAccount>>(serializedPatients);
            return patients;
        }
      
      
   
   }
}