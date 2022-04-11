using System;

namespace Model
{
   public class Employee : RegisteredUser
   {
      private EmployeeRole role;

        public WorkingTime workingTime;
        public WorkingTime WorkingTime
        {
            get
            {
                return workingTime;
            }
            set
            {
                if (this.workingTime == null || !this.workingTime.Equals(value))
                {
                    if (this.workingTime != null)
                    {
                        WorkingTime oldWorkingTime = this.workingTime;
                        this.workingTime = null;
                        oldWorkingTime.RemoveEmployee(this);
                    }
                    if (value != null)
                    {
                        this.workingTime = value;
                        this.workingTime.AddEmployee(this);
                    }
                }
            }
        }

    
}
}