using System;
using System.Collections.Generic;
using Hospital.Model;

namespace Model
{
    public class PatientAccount : RegisteredUser
    {
        public bool IsGuest { get; set; }
        public int HealthCardId { get; set; }
        public List<Allergy> DrugAllergies { get; set; }
        public List<Ingredient> IngredientsAllergies { get; set; }

        public PatientAccount(String name, String surname, int citizenId, Gender gender, DateTime dateOfBirth, String email, String phoneNumber, Address address, String username, String password, bool isGuest, int healthCardId, List<Allergy> drugAllergies, List<Ingredient> ingredientAllergies) : base(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password)
        {
            this.IsGuest = isGuest;
            this.HealthCardId = healthCardId;
            this.DrugAllergies = drugAllergies;
            this.IngredientsAllergies = ingredientAllergies;
        }

        public bool serialize { get; set; }

        public bool ShouldSerializeserialize()
        {
            this.serialize = true;
            return false;
        }
        public bool ShouldSerializeIsGuest() { return serialize; }
        public bool ShouldSerializeHealthCardId() { return serialize; }
        public bool ShouldSerializeDrugAllergies() { return serialize; }
        public bool ShouldSerializeIngredientsAllergies() { return serialize; }

        public override string ToString()
        {
            return Name + " " + Surname + ", " + PhoneNumber + ", " + Address;
        }

    }
}