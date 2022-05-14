using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Repository;
using Model;

namespace Hospital.Service
{
    public class LogInService
    {
        public Repository.LogInRepository logInRepository;

        public LogInService(LogInRepository logInRepository)
        {
            this.logInRepository = logInRepository;
        }

        public Employee LogIn(string username, string password)
        {
            return logInRepository.LogIn(username, password);
        }

    }
}
