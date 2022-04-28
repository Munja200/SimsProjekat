using System;

namespace Model
{
   public class Specialist : Doctor
   {
      public Speciality speciality { get; set; }

        public Specialist(string name, string surname, int citizenId, Gender gender, DateTime dateOfBirth, string email, string phoneNumber, Address address, string username, string password, EmployeeRole role, WorkingTime workingTime, float averageRating, Speciality speciality) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password, role, workingTime, averageRating)
        {
            this.speciality = speciality;
        }
    }
}