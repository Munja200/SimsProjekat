using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class RoomEquipmentService
   {

        public RoomEquipmentRepository roomEquipmentRepository;
        public RoomEquipmentService(RoomEquipmentRepository roomEquipmentRepository)
        {
           this.roomEquipmentRepository = roomEquipmentRepository;
        }
        public List<RoomEquipment> GetByRoomId(int id)
        {
          return roomEquipmentRepository.GetByRoomId(id);
        }
      
        public List<RoomEquipment> GetByEquipmentId(int id)
        {
            return roomEquipmentRepository.GetByEquipmentId(id);
        }

        public List<RoomEquipment> GetByEquipmentIdAndQuantity(int equipmentId, int minQuantity, int maxQuantity)
        {
            return roomEquipmentRepository.GetByEquipmentIdAndQuantity(equipmentId, minQuantity, maxQuantity);
        }

        public List<RoomEquipment> GetAll()
        {
            return roomEquipmentRepository.GetAll();
        }
      
        public RoomEquipment GetByIds(int idRoom, int idEquipment)
        {
            return roomEquipmentRepository.GetByIds(idRoom, idEquipment);
        }
      
        public RoomEquipment GetById(int id)
        {
            return roomEquipmentRepository.GetById(id);
        }
      
        public bool DeleteByRoomId(int id)
        {
            return roomEquipmentRepository.DeleteByRoomId(id);
        }
      
        public bool DeleteByEquipmentId(int id)
        {
            return roomEquipmentRepository.DeleteByEquipmentId(id);
        }
      
        public bool DeleteById(int id)
        {
            return roomEquipmentRepository.DeleteById(id);
        }
      
        public bool Edit(RoomEquipment roomEquipment)
        {
            return roomEquipmentRepository.Edit(roomEquipment);
        }
      
        public bool Create(RoomEquipment roomEquipment)
        {
            foreach (RoomEquipment newRoomEquipment in roomEquipmentRepository.GetAll())
            {
                if (newRoomEquipment.Room.Id.Equals(roomEquipment.Room.Id) && newRoomEquipment.Equipment.Id.Equals(roomEquipment.Equipment.Id))
                {
                    int pom = newRoomEquipment.Quantity + roomEquipment.Quantity;
                    return roomEquipmentRepository.Edit(new RoomEquipment(roomEquipment.Room, roomEquipment.Equipment, pom, newRoomEquipment.Id));
                }
            }
            roomEquipment.Id = GenerateRoomEquipmentId();
            return roomEquipmentRepository.Create(roomEquipment); 
        }

        private int GenerateRoomEquipmentId() {
            int id = roomEquipmentRepository.GetAll().Count() == 0 ? 0 : roomEquipmentRepository.GetAll().Max(RoomEquipment => RoomEquipment.Id);
            return ++id;
        }
      
        public bool MoveEquipment(EquipmentTransfer equipmentTransfer)
        {
            return roomEquipmentRepository.MoveEquipment(equipmentTransfer);
        }   
   }
}