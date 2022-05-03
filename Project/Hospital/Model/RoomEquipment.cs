using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Model
{
   public class RoomEquipment
   {
      public RoomEquipment(Room room, Equipment equipment, int quantity, int id) 
      {
            Quantity = quantity;
            Id = id;
            Equipment = equipment;
            Room = room;
      }
      public int Quantity { get; set; }
      public int Id { get; set; }
      
      public Equipment Equipment { get; set; }

      public Room Room { get; set; }
        public bool ShouldSerializeRoom()
        {
            this.Room.serialize = false;
            return true;
        }

        public bool ShouldSerializeEquipment()
        {
            this.Equipment.serialize = false;
            return true;
        }

    }
}