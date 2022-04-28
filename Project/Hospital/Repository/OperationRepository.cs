using Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool CreateOperation(int id, int duration, OperationType operationType, Specialist specialist, Room room, Appointment appointment)
      {
            operations.Add(new Operation(GenerateId(), duration, operationType, specialist, room, appointment));
            operationFileHandler.Write(operations);
            return true;
        }

        public int GenerateId()
        {
            int id = 0;

            foreach (Operation operation in operations) 
            {
                if (operation.Id > id) 
                {
                    id = operation.Id;
                }
            }

            return id + 1;
        }
         
      public bool DeleteOperation(int id)
      {
            foreach (Operation operation in operations)
            {
                if (operation.Id.Equals(id))
                {
                    operations.Remove(operation);
                    operationFileHandler.Write(operations);
                    return true;
                }
            }
            return false;
        }
      
      public bool EditOperation(int id, int duration, OperationType operationType, Specialist specialist, Room room, Appointment appointment)
      {

            foreach (Operation op in operations)
            {
                if (op.Id.Equals(id))
                {
                    op.Id = id;
                    op.Duration = duration;
                    op.OperationType = operationType;
                    op.Specialist = specialist;
                    op.Room = room;
                    op.Appointment = appointment;
                    operationFileHandler.Write(operations);

                    return true;
                }
            }

            return false;
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
                if (operation.Id.Equals(id))
                    return operation;
            }
            return null;
        }
      
      public FileHandler.OperationFileHandler operationFileHandler;
   
   }
}