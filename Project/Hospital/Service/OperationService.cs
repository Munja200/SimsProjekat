using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class OperationService
    {
        public OperationService(OperationRepository operationRepository)
        {
            this.operationRepository = operationRepository;
        }

        public List<Operation> GetAll()
        {
            return operationRepository.GetAll();
        }

        public bool CreateOperation(Operation operation)
        {
            return operationRepository.CreateOperation(operation);
        }

        public bool DeleteOperation(Operation operation)
        {
            return operationRepository.DeleteOperation(operation);
        }

        public Operation GetOperationById(int id)
        {
            return operationRepository.GetOperationById(id);
        }

        public bool UpdateOperation(Operation operation)
        {
            return operationRepository.UpdateOperation(operation);
        }

        public Repository.OperationRepository operationRepository;
   
   }
}