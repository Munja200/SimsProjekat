using Hospital.Util;
using Hospital.View;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class RoomRepository
   {
        public FileHandler.RoomFileHandler roomFileHandler;
        MTObservableCollection<Room> rooms;
        public RoomRepository()
        {
          roomFileHandler = new FileHandler.RoomFileHandler();

          rooms = new MTObservableCollection<Room>();
          this.GetAll();
        }
        public Room GetById(int id)
        {
            foreach (Room room in rooms)
            {
                if (room.Id.Equals(id))
                    return room;
            }
            return null;
        }

        public ref MTObservableCollection<Room> GetAll()
        {
            if (roomFileHandler.Read() == null)
                return ref rooms;
            rooms.Clear();
            List<Room> list = roomFileHandler.Read();

            foreach (Room room in list)
                rooms.Add(room); 

            return ref rooms;
        }

        public List<Room> GetAllByFloor(int floor)
        {
            List<Room> list = new List<Room>();

            foreach (Room room in rooms)
            {
                if (room.Floor == floor && room.RoomType != RoomType.storage)
                    list.Add(room);
            }
            return list;
        }

        public bool DeleteRoom(int id)
        {
            foreach (Room room in rooms)
            {
                if (room.Id.Equals(id))
                {
                    rooms.Remove(room);
                    roomFileHandler.Write(rooms.ToList());
                    return true;
                }
            }
            return false;
        }
      
        public bool EditRoom(Room room)
        {
            foreach (Room newRoom in rooms)
            {
                if (newRoom.Id.Equals(room.Id))
                {
                    SetRoomValue(newRoom,room);
                    return true;
                }
            }

            return false;
        }

        private void SetRoomValue(Room newRoom, Room room) {
            newRoom.Id = room.Id;
            newRoom.Floor = room.Floor;
            newRoom.Name = room.Name;
            newRoom.RoomType = room.RoomType;
            newRoom.Availability = room.Availability;
            roomFileHandler.Write(rooms.ToList());
            this.GetAll();

        }

        public bool CreateRoom(Room room)
        {  
            rooms.Add(room);
            roomFileHandler.Write(rooms.ToList());
            return true;
        }   
   }
}