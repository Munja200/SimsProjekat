using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class EquipmentTransferController
   {
        public EquipmentTransferController(EquipmentTransferService equipmentTransferService) 
        {
            this.equipmentTransferService = equipmentTransferService; 
        }
      public EquipmentTransfer GetById(int id)
      {
            return equipmentTransferService.GetById(id);
      }

        public List<EquipmentTransfer> GetAll()
      {
            return equipmentTransferService.GetAll();
      }
      
      public bool Delete(int id)
      {
            return equipmentTransferService.Delete(id);
      }
      
      public bool Edit(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id)
      {
            return equipmentTransferService.Edit(senderRoom, recipientRoom, equipment, quantity, scheduledDate, id);
      }
      
      public bool Create(Room senderRoom, Room recipientRoom, Equipment equipment, int quantity, DateTime scheduledDate, int id)
      {
            return equipmentTransferService.Create(senderRoom,recipientRoom,equipment,quantity,scheduledDate,id);
      }
      
      public Service.EquipmentTransferService equipmentTransferService;
   
   }
}