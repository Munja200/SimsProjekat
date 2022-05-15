using Hospital.View;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ref MTObservableCollection<Room> GetAll()
      {
            return ref roomRepository.GetAll();
      }

        public List<Room> GetAllByFloor(int floor)
        {
            return roomRepository.GetAllByFloor(floor);
        }

        public bool DeleteRoom(int id)
      {
            return roomRepository.DeleteRoom(id);
      }
      
      public bool EditRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            return roomRepository.EditRoom(floor,name,id,availability,roomType);
      }

        public bool EditRoomAvailability(Room room, bool newAvailability)
        {

            return this.EditRoom(room.Floor, room.Name, room.Id, newAvailability, room.RoomType);
        }


        public bool CreateRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            int ids = roomRepository.GetAll().Count() == 0 ? 0 : roomRepository.GetAll().Max(Room => Room.Id);

            return roomRepository.CreateRoom(floor,name,++ids,availability,roomType);
      }
      
      public Repository.RoomRepository roomRepository;
   
   }
}