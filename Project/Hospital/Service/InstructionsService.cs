using System.Collections.Generic;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class InstructionsService
    {
        public InstructionsService(InstructionsRepository instructionsRepository)
        {
            this.instructionsRepository = instructionsRepository;
        }

        public List<Instructions> GetAll()
        {
            return instructionsRepository.GetAll();
        }

        public Repository.InstructionsRepository instructionsRepository;
    }

}
