using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class OperationController
   {
        private readonly OperationService _service;

        public Service.OperationService operationService;


        public OperationController(OperationService service)
        {
            _service = service;
        }

        public bool CreateOperation(int id, int duration, OperationType operationType, Specialist specialist, Room room, Appointment appointment)
        {   
            return _service.CreateOperation(id, duration, operationType, specialist, room, appointment);
        }

        public bool DeleteOperation(int id)
        {
            return _service.DeleteOperation(id);        
        }

        public bool EditOperation(int id, int duration, OperationType operationType, Specialist specialist, Room room, Appointment appointment)
        {
                return _service.EditOperation(id, duration, operationType, specialist, room, appointment);

        }

        public List<Operation> GetAll()
        {
            return _service.GetAll();
        }

        public Operation GetOperationById(int id)
        {
            return _service.GetOperationById(id);
        }
   
   }
}