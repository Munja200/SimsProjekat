using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class DrugService
    {
        public DrugService(DrugRepository drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        public List<Drug> GetAll()
        {
            return drugRepository.GetAll();
        }

        public Repository.DrugRepository drugRepository;
    }
}
