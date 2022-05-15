using System.Collections.Generic;
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

        public bool EditDrug(Drug drug)
        {

            return drugRepository.EditDrug(drug);
        }
    }
}
