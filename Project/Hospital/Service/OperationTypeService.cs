using System;
using System.Collections.Generic;
using Hospital.Repository;
using Model;
using Repository;


namespace Hospital.Service
{
    public class OperationTypeService
    {
        public OperationTypeService(OperationTypeRepository operationtypeRepository)
        {
            this.operationtypeRepository = operationtypeRepository;
        }

        public List<OperationType> GetAll()
        {
            return operationtypeRepository.GetAll();
        }

        public bool CreateOperationType(int oc, string od)
        {
            return operationtypeRepository.CreateOperationType(oc, od);
        }

        public bool DeleteOperationType(int oc)
        {
         return operationtypeRepository.DeleteOperationType(oc);
        }

        public OperationType GetOperationById(int oc)
        {
            return operationtypeRepository.GetOperationById(oc);
        }

        public bool EditOperationType(int oc, string od)
        {
            return operationtypeRepository.EditOperationType(oc, od);
        }

        public Repository.OperationTypeRepository operationtypeRepository;

    }

}
