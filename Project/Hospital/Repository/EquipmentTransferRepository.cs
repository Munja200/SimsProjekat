using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class EquipmentTransferRepository
   {
        public List<EquipmentTransfer> equipmentTransfers;
        public EquipmentTransferRepository()
        {
            equipmentTransferFileHandler = new FileHandler.EquipmentTransferFileHandler();
            equipmentTransfers = new List<EquipmentTransfer>();
        }


        public EquipmentTransfer GetById(int id)
      {
            foreach (EquipmentTransfer et in equipmentTransfers)
            {
                if (et.Id.Equals(id))
                    return et;
            }
            return null;
        }
      
      public List<EquipmentTransfer> GetAll()
      {
            equipmentTransfers = equipmentTransferFileHandler.Read();
            return equipmentTransfers;
        }
      
      public bool Delete(int id)
      {
            foreach (EquipmentTransfer et in equipmentTransfers)
            {
                if (et.Id.Equals(id))
                {
                    equipmentTransfers.Remove(et);
                    equipmentTransferFileHandler.Write(equipmentTransfers);
                    return true;
                }
            }
            return false;
        }
      
      public bool Edit(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id)
      {
            foreach (EquipmentTransfer et in equipmentTransfers)
            {
                if (et.Id.Equals(id))
                {
                    et.Id = id;
                    et.SenderRoom = senderRoom;
                    et.RecipientRoom = recipientRoom;
                    et.Equipment = equipment;
                    et.Quantity = quantity;
                    et.SheduledDate = scheduledDate;
                    equipmentTransferFileHandler.Write(equipmentTransfers);

                    return true;
                }
            }

            return false;
        }
      
      public bool Create(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id)
      {
            equipmentTransfers.Add(new EquipmentTransfer(senderRoom,recipientRoom,equipment,quantity,scheduledDate,id)) ;
            equipmentTransferFileHandler.Write(equipmentTransfers);
            return true;
        }
      
      public FileHandler.EquipmentTransferFileHandler equipmentTransferFileHandler;
   
   }
}