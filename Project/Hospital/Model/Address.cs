using System;

namespace Model
{
   public class Address
   {
      public String streetName;
      public String number;
      
      public City city;
      
      
      public City City
      {
         get
         {
            return city;
         }
         set
         {
            this.city = value;
         }
      }
   
   }
}