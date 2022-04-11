using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomController
   {
      public RoomController(RoomService roomService)
      {
            this.roomService = roomService;
      }

      public Room GetById(int id)
      {
            return roomService.GetById(id);
      }
      
      public List<Room> GetAll()
      {
            return roomService.GetAll();
      }
      
      public bool DeleteRoom(int id)
      {
            if (roomService.GetById(id).RoomType.Equals(RoomType.storage)) 
            {
                return false;
            }
            return roomService.DeleteRoom(id);
      }
      
      public bool EditRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            if (roomService.GetById(id).RoomType.Equals(RoomType.storage))
            {
                return false;
            }
            return roomService.EditRoom(floor,name,id,availability,roomType);
        }
      
      public bool CreateRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            bool indicator = false;
            foreach (Room room in roomService.GetAll()) {
                if (room.RoomType.Equals(RoomType.storage))
                    indicator = true;
            }
            
            if (roomType.Equals(RoomType.storage) && indicator)
            {
                return false;
            }
          
            return roomService.CreateRoom(floor,name,id,availability,roomType);
      }
      
      public Service.RoomService roomService;
   
   }
}