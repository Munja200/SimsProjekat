using System;
using System.Windows.Controls;

namespace Model
{
   public class OperationType
   {
        public int OperationCode { get; set; }
        public string OperationDescription { get; set; }

        public OperationType(int operationCode, string operationDescription)
        {
            OperationCode = operationCode;
            OperationDescription = operationDescription;

        }

        public override bool Equals(object obj)
        {
            return Equals(obj as OperationType);
        }

        public bool Equals(OperationType other)
        {
            return other != null &&
                   OperationCode == other.OperationCode;
        }
    }
}