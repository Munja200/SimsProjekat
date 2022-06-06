using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class EquipmentTransferController
   {
        public EquipmentTransferService equipmentTransferService;
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
      
        public bool Edit(EquipmentTransfer equipmentTransfer)
        {
            return equipmentTransferService.Edit(equipmentTransfer);
        }
      
        public bool Create(EquipmentTransfer equipmentTransfer)
        {
            return equipmentTransferService.Create(equipmentTransfer);
        } 
   }
}