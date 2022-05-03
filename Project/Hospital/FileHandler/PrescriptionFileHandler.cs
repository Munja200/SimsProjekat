using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.FileHandler
{
    public class PrescriptionFileHandler
    {
        private readonly string path = @"../../Resources/Prescription.txt";

        public List<Prescription> Read()
        {

            string serializedOperations = System.IO.File.ReadAllText(path);
            List<Prescription> prescriptions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Prescription>>(serializedOperations);
            return prescriptions;
        }

        public void Write(List<Prescription> prescriptions)
        {
            string serializedOperations = Newtonsoft.Json.JsonConvert.SerializeObject(prescriptions);
            System.IO.File.WriteAllText(path, serializedOperations);

        }
    }
}
