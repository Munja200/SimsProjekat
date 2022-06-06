using FileHandler;
using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class EquipmentTransferRepository
   {
        public List<EquipmentTransfer> equipmentTransfers;
        public EquipmentTransferFileHandler equipmentTransferFileHandler;

        public EquipmentTransferRepository()
        {
            equipmentTransferFileHandler = new FileHandler.EquipmentTransferFileHandler();
            equipmentTransfers = new List<EquipmentTransfer>();
        }


        public EquipmentTransfer GetById(int id)
        {
            foreach (EquipmentTransfer equipmentTransfer in equipmentTransfers)
            {
                if (equipmentTransfer.Id.Equals(id))
                    return equipmentTransfer;
            }
            return null;
        }
        
        public List<EquipmentTransfer> GetAll()
        {
            if (equipmentTransferFileHandler.Read() == null)
                return equipmentTransfers;

            equipmentTransfers.Clear();
            SetEquipmentAndRooms();
                
            return equipmentTransfers;
        }

        private void SetEquipmentAndRooms() {
            RoomRepository roomRepository = new RoomRepository();
            EquipmentRepository equipmentRepository = new EquipmentRepository();
            equipmentRepository.GetAll();
            roomRepository.GetAll();

            foreach (EquipmentTransfer et in equipmentTransferFileHandler.Read())
            {
                et.RecipientRoom = roomRepository.GetById(et.RecipientRoom.Id);
                et.SenderRoom = roomRepository.GetById(et.SenderRoom.Id);
                et.Equipment = equipmentRepository.GetById(et.Equipment.Id);
                equipmentTransfers.Add(et);
            }
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
      
        public bool Edit(EquipmentTransfer equipmentTransfer)
        {
            foreach (EquipmentTransfer newEquipmentTransfer in equipmentTransfers)
            {
                if (newEquipmentTransfer.Id.Equals(equipmentTransfer.Id))
                {
                    SetEquipmentTransferValue(newEquipmentTransfer, equipmentTransfer);
                    return true;
                }
            }
            return false;
        }

        private void SetEquipmentTransferValue(EquipmentTransfer newEquipmentTransfer, EquipmentTransfer equipmentTransfer) {
            newEquipmentTransfer.Id = equipmentTransfer.Id;
            newEquipmentTransfer.SenderRoom = equipmentTransfer.SenderRoom;
            newEquipmentTransfer.RecipientRoom = equipmentTransfer.RecipientRoom;
            newEquipmentTransfer.Equipment = equipmentTransfer.Equipment;
            newEquipmentTransfer.Quantity = equipmentTransfer.Quantity;
            newEquipmentTransfer.SheduledDate = equipmentTransfer.SheduledDate;
            equipmentTransferFileHandler.Write(equipmentTransfers);
        }
      
        public bool Create(EquipmentTransfer equipmentTransfer)
        {
            equipmentTransfers.Add(equipmentTransfer);
            equipmentTransferFileHandler.Write(equipmentTransfers);
            return true;
        }   
   }
}