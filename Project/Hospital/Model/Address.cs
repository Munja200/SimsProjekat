using System;

namespace Model
{
   public class Address
   {
      public String streetName { get; set; }
      public String number { get; set; }
      
      public City city;

        public Address(string streetName, string number, City city)
        {
            this.streetName = streetName;
            this.number = number;
            this.city = city;
        }

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