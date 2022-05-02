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
   
    }
}