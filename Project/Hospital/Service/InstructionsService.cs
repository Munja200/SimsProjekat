﻿using System.Collections.Generic;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class InstructionsService
    {
        public Repository.InstructionsRepository instructionsRepository;

        public InstructionsService(InstructionsRepository instructionsRepository)
        {
            this.instructionsRepository = instructionsRepository;
        }

        public List<Instructions> GetAll()
        {
            return instructionsRepository.GetAll();
        }

    }

}
