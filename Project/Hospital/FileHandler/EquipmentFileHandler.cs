using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class EquipmentFileHandler
   {
        public readonly String path = @"../../Resources/Equipment.txt";
        public void Write(List<Equipment> equipments)
        {
            foreach (Equipment equipment in equipments) { equipment.Serialize = true; }
            string serializedEquimpent = Newtonsoft.Json.JsonConvert.SerializeObject(equipments);
            System.IO.File.WriteAllText(path, serializedEquimpent);
        }

        public List<Equipment> Read()
        {
            string serializedEquipment = System.IO.File.ReadAllText(path);
            List<Equipment> equipments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Equipment>>(serializedEquipment);
            return equipments;
        }
    }
}