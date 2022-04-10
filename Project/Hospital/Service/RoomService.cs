using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class RoomService
   {
      public RoomService(RoomRepository roomRepository) 
      {
            this.roomRepository = roomRepository;
      }
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
      
      public Repository.RoomRepository roomRepository;
   
   }
}