using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Service;
using Model;

namespace Hospital.Controller
{
    public class LogInController
    {
        public Service.LogInService logInService;

        public LogInController(LogInService logInService)
        {
            this.logInService = logInService;
        }

        public Employee LogIn(string username, string password)
        {
            return logInService.LogIn(username, password);
        }
    }
}
