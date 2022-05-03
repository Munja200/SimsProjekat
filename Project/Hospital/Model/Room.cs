using System;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace Model
{
   public class Room
   {
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

        public bool serialize { get; set; }

        public bool ShouldSerializeserialize()
        {
            this.serialize = true;
            return false;
        }
        public bool ShouldSerializeFloor() { return serialize; }
        public bool ShouldSerializeRoomType() { return serialize; }
        public bool ShouldSerializeName() { return serialize; }
        public bool ShouldSerializeAvailability() { return serialize; }

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