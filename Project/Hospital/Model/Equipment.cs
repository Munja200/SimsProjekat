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

        public bool Serialize { get; set; }

        public bool ShouldSerializeName() { return Serialize; }
        public bool ShouldSerializeManufacturer() { return Serialize; }

        public bool ShouldSerializeQuantity() { return Serialize; }
        public bool ShouldSerializeDescription() { return Serialize; }
        public bool ShouldSerializeMedicine() { return Serialize; }
        public bool ShouldSerializeSerialize() { return false; }

    }
}