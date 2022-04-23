using System;

namespace Model
{
   public class PatientAccount : RegisteredUser
   {
      public bool isGuest { get; set; }
      public int healthCardId { get; set; }
      public String allergies { get; set; }

        public PatientAccount(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password, bool isGuest, int healthCardId, string allergies) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password)
        {
            this.isGuest = isGuest;
            this.healthCardId = healthCardId;
            this.allergies = allergies;
        }
    }
}