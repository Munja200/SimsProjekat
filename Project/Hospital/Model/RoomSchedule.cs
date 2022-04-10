using System;

namespace Model
{
   public class RoomSchedule
   {
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
      public int RoomId { get; set; }

      public RoomSchedule(DateTime startTime, DateTime endTime, int roomId)
      {
          StartTime = startTime;
          EndTime = endTime;
          RoomId = roomId;
      }
    }
}