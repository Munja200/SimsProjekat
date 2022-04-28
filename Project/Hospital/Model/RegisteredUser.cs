using System;
using Hospital.Model;

namespace Model
{
    public class RegisteredUser : User
   {

      public String Username { get; set; }
      public String Password { get; set; }

        public RegisteredUser(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address)
        {
            this.Username = username;
            this.Password = password;
        }
    }

}