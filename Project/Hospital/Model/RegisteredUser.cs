using System;

namespace Model
{
   public class RegisteredUser : User
   {
      public String username { get; set; }
      public String password { get; set; }

        public RegisteredUser(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address)
        {
            this.username = username;
            this.password = password;
        }
    }
}