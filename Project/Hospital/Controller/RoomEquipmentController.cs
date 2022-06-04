using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
    public class RoomEquipmentController
    {
        public RoomEquipmentController(RoomEquipmentService roomEquipmentService)
        {
            this.roomEquipmentService = roomEquipmentService;
        }
        public List<RoomEquipment> GetByRoomId(int id)
        {
            return roomEquipmentService.GetByRoomId(id);
        }

        public List<RoomEquipment> GetByEquipmentId(int id)
        {
            return roomEquipmentService.GetByEquipmentId(id);
        }
        public List<RoomEquipment> GetByEquipmentIdAndQuantity(int equipmentId, int minQuantity, int maxQuantity)
        {
            return roomEquipmentService.GetByEquipmentIdAndQuantity(equipmentId, minQuantity, maxQuantity);
        }

        public List<RoomEquipment> GetAll()
        {
            return roomEquipmentService.GetAll();
        }

        public RoomEquipment GetByIds(int idRoom, int idEquipment)
        {
            return roomEquipmentService.GetByIds(idRoom, idEquipment);
        }

        public RoomEquipment GetById(int id)
        {
            return roomEquipmentService.GetById(id);
        }

        public bool DeleteByRoomId(int id)
        {
            return roomEquipmentService.DeleteByRoomId(id);
        }

        public bool DeleteByEquipmentId(int id)
        {
            return roomEquipmentService.DeleteByEquipmentId(id);
        }

        public bool DeleteById(int id)
        {
            return roomEquipmentService.DeleteById(id);
        }

        public bool Edit(Room room, Equipment equipment, int quantity, int id)
        {
            return roomEquipmentService.Edit(room, equipment, quantity, id);
        }

        public bool Create(Room room, Equipment equipment, int quantity, int id)
        {
            return roomEquipmentService.Create(room, equipment, quantity, id);
        }

        public bool MoveEquipment(EquipmentTransfer equipmentTransfer)
        {
            return roomEquipmentService.MoveEquipment(equipmentTransfer);
        }

        public Service.RoomEquipmentService roomEquipmentService;

    }
}