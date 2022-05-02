using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class EquipmentTransferService
   {
      public EquipmentTransferService(EquipmentTransferRepository equipmentTransferRepository)
      {
          this.equipmentTransferRepository = equipmentTransferRepository;
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
            
       
                return equipmentTransferRepository.Create(senderRoom, recipientRoom, equipment, quantity, scheduledDate, id);
      }

        public Repository.EquipmentTransferRepository equipmentTransferRepository;
   
   }
}