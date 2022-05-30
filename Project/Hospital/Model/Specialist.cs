using System;
using Hospital.Model;

namespace Model
{

    public class Specialist : Doctor
    {
        public Speciality Speciality { get; set; }

        public Specialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime, string username, string password, string name,
            string surname, int citid, Gender gender, DateTime dateOfBirth, string email, string phoneNumber, Address address) : base(name, surname, citid, gender,
                dateOfBirth, email, phoneNumber, address, username, password, role, workingTime, averageRating)
        {
            Speciality = speciality;
            AverageRating = averageRating;
            role = role;
            WorkingTime = workingTime;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            CitizenId = citid;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;

        }


        public override bool Equals(object obj)
        {
            return Equals(obj as Specialist);
        }

        public bool Equals(Specialist other)
        {
            return other != null &&
                   Speciality == other.Speciality;
        }

    }
}