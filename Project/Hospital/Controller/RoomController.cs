using Model;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomController
   {
      public Room GetById(int id)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteRoom(int id)
      {
         throw new NotImplementedException();
      }
      
      public bool EditRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
         throw new NotImplementedException();
      }
      
      public bool CreateRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
         throw new NotImplementedException();
      }
      
      public Service.RoomService roomService;
   
   }
}