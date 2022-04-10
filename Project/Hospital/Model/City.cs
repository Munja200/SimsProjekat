using System;

namespace Model
{
   public class City
   {
      public String name;
      
      public Country country;
      
      
      public Country Country
      {
         get
         {
            return country;
         }
         set
         {
            this.country = value;
         }
      }
   
   }
}