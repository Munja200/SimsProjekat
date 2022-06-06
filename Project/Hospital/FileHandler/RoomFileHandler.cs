using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class RoomFileHandler
   {
        private readonly string path = @"../../Resources/Room.txt";


        public List<Room> Read()
        {
            string serializedRooms = System.IO.File.ReadAllText(path);
            List<Room> rooms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Room>>(serializedRooms);
            return rooms;
        }

        public void Write(List<Room> rooms)
        {
            foreach (Room room in rooms)  room.Serialize = true; 
            string serializedRooms = Newtonsoft.Json.JsonConvert.SerializeObject(rooms);
            System.IO.File.WriteAllText(path, serializedRooms);
        }
    }
}