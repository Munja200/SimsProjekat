using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class EquipmentFileHandler
   {
      public void Write(List<Equipment> equipments)
      {
            string serializedEquimpent = Newtonsoft.Json.JsonConvert.SerializeObject(equipments);
            System.IO.File.WriteAllText(path, serializedEquimpent);
        }

        public List<Equipment> Read()
      {
            string serializedEquipment = System.IO.File.ReadAllText(path);
            List<Equipment> equipment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Equipment>>(serializedEquipment);
            return equipment;
        }

         public readonly String path = @"../../Resources/Equipment.txt";


    }
}