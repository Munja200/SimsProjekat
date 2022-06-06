using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace FileHandler
{
    public class RoomEquipmentFileHandler
   {
        public readonly String path = @"../../Resources/RoomEquipment.txt";
        public void Write(List<RoomEquipment> roomEquipments)
        {
            string serializedRoomEquipment = Newtonsoft.Json.JsonConvert.SerializeObject(roomEquipments);
            System.IO.File.WriteAllText(path, serializedRoomEquipment);
        }

        public List<RoomEquipment> Read()
        {
            string serializedRoomsEquimpent = System.IO.File.ReadAllText(path);
            List<RoomEquipment> roomsEquimpent = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoomEquipment>>(serializedRoomsEquimpent);
            return roomsEquimpent;
        }
    }
}