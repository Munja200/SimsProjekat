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

        [JsonIgnore]
        public System.Collections.Generic.List<RoomSchedule> roomSchedule;
      
      public System.Collections.Generic.List<RoomSchedule> RoomSchedule
      {
         get
         {
            if (roomSchedule == null)
               roomSchedule = new System.Collections.Generic.List<RoomSchedule>();
            return roomSchedule;
         }
         set
         {
            RemoveAllRoomSchedule();
            if (value != null)
            {
               foreach (RoomSchedule oRoomSchedule in value)
                  AddRoomSchedule(oRoomSchedule);
            }
         }
      }
      
      
      public void AddRoomSchedule(RoomSchedule newRoomSchedule)
      {
         if (newRoomSchedule == null)
            return;
         if (this.roomSchedule == null)
            this.roomSchedule = new System.Collections.Generic.List<RoomSchedule>();
         if (!this.roomSchedule.Contains(newRoomSchedule))
            this.roomSchedule.Add(newRoomSchedule);
      }
      
      
      public void RemoveRoomSchedule(RoomSchedule oldRoomSchedule)
      {
         if (oldRoomSchedule == null)
            return;
         if (this.roomSchedule != null)
            if (this.roomSchedule.Contains(oldRoomSchedule))
               this.roomSchedule.Remove(oldRoomSchedule);
      }
      
      
      public void RemoveAllRoomSchedule()
      {
         if (roomSchedule != null)
            roomSchedule.Clear();
      }

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