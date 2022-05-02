using System;

namespace Model
{
   public class Medicine
   {
      public Medicine(String allergies)
      {
            Allergies = allergies;
      }
      public String Allergies { get; set; }
   
   }
}