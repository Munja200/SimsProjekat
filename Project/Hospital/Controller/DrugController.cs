using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class DrugController
    {

        private readonly DrugService drugService;
        public DrugController(DrugService drugService)
        {
            this.drugService = drugService;
        }

        public List<Drug> GetAll()
        {
            return drugService.GetAll();
        }
        public bool CreateDrug(Drug drug)
        {
            return drugService.CreateDrug(drug);
        }

        public bool EditDrug(Drug drug)
        {
            return drugService.EditDrug(drug);
        }
        public List<Drug> GetAllInvalidDrug()
        {
            return drugService.GetAllInvalidDrug();
        }
    }
}
