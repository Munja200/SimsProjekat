using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class OperationController
   {
        private readonly OperationService _service;

        public OperationController(OperationService service)
        {
            _service = service;
        }

        public bool CreateOperation(Operation operation)
        {
            // opefaciona sala, zakazan termin, specijalista u smenu
            if (_service.GetOperationById(operation.id).room.RoomType.Equals("operationRoom") && _service.GetOperationById(operation.id).appointment.Scheduled.Equals(false) && _service.GetOperationById(operation.id).specialist.workingTime.startTime.Equals(true) && _service.GetOperationById(operation.id).specialist.workingTime.endTime.Equals(false))
            {
                return _service.CreateOperation(operation); ;
            }
            return false;
        }

        public bool DeleteOperation(Operation operation)
        {
            if (_service.GetOperationById(operation.id).room.RoomType.Equals("operationRoom") && _service.GetOperationById(operation.id).appointment.Scheduled.Equals(true))
            {
                return _service.DeleteOperation(operation);
            }
            return false;

        }

        public bool UpdateOperation(Operation operation)
        {
            if (_service.GetOperationById(operation.id).room.RoomType.Equals("operationRoom") && _service.GetOperationById(operation.id).appointment.Scheduled.Equals(true))
            {
                return _service.UpdateOperation(operation);
            }
            return false;

        }

        public List<Operation> GetAll()
        {
            return _service.GetAll();
        }

        public Operation GetOperationById(int id)
        {
            return _service.GetOperationById(id);
        }


        public Service.OperationService operationService;
   
   }
}