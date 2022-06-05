using System.Collections.Generic;
using Model;

namespace Hospital.FileHandler
{
    public class OperationTypeFileHandler
    {
        private readonly string path = @"../../Resources/OperationType.txt";

        public List<OperationType> Read()
        {

            string serializedOperationsTypes = System.IO.File.ReadAllText(path);
            List<OperationType> operationsTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OperationType>>(serializedOperationsTypes);
            return operationsTypes;
        }

        public void Write(List<OperationType> operationsTypes)
        {
            string serializedOperations = Newtonsoft.Json.JsonConvert.SerializeObject(operationsTypes);
            System.IO.File.WriteAllText(path, serializedOperations);

        }

    }
}
