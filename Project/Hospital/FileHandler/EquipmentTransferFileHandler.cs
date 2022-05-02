using Model;
using System;
using System.Collections.Generic;

namespace FileHandler
{
   public class EquipmentTransferFileHandler
   {
      public void Write(List<EquipmentTransfer> equipmentTransfers)
      {
            string serializedEquipmentTransfer = Newtonsoft.Json.JsonConvert.SerializeObject(equipmentTransfers);
            System.IO.File.WriteAllText(path, serializedEquipmentTransfer);
        }

        public List<EquipmentTransfer> Read()
      {
            string serializedEquipmentTransfer = System.IO.File.ReadAllText(path);
            List<EquipmentTransfer> equipmentTransfers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EquipmentTransfer>>(serializedEquipmentTransfer);
            return equipmentTransfers;
        }

        public readonly String path = @"../../Resources/EquipmentTransfer.txt";

    }
}