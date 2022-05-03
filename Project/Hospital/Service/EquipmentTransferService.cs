using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class EquipmentTransferService
   {
        private RoomEquipmentRepository roomEquipmentRepository;

        public EquipmentTransferService(EquipmentTransferRepository equipmentTransferRepository, RoomEquipmentRepository roomEquipmentRepository)
      {
          this.equipmentTransferRepository = equipmentTransferRepository;
          this.roomEquipmentRepository = roomEquipmentRepository;
        }
        public EquipmentTransfer GetById(int id)
      {
            return equipmentTransferRepository.GetById(id);
      }
      
      public List<EquipmentTransfer> GetAll()
      {
            return equipmentTransferRepository.GetAll();     
      }
      
      public bool Delete(int id)
      {
            return equipmentTransferRepository.Delete(id);
      }
      
      public bool Edit(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id)
      {
            return equipmentTransferRepository.Edit(senderRoom, recipientRoom, equipment, quantity, scheduledDate, id);
      }

      public bool Create(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id)
      {
            if (senderRoom.Id.Equals(recipientRoom.Id))
            {
                return false;
            }

            if (DateTime.Compare(scheduledDate, DateTime.Today) < 0)
            {
                return false;
            }

            if (DateTime.Compare(scheduledDate, DateTime.Today) == 0)
            {
                return roomEquipmentRepository.MoveEquipment(new EquipmentTransfer(senderRoom, recipientRoom, equipment, quantity, scheduledDate, 0));
            }



            return equipmentTransferRepository.Create(senderRoom, recipientRoom, equipment, quantity, scheduledDate, id);
      }

        public Repository.EquipmentTransferRepository equipmentTransferRepository;
   
   }
}