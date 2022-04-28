using System;

namespace Model
{
   public class Employee : RegisteredUser
   {
        private EmployeeRole role { get; set; }

        public WorkingTime workingTime { get; set; }

        public Employee(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password, EmployeeRole role, WorkingTime workingTime) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password)
        {
            this.role = role;
            this.workingTime = workingTime;
        }
    
}
}