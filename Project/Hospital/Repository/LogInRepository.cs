using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital.Repository
{
    public class LogInRepository
    {

        public List<Employee> employees;
        public FileHandler.LogInFileHandler logInFileHandler;

        public LogInRepository()
        {
            logInFileHandler = new FileHandler.LogInFileHandler();
            employees = new List<Employee>();
        }

        public Employee LogIn(string username, string password)
        {

            employees = logInFileHandler.Read();
            foreach (Employee employee in employees) 
            {
                if(employee.Username.Equals(username) && employee.Password.Equals(password))
                {
                    return employee;
                }
            }
                return null;
        }

    }
}
