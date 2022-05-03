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

      
    }
}
