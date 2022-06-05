using Hospital.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class EmployeeController
    {
        private EmployeeService employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
            this.GetAll();
        }

        public List<Employee> GetAll()
        {
            return employeeService.GetAll();
        }


        public Employee GetById(int id)
        {
            return employeeService.GetById(id);
        }
    }
}
