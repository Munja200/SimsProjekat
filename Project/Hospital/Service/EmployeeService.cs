using Hospital.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class EmployeeService
    {
        private EmployeeRepository employeeRepository;
        public EmployeeService(EmployeeRepository employeeRepoitory)
        {
            this.employeeRepository = employeeRepoitory;
            this.GetAll();
        }

        public List<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }
       

        public Employee GetById(int id)
        {
            return employeeRepository.GetById(id);
        }

    }
}
