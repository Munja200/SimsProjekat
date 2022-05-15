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
            { rooms.Add(room); }

            return ref rooms;
        }

        public List<Room> GetAllByFloor(int floor)
        {

            List<Room> list = new List<Room>();

            foreach (Room room in rooms)
            {
                if (room.Floor == floor && room.RoomType != RoomType.storage)
                {
                    list.Add(room);
                }
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
      
      public bool EditRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            foreach (Room newRoom in rooms)
            {
                if (newRoom.Id.Equals(id))
                {
                    newRoom.Id = id;
                    newRoom.Floor = floor;
                    newRoom.Name = name;
                    newRoom.RoomType = roomType;
                    newRoom.Availability = availability;
                    roomFileHandler.Write(rooms.ToList());
                    this.GetAll();
                    return true;
                }
            }

            return false;
        }
      
      public bool CreateRoom(int floor, String name, int id, bool availability, RoomType roomType)
      { 

            rooms.Add(new Room(id, floor, roomType, name, availability));
            roomFileHandler.Write(rooms.ToList());
            return true;
      }
      
      public FileHandler.RoomFileHandler roomFileHandler;
   
   }
}