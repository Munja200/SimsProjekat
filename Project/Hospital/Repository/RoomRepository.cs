using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class RoomRepository
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
      
      public List<Room> rooms;
      
      public FileHandler.RoomFileHandler roomFileHandler;
   
   }
}