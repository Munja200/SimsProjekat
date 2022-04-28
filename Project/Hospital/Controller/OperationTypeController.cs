using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Service;
using Model;

namespace Hospital.Controller
{
    public class OperationTypeController
    {
        private readonly OperationTypeService _service;

        public OperationTypeController(OperationTypeService service)
        {
            _service = service;
        }

        public List<OperationType> GetAll()
        {
            return _service.GetAll();
        }

        public bool CreateOperationType(int oc, string od)
        {
            return _service.CreateOperationType(oc, od);
        }

        public bool DeleteOperationType(int oc)
        {
            return _service.DeleteOperationType(oc);
        }

        public OperationType GetOperationById(int oc)
        {
            return _service.GetOperationById(oc);
        }

        public bool EditOperationType(int oc, string od)
        {
            return _service.EditOperationType(oc, od);
        }



    }
}
