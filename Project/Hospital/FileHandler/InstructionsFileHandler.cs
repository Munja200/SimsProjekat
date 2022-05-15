using System.Collections.Generic;
using Hospital.Model;

namespace Hospital.FileHandler
{
    public class InstructionsFileHandler
    {
        private readonly string path = @"../../Resources/Instructions.txt";

        public List<Instructions> Read()
        {

            string serializedInstructions = System.IO.File.ReadAllText(path);
            List<Instructions> instructions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Instructions>>(serializedInstructions);
            return instructions;
        }

        public void Write(List<Instructions> instructions)
        {
            string serializedInstructions = Newtonsoft.Json.JsonConvert.SerializeObject(instructions);
            System.IO.File.WriteAllText(path, serializedInstructions);

        }

    }
}
