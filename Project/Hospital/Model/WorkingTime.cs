using System;

namespace Model
{
   public class WorkingTime
   {
      private DateTime startTime;
      private DateTime endTime;
      private int duration;
      
      public System.Collections.Generic.List<Employee> employee;
      
      public System.Collections.Generic.List<Employee> Employee
      {
         get
         {
            if (employee == null)
               employee = new System.Collections.Generic.List<Employee>();
            return employee;
         }
         set
         {
            RemoveAllEmployee();
            if (value != null)
            {
               foreach (Employee oEmployee in value)
                  AddEmployee(oEmployee);
            }
         }
      }
      
      
      public void AddEmployee(Employee newEmployee)
      {
         if (newEmployee == null)
            return;
         if (this.employee == null)
            this.employee = new System.Collections.Generic.List<Employee>();
         if (!this.employee.Contains(newEmployee))
            this.employee.Add(newEmployee);
      }
      
      
      public void RemoveEmployee(Employee oldEmployee)
      {
         if (oldEmployee == null)
            return;
         if (this.employee != null)
            if (this.employee.Contains(oldEmployee))
               this.employee.Remove(oldEmployee);
      }
      
      
      public void RemoveAllEmployee()
      {
         if (employee != null)
            employee.Clear();
      }
   
   }
}