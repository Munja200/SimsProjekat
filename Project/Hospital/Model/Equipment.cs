using System;

namespace Model
{
   public class Equipment
   {
      public Equipment(int id, String name, String manufacturer, int quantity, String description, Medicine medicine) 
      {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            Description = description;
            Medicine = medicine;
      }
      public int Id { get; set; }
      public String Name { get; set; }
      public String Manufacturer { get; set; }
      public int Quantity { get; set; }
      public String Description { get; set; }
      
      public Medicine Medicine { get; set; }
   
   }
}