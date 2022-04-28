using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class OperationFileHandler
   {

        private readonly string path = @"../../Resources/Operation.txt";

        public List<Operation> Read()
      {

            string serializedOperations = System.IO.File.ReadAllText(path);
            List<Operation> operations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Operation>>(serializedOperations);
            return operations;
        }
      
      public void Write(List<Operation> operations)
      {
            string serializedOperations = Newtonsoft.Json.JsonConvert.SerializeObject(operations);
            System.IO.File.WriteAllText(path, serializedOperations);
           
      }
   
   }
}