using System;

namespace Model
{
   public class Doctor : Employee
   {
        public float averageRating { get; set; }

        public Doctor(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password, EmployeeRole role, WorkingTime workingTime, float averageRating) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password, role, workingTime)
        {
            this.averageRating = averageRating;
        }
    }
}