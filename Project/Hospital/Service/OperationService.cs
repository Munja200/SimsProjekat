using System.Collections.Generic;
using Model;
using Repository;

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

        public bool CreateOperation(int id, int duration, OperationType operationType, Specialist specialist, Room room, Appointment appointment)
        {
            return operationRepository.CreateOperation(id, duration, operationType, specialist, room, appointment);
        }

        public bool DeleteOperation(int id)
        {
            return operationRepository.DeleteOperation(id);
        }

        public Operation GetOperationById(int id)
        {
            return operationRepository.GetOperationById(id);
        }

        public bool EditOperation(int id, int duration, OperationType operationType, Specialist specialist, Room room, Appointment appointment)
        {
            return operationRepository.EditOperation(id, duration, operationType, specialist, room, appointment);
        }

        public Repository.OperationRepository operationRepository;

    }
}