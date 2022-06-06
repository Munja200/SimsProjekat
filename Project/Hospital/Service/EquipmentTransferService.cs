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
        public Repository.EquipmentTransferRepository equipmentTransferRepository;

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
      
        public bool Edit(EquipmentTransfer equipmentTransfer)
        {
            return equipmentTransferRepository.Edit(equipmentTransfer);
        }

        public bool Create(EquipmentTransfer equipmentTransfer)
        {
            if (equipmentTransfer.SenderRoom.Id.Equals(equipmentTransfer.RecipientRoom.Id) ||
                DateTime.Compare(equipmentTransfer.SheduledDate, DateTime.Today) < 0)
                return false;

            if (DateTime.Compare(equipmentTransfer.SheduledDate, DateTime.Today) == 0)
                return roomEquipmentRepository.MoveEquipment(equipmentTransfer);

            equipmentTransfer.Id = GenerateEquipmentTransferId();
            return equipmentTransferRepository.Create(equipmentTransfer);
        }
        private int GenerateEquipmentTransferId() {
            int id = equipmentTransferRepository.GetAll().Count() == 0 ? 0 : equipmentTransferRepository.GetAll().Max(EquipmentTransfer => EquipmentTransfer.Id);
            return ++id;
        }
   }
}