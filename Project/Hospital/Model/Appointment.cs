using System;

namespace Model
{
   public class Appointment
   {
      public int id;
      public DateTime startTime;
      public DateTime endTime;
      public float duration;
      
      public System.Collections.Generic.List<Operation> operation;
      
      public System.Collections.Generic.List<Operation> Operation
      {
         get
         {
            if (operation == null)
               operation = new System.Collections.Generic.List<Operation>();
            return operation;
         }
         set
         {
            RemoveAllOperation();
            if (value != null)
            {
               foreach (Operation oOperation in value)
                  AddOperation(oOperation);
            }
         }
      }
      
      
      public void AddOperation(Operation newOperation)
      {
         if (newOperation == null)
            return;
         if (this.operation == null)
            this.operation = new System.Collections.Generic.List<Operation>();
         if (!this.operation.Contains(newOperation))
            this.operation.Add(newOperation);
      }
      
      
      public void RemoveOperation(Operation oldOperation)
      {
         if (oldOperation == null)
            return;
         if (this.operation != null)
            if (this.operation.Contains(oldOperation))
               this.operation.Remove(oldOperation);
      }
      
      
      public void RemoveAllOperation()
      {
         if (operation != null)
            operation.Clear();
      }
   
   }
}