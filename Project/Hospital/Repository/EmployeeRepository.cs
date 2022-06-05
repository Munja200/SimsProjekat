using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class EmployeeRepository
    {
        public List<Employee> employees;

        public FileHandler.EmployeeFileHandler employeeFileHandler;
        public EmployeeRepository()
        {
            employeeFileHandler = new FileHandler.EmployeeFileHandler();
            employees = new List<Employee>();
            this.GetAll();
        }

        public List<Employee> GetAll()
        {
            if (employeeFileHandler.Read() == null)
                return employees;

            AddAllEmployee();

            return employees;
        }
        private void AddAllEmployee() {
            employees.Clear();
            List<Employee> list = employeeFileHandler.Read();
            foreach (Employee newEmployee in list)
            {
                employees.Add(newEmployee);
            }

        }

        public Employee GetById(int id)
        {
            foreach (Employee employee in employees)
            {
                if (employee.CitizenId.Equals(id))
                    return employee;
            }
            return null;
        }
    }
}
