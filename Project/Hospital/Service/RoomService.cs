using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return roomRepository.GetById(id);
      }
      
      public List<Room> GetAll()
      {
            return roomRepository.GetAll();
      }
      
      public bool DeleteRoom(int id)
      {
            return roomRepository.DeleteRoom(id);
      }
      
      public bool EditRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            return roomRepository.EditRoom(floor,name,id,availability,roomType);
      }
      
      public bool CreateRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            int ids = roomRepository.GetAll().Count() == 0 ? 0 : roomRepository.GetAll().Max(Room => Room.Id);

            return roomRepository.CreateRoom(floor,name,++ids,availability,roomType);
      }
      
      public Repository.RoomRepository roomRepository;
   
   }
}