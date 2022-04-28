using System;

namespace Model
{
   public class Address
   {
      public String StreetName { get; set; }
      public String Number { get; set; }
      
      public City city;

        public Address(string streetName, string number, City city)
        {
            this.StreetName = streetName;
            this.Number = number;
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

        public override string ToString()
        {
            return StreetName + " " + Number + ", " + city.name + ", " + city.country.name;
        }
    }
}