namespace Model
{

    public class Employee : RegisteredUser
    {
        public EmployeeRole role { get; set; }
        
        public WorkingTime WorkingTime { get; set; }
        /*
        public WorkingTime WorkingTime

        {
            this.role = role;
            this.workingTime = workingTime;
        }

        */

    }

}