using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class RoomRepository
   {
     public RoomRepository()
     {
          roomFileHandler = new FileHandler.RoomFileHandler();
          rooms = new List<Room>();
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
      
      public List<Room> GetAll()
      {
            if (roomFileHandler.Read() == null)
                return rooms;

            foreach (Room room in roomFileHandler.Read())
            {
                rooms.Add(room);
            }
            return rooms;
        }
      
      public bool DeleteRoom(int id)
      {
            foreach (Room room in rooms)
            {
                if (room.Id.Equals(id))
                {
                    rooms.Remove(room);
                    roomFileHandler.Write(rooms);
                    return true;
                }
            }
            return false;
        }
      
      public bool EditRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            foreach (Room rs in rooms)
            {
                if (rs.Id.Equals(id))
                {
                    rs.Id = id;
                    rs.Floor = floor;
                    rs.Name = name;
                    rs.RoomType = roomType;
                    rs.Availability = availability;
                    roomFileHandler.Write(rooms);

                    return true;
                }
            }

            return false;
        }
      
      public bool CreateRoom(int floor, String name, int id, bool availability, RoomType roomType)
      {
            rooms.Add(new Room(id, floor, roomType, name, availability));
            roomFileHandler.Write(rooms);
            return true;
        }
      
      public List<Room> rooms;
      
      public FileHandler.RoomFileHandler roomFileHandler;
   
   }
}