using System;
using Hospital.Model;

namespace Model
{

    public class Employee : RegisteredUser
    {
        public EmployeeRole Role { get; set; }
        
        public WorkingTime WorkingTime { get; set; }
        public bool Serialize { get; set; }

        public Employee(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber,
            Address address, String username, String password, EmployeeRole role, WorkingTime workingTime) : 
            base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password)
        {
            Role = role;
            WorkingTime = workingTime;
        }

    
        public bool ShouldSerializeSerialize()
        {
            Serialize = true;
            return false;
        }

        public bool ShouldSerializeName() { return Serialize; }
        public bool ShouldSerializeSurname() { return Serialize; }
        public bool ShouldSerializeGender() { return Serialize; }
        public bool ShouldSerializeRole() { return Serialize; }
        public bool ShouldSerializeWorkingTime() { return Serialize; }
        public bool ShouldSerializeDateOfBirth() { return Serialize; }
        public bool ShouldSerializePhoneNumber() { return Serialize; }
        public bool ShouldSerializeAddress() { return Serialize; }
        public bool ShouldSerializeUsername() { return Serialize; }
        public bool ShouldSerializePassword() { return Serialize; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

    }
}

