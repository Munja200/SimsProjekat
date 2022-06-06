using Hospital.Util;
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
        public RoomRepository roomRepository;

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
            if (roomRepository.GetById(id).RoomType.Equals(RoomType.storage))
                return false;
            
            return roomRepository.DeleteRoom(id);
        }
      
        public bool EditRoom(Room room)
        {
            if (roomRepository.GetById(room.Id).RoomType.Equals(RoomType.storage))
                return false;

            return roomRepository.EditRoom(room);
        }

        public bool EditRoomAvailability(Room room, bool newAvailability)
        {
            room.Availability = newAvailability;
            return this.EditRoom(room);
        }


        public bool CreateRoom(Room room)
        {
            bool indicator = IsStorageExist();

            if (room.RoomType.Equals(RoomType.storage) && indicator)
                return false;

            room.Id = GenerateRoomId();
            return roomRepository.CreateRoom(room);
        }

        private bool IsStorageExist() {
            foreach (Room newRoom in roomRepository.GetAll())
            {
                if (newRoom.RoomType.Equals(RoomType.storage))
                    return  true;
            }
            return false;
        }

        private int GenerateRoomId() {
            int id = roomRepository.GetAll().Count() == 0 ? 0 : roomRepository.GetAll().Max(Room => Room.Id);
            return ++id;
        }
    }
}