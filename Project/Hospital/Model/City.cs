using System;

namespace Model
{
   public class City
   {
      public String name { get; set; }
      
      public Country country;

        public City(string name, Country country)
        {
            this.name = name;
            this.country = country;
        }

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