using System;
using Hospital.Model;

namespace Model
{
    public class Doctor : Employee
    {

        public float AverageRating { get; set; }

        public System.Collections.Generic.List<Appointment> appointment;

        public Doctor(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, 
            String username, String password, EmployeeRole role, WorkingTime workingTime, float averageRating) : base(name, surname, citizenId, gender, dateOfBirth,
                email, phoneNumber, address, username, password, role, workingTime)
        {
            AverageRating = averageRating;
        }
    }

}