using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Repository
{
    public class InstructionsRepository
    {
        public List<Instructions> instructions;
        public FileHandler.InstructionsFileHandler instructionsFileHandler;

        public InstructionsRepository()
        {
            instructionsFileHandler = new FileHandler.InstructionsFileHandler();
            instructions = new List<Instructions>();
        }

        public List<Instructions> GetAll()
        {

            if (instructionsFileHandler.Read() == null)
                return instructions;

            instructions = instructionsFileHandler.Read();

            return instructions;
        }

    }
}
