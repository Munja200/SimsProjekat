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

        public void Write(List<Employee> employees)
        {
            string serializedEmployee = Newtonsoft.Json.JsonConvert.SerializeObject(employees);
            System.IO.File.WriteAllText(path, serializedEmployee);
        }

        public List<Employee> Read()
        {
            string serializedEmployee = System.IO.File.ReadAllText(path);
            List<Employee> employees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(serializedEmployee);
            return employees;
        }
    }
}
