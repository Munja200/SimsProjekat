using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class RenovationController
    {
        public RenovationService renovationService;
        public RenovationController(RenovationService renovationService)
        {
            this.renovationService = renovationService;
        }
        public List<Renovation> GetAll()
        {
            return renovationService.GetAll();
        }

        public bool Delete(Renovation renovation)
        {
            return renovationService.Delete(renovation);
        }

        public bool Edit(Renovation renovation)
        {
            return renovationService.Edit(renovation);
        }

        public bool Create(Renovation renovation)
        {
            return renovationService.Create(renovation);
        }
    }
}
