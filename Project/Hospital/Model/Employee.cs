namespace Model
{
    public class Employee : RegisteredUser
    {
        public EmployeeRole role { get; set; }
        
        public WorkingTime WorkingTime { get; set; }
        /*
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
        */

    }
}