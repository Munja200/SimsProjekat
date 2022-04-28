using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital.FileHandler
{
    public class SpecialistFileHandler
    {
        private readonly string path = @"../../Resources/Specialist.txt";

        public List<Specialist> Read()
        {

            string serializedOperations = System.IO.File.ReadAllText(path);
            List<Specialist> specialists = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Specialist>>(serializedOperations);
            return specialists;
        }

        public void Write(List<Specialist> specialists)
        {
            string serializedOperations = Newtonsoft.Json.JsonConvert.SerializeObject(specialists);
            System.IO.File.WriteAllText(path, serializedOperations);

        }
    }
}
