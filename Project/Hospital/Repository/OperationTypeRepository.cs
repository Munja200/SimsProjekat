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
        public FileHandler.OperationTypeFileHandler operationTypeFileHandler;

        public OperationTypeRepository()
        {
            operationTypeFileHandler = new FileHandler.OperationTypeFileHandler();
            operationtypes = new List<OperationType>();
        }
        public bool CreateOperationType(int operationCode, string operationDescription)
        {
            operationtypes.Add(new OperationType(operationCode, operationDescription));
            operationTypeFileHandler.Write(operationtypes);
            return true;
        }

        public bool DeleteOperationType(int oc)
        {
            foreach (OperationType operationType in operationtypes)
            {
                if (operationType.OperationCode.Equals(oc))
                {
                    operationtypes.Remove(operationType);
                    operationTypeFileHandler.Write(operationtypes);
                    return true;
                }
            }
            return false;
        }

        public bool EditOperationType(int operationCode, string operationDescription)
        {

            foreach (OperationType operationtype in operationtypes)
            {
                if (operationtype.OperationCode.Equals(operationCode))
                {
                    operationtype.OperationCode = operationCode;
                    operationtype.OperationDescription = operationDescription;

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

        public OperationType GetOperationById(int operationCode)
        {
            foreach (OperationType operationtype in operationtypes)
            {
                if (operationtype.OperationCode.Equals(operationCode))
                    return operationtype;
            }
            return null;
        }

    }

}
