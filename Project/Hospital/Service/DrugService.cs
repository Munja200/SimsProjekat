using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class DrugService
    {

        public Repository.DrugRepository drugRepository;

        public DrugService(DrugRepository drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        public List<Drug> GetAll()
        {
            return drugRepository.GetAll();
        }
        public bool CreateDrug(Drug drug)
        {
            drug.Id = GenerateDrugId(); 
            return drugRepository.CreateDrug(drug);
        }
        private int GenerateDrugId() {
            int id = drugRepository.GetAll().Count() == 0 ? 0 : drugRepository.GetAll().Max(Drug => Drug.Id);
            return ++id;
        }

        public bool EditDrug(Drug drug)
        {
            return drugRepository.EditDrug(drug);
        }

        public List<Drug> GetAllInvalidDrug()
        {
            return drugRepository.GetAllInvalidDrug();
        }
    }
}
