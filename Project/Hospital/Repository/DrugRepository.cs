using System.Collections.Generic;
using Hospital.Model;
using Repository;

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
            this.GetAll();
        }

        public List<Drug> GetAll()
        {

            if (drugFileHandler.Read() == null)
                return drugs;

            SetDrugsEquipment();

            return drugs;
        }
        public bool CreateDrug(Drug drug)
        {
            drugs.Add(new Drug(drug.Ingredients, drug.Id, drug.Equipment, drug.Replacements, "", true, ""));
            drugFileHandler.Write(drugs);
            return true;
        }
        public void SetDrugsEquipment()
        {
            drugs.Clear();
            EquipmentRepository equipmentRepository = new EquipmentRepository();
            equipmentRepository.GetAll();

            foreach (Drug newDrug in drugFileHandler.Read())
            {
                if (newDrug.Equipment != null)
                {
                    newDrug.Equipment = equipmentRepository.GetById(newDrug.Equipment.Id);
                }
                drugs.Add(newDrug);

            }
        }

        public bool EditDrug(Drug drug)
        {

            foreach (Drug drug1 in drugs)
            {
                if (drug1.Id.Equals(drug.Id))
                {
                    drug1.Id = drug.Id;
                    drug1.Using = drug.Using;
                    drug1.IsNotValid = drug.IsNotValid;
                    drug1.ReasonForInvalidity = drug.ReasonForInvalidity;

                    drugFileHandler.Write(drugs);

                    return true;
                }
            }

            return false;
        }

    }
}
