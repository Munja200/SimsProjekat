using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileHandler
{
    public class EmployeeFileHandler
    {
        private readonly string path = @"../../Resources/Employee.txt";

        public void Write(List<Employee> patients)
        {
            string serializedPatients = Newtonsoft.Json.JsonConvert.SerializeObject(patients);
            System.IO.File.WriteAllText(path, serializedPatients);
        }

        public List<Employee> Read()
        {
            string serializedPatients = System.IO.File.ReadAllText(path);
            List<Employee> patients = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(serializedPatients);
            return patients;
        }
    }
}
