using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class DrugController
    {

        private readonly DrugService _service;
        public DrugController(DrugService drugService)
        {
            _service = drugService;
        }

        public List<Drug> GetAll()
        {
            return _service.GetAll();
        }

        public bool EditDrug(Drug drug) 
        {
            return _service.EditDrug(drug); 
        }
    }
}
