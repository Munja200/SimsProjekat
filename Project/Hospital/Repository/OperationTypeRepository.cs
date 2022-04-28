using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Hospital.Repository
{
    public class OperationTypeRepository
    {
        public List<OperationType> operationtypes;
        public OperationTypeRepository()
        {
            operationTypeFileHandler = new FileHandler.OperationTypeFileHandler();
            operationtypes = new List<OperationType>();
        }
        public bool CreateOperationType(int oc, string od)
        {
            operationtypes.Add(new OperationType(oc, od));
            operationTypeFileHandler.Write(operationtypes);
            return true;
        }

        public bool DeleteOperationType(int oc)
        {
            foreach (OperationType operationtype in operationtypes)
            {
                if (operationtype.OperationCode.Equals(oc))
                {
                    operationtypes.Remove(operationtype);
                    operationTypeFileHandler.Write(operationtypes);
                    return true;
                }
            }
            return false;
        }

        public bool EditOperationType(int oc, string od)
        {

            foreach (OperationType operationtype in operationtypes)
            {
                if (operationtype.OperationCode.Equals(oc))
                {
                    operationtype.OperationCode = oc;
                    operationtype.OperationDescription = od;

                    return true;
                }
            }

            return false;
        }

        public List<OperationType> GetAll()
        {
            if (operationTypeFileHandler.Read() == null)
                return operationtypes;

            operationtypes = operationTypeFileHandler.Read();

            return operationtypes;
        }

        public OperationType GetOperationById(int oc)
        {
            foreach (OperationType operationtype in operationtypes)
            {
                if (operationtype.OperationCode.Equals(oc))
                    return operationtype;
            }
            return null;
        }

        public FileHandler.OperationTypeFileHandler operationTypeFileHandler;

    }

}
