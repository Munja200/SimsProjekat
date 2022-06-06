using System;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace Model
{
   public class Room
   {
        [Newtonsoft.Json.JsonConstructor]
        public Room(int id, int floor, RoomType roomType, String name, bool availability)
        {
            Id = id;
            Floor = floor;
            RoomType = roomType;
            Name = name;
            Availability = availability;
        }

        public Room()
        {
        }

        public int Floor { get; set; }
        public String Name { get; set; }
        public int Id { get; set; }
        public bool Availability { get; set; }
        public RoomType RoomType { get; set; }
        public bool Serialize { get; set; }
        public bool ShouldSerializeSerialize()
        {
            this.Serialize = true;
            return false;
        }
        public bool ShouldSerializeFloor() { return Serialize; }
        public bool ShouldSerializeRoomType() { return Serialize; }
        public bool ShouldSerializeName() { return Serialize; }
        public bool ShouldSerializeAvailability() { return Serialize; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Room);
        }

        public bool Equals(Room other)
        {
            return other != null &&
                   Id == other.Id;
        }
    }
}