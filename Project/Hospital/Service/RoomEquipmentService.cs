using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class RoomEquipmentService
   {
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
      
      public bool Edit(Room room, Equipment equipment, int quantity, int id)
      {
            return roomEquipmentRepository.Edit(room, equipment, quantity, id);
      }
      
      public bool Create(Room room, Equipment equipment, int quantity, int id)
      {
            foreach (RoomEquipment e in roomEquipmentRepository.GetAll())
            {
                if (e.Room.Id.Equals(room.Id) && e.Equipment.Id.Equals(equipment.Id))
                {
                    int pom = e.Quantity + quantity;
                    return roomEquipmentRepository.Edit(room, equipment, pom, e.Id);
                }
            }
            int ids = roomEquipmentRepository.GetAll().Count() == 0 ? 0 : roomEquipmentRepository.GetAll().Max(RoomEquipment => RoomEquipment.Id);
            return roomEquipmentRepository.Create(room, equipment, quantity, ++ids); 
      }
      
      public bool MoveEquipment(EquipmentTransfer equipmentTransfer)
      {
            return roomEquipmentRepository.MoveEquipment(equipmentTransfer);
      }
      
      public Repository.RoomEquipmentRepository roomEquipmentRepository;
   
   }
}