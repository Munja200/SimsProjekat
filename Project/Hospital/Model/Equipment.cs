using System;

namespace Model
{
    public class Equipment
    {
        public Equipment(int id, String name, String manufacturer, int quantity, String description)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            Quantity = quantity;
            Description = description;
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }

        public bool serialize { get; set; }

        public bool ShouldSerializeName() { return serialize; }
        public bool ShouldSerializeManufacturer() { return serialize; }

        public bool ShouldSerializeQuantity() { return serialize; }
        public bool ShouldSerializeDescription() { return serialize; }
        public bool ShouldSerializeMedicine() { return serialize; }
        public bool ShouldSerializeserialize() { return false; }

    }
}