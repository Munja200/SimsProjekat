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
            int ids = drugRepository.GetAll().Count() == 0 ? 0 : drugRepository.GetAll().Max(Drug => Drug.Id);
            drug.Id = ++ids;
            return drugRepository.CreateDrug(drug);
        }

        public bool EditDrug(Drug drug)
        {

            return drugRepository.EditDrug(drug);
        }
    }
}
