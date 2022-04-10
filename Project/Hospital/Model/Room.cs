using System;

namespace Model
{
   public class Room
   {
      public int floor;
      public String name;
      public int id;
      public bool availability;
      public RoomType roomType;
      
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
   
   }
}