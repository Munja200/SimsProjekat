using System;

namespace Model
{
   public class PatientAccount : RegisteredUser
   {
      public bool IsGuest { get; set; }
      public int HealthCardId { get; set; }
      public String Allergies { get; set; }

        public PatientAccount(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password, bool isGuest, int healthCardId, string allergies) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password)
        {
            this.IsGuest = isGuest;
            this.HealthCardId = healthCardId;
            this.Allergies = allergies;
        }
    }
}