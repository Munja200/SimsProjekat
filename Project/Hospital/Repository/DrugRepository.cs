using System.Collections.Generic;
using Hospital.Model;

namespace Hospital.Repository
{
    public class DrugRepository
    {

        public List<Drug> drugs;
        public FileHandler.DrugFileHandler drugFileHandler;

        public DrugRepository()
        {
            drugFileHandler = new FileHandler.DrugFileHandler();
            drugs = new List<Drug>();
        }

        public List<Drug> GetAll()
        {

            if (drugFileHandler.Read() == null)
                return drugs;

            drugs = drugFileHandler.Read();

            return drugs;
        }

        public bool EditDrug(Drug drug)
        {

            foreach (Drug drugg in drugs )
            {
                if (drugg.Id.Equals(drug.Id))
                {
                    drugg.Id = drug.Id;
                    drugg.Name = drug.Name;
                    drugg.Using = drug.Using;
                    drugg.IsValid = drug.IsValid;
                    drugg.ReasonForInvalidity = drug.ReasonForInvalidity;
                   
                    drugFileHandler.Write(drugs);

                    return true;
                }
            }

            return false;
        }

    }
}
