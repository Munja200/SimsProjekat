using System;
using System.Collections.Generic;
using Model;

namespace Hospital.Model
{
    public class Drug
    {
        public int Id { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<String> Replacements { get; set; }
        public Equipment Equipment { get; set; }

        public string Using { get; set; }
        public bool IsNotValid { get; set; }
        public string ReasonForInvalidity { get; set; }


        [Newtonsoft.Json.JsonConstructor]
        public Drug(List<Ingredient> ingredients, int id, Equipment equipment, List<String> replacements, string @using, bool isValid, string reasonForInvalidity)
        {
            this.Ingredients = ingredients;
            this.Id = id;
            this.Equipment = equipment;
            this.Replacements = replacements;
            this.Using = @using;
            this.IsNotValid = isValid;
            this.ReasonForInvalidity = reasonForInvalidity;
        }

        public Drug(int id, string name, string @using, bool isValid, string reasonForInvalidity)
        {
            Id = id;
            Using = @using;
            IsNotValid = isValid;
            ReasonForInvalidity = reasonForInvalidity;
        }

        public bool ShouldSerializeEquipment()
        {
            if (this.Equipment != null)
                this.Equipment.serialize = false;
            return true;
        }


    }
}
