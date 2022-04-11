using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class RoomRepository
   {
        ObservableCollection<Room> rooms;
        public RoomRepository()
     {
          roomFileHandler = new FileHandler.RoomFileHandler();
          rooms = new ObservableCollection<Room>();
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

        public ref ObservableCollection<Room> GetAll()
      {
            if (roomFileHandler.Read() == null)
                return ref rooms;
            rooms.Clear();
            List<Room> list = roomFileHandler.Read();

            foreach (Room r in list)
            { rooms.Add(r); }

            return ref rooms;
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
            foreach (Room rs in rooms)
            {
                if (rs.Id.Equals(id))
                {
                    rs.Id = id;
                    rs.Floor = floor;
                    rs.Name = name;
                    rs.RoomType = roomType;
                    rs.Availability = availability;
                    roomFileHandler.Write(rooms.ToList());

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
      
     // public List<Room> rooms;
      
      public FileHandler.RoomFileHandler roomFileHandler;
   
   }
}