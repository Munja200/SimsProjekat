using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class OperationRepository
   {

        public List<Operation> operations;
        public OperationRepository()
        {
            operationFileHandler = new FileHandler.OperationFileHandler();
            operations = new List<Operation>();
        }
        public bool CreateOperation(Operation operation)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteOperation(Operation operation)
      {
            throw new NotImplementedException();
        }
      
      public bool UpdateOperation(Operation operation)
      {
         throw new NotImplementedException();
      }
      
      public List<Operation> GetAll()
      {
            if (operationFileHandler.Read() == null)
                return operations;

            operations = operationFileHandler.Read();

            return operations;
        }
      
      public Operation GetOperationById(int id)
      {
            foreach (Operation operation in operations)
            {
                if (operation.id.Equals(id))
                    return operation;
            }
            return null;
        }
      
      public FileHandler.OperationFileHandler operationFileHandler;
   
   }
}