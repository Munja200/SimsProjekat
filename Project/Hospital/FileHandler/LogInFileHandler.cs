using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital.FileHandler
{
    public class LogInFileHandler
    {
        private readonly string path = @"../../Resources/Employee.txt";

        public List<Employee> Read()
        {

            string serializedLogIn = System.IO.File.ReadAllText(path);
            List<Employee> employees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(serializedLogIn);
            return employees;
        }

        public void Write(List<Employee> employees)
        {
            string serializedLogIn = Newtonsoft.Json.JsonConvert.SerializeObject(employees);
            System.IO.File.WriteAllText(path, serializedLogIn);

        }
    }
}
