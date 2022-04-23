using System;

namespace Model
{
   public class User
   {
      public String name { get; set; }
      public String surname { get; set; }
      public int citizenId { get; set; }
      public Gender gender { get; set; }
      public DateTime dateOfBirth { get; set; }
      public String email { get; set; }
      public String phoneNumber { get; set; }
      public Address address { get; set; }

        public User(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address)
        {
            this.name = name;
            this.surname = surname;
            this.citizenId = citizenId;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
    }
}