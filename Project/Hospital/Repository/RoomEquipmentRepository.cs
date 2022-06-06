using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class RoomEquipmentRepository
    {
        public List<RoomEquipment> roomEquipments;
        public FileHandler.RoomEquipmentFileHandler roomEquipmentFileHandler;

        public RoomEquipmentRepository()
        {
          roomEquipmentFileHandler = new FileHandler.RoomEquipmentFileHandler();
          roomEquipments = new List<RoomEquipment>();
          this.GetAll();
        }

        public List<RoomEquipment> GetByRoomId(int id)
        {
            List<RoomEquipment> pom = new List<RoomEquipment>();
          
            foreach (RoomEquipment roomEquipment in roomEquipments)
            {
                if (roomEquipment.Room.Id.Equals(id))
                    pom.Add(roomEquipment);
            }
            return pom;
        }
      
        public List<RoomEquipment> GetByEquipmentId(int id)
        {
            List<RoomEquipment> pom = new List<RoomEquipment>();
          
            foreach (RoomEquipment roomEquipment in roomEquipments)
            {
                if (roomEquipment.Equipment.Id.Equals(id))
                    pom.Add(roomEquipment);
            }
            return pom;
        }

        public List<RoomEquipment> GetByEquipmentIdAndQuantity(int equipmentId, int minQuantity, int maxQuantity)
        {
            List<RoomEquipment> newRoomEquipments = new List<RoomEquipment>();
            foreach (RoomEquipment roomEquipment in this.GetByEquipmentId(equipmentId))
            {
                if (roomEquipment.Quantity >= minQuantity && roomEquipment.Quantity <= maxQuantity)
                    newRoomEquipments.Add(roomEquipment);
            }
            return newRoomEquipments;
        }

        public List<RoomEquipment> GetAll()
        {
            if (roomEquipmentFileHandler.Read() == null)
                return  roomEquipments;

            roomEquipments.Clear();
            SetRoomAndEquipment();

            return roomEquipments;
        }

        private void SetRoomAndEquipment() {
            RoomRepository roomRepository = new RoomRepository();
            EquipmentRepository equipmentRepository = new EquipmentRepository();
            equipmentRepository.GetAll();
            roomRepository.GetAll();
            foreach (RoomEquipment roomEquipment in roomEquipmentFileHandler.Read())
            {
                roomEquipment.Room = roomRepository.GetById(roomEquipment.Room.Id);
                roomEquipment.Equipment = equipmentRepository.GetById(roomEquipment.Equipment.Id);

                roomEquipments.Add(roomEquipment);
            }

        }

        public RoomEquipment GetByIds(int idRoom, int idEquipment)
        {
            foreach (RoomEquipment roomEquipment in roomEquipments)
            {
                if (roomEquipment.Room.Id.Equals(idRoom) && roomEquipment.Equipment.Id.Equals(idEquipment))
                    return roomEquipment;
            }
            return null;
        }
      
        public RoomEquipment GetById(int id)
        {
            foreach (RoomEquipment roomEquipment in roomEquipments)
            {
                if (roomEquipment.Id.Equals(id))
                    return roomEquipment;
            }
            return null;
        }
      
        public bool DeleteByRoomId(int id)
        {
            List<RoomEquipment> re = this.GetByRoomId(id);

            foreach (RoomEquipment roomEquipment in re)
            {
                if (roomEquipment.Room.Id.Equals(id))
                {
                    roomEquipments.Remove(roomEquipment);
                    roomEquipmentFileHandler.Write(roomEquipments);
                }
            }
            return true;

        }

        public bool DeleteByEquipmentId(int id)
        {
            List<RoomEquipment> re = this.GetByRoomId(id);

            foreach (RoomEquipment roomEquipment in re)
            {
                if (roomEquipment.Equipment.Id.Equals(id))
                {
                    roomEquipments.Remove(roomEquipment);
                    roomEquipmentFileHandler.Write(roomEquipments);
                }
            }
            return true;
        }
      
        public bool DeleteById(int id)
        {
            foreach (RoomEquipment roomEquipment in roomEquipments)
            {
                if (roomEquipment.Id.Equals(id)) 
                {
                    roomEquipments.Remove(roomEquipment);
                    roomEquipmentFileHandler.Write(roomEquipments);
                    return true;
                }
            }
            return false;

        }

        public bool Edit(RoomEquipment roomEquipment)
        {
            foreach (RoomEquipment newRoomEquipment in roomEquipments)
            {
                if (newRoomEquipment.Room.Id.Equals(roomEquipment.Room.Id) && newRoomEquipment.Equipment.Id.Equals(roomEquipment.Equipment.Id))
                {
                    newRoomEquipment.Room = roomEquipment.Room;
                    newRoomEquipment.Equipment = roomEquipment.Equipment;
                    newRoomEquipment.Quantity = roomEquipment.Quantity;
                    newRoomEquipment.Id = roomEquipment.Id;
                    roomEquipmentFileHandler.Write(roomEquipments);

                    return true;
                }
            }

            return false;
        }
      
        public bool Create(RoomEquipment roomEquipment)
        {
            roomEquipments.Add(roomEquipment);
            roomEquipmentFileHandler.Write(roomEquipments);
            return true;
        }
      
        public bool MoveEquipment(EquipmentTransfer equipmentTransfer)
        {
            if (CheckEquipmentTransfer(equipmentTransfer) == true)
                return true;
         
            RoomEquipment roomEquipment = this.GetByIds(equipmentTransfer.SenderRoom.Id, equipmentTransfer.Equipment.Id);
            if (roomEquipment == null)
                return true;
            CreatOrEditRoomEquipment(equipmentTransfer, roomEquipment);

            return true;
        }
        private void CreatOrEditRoomEquipment(EquipmentTransfer equipmentTransfer,RoomEquipment roomEquipment) {
            if (roomEquipment.Quantity == equipmentTransfer.Quantity)
                this.DeleteById(roomEquipment.Id);
            else
                this.Edit(new RoomEquipment(roomEquipment.Room, roomEquipment.Equipment, roomEquipment.Quantity - equipmentTransfer.Quantity, roomEquipment.Id));

            RoomEquipment res = this.GetByIds(equipmentTransfer.RecipientRoom.Id, equipmentTransfer.Equipment.Id);
            if (res != null)
                this.Edit(new RoomEquipment(res.Room, res.Equipment, res.Quantity + equipmentTransfer.Quantity, res.Id));
            else
                this.Create(new RoomEquipment(equipmentTransfer.RecipientRoom, equipmentTransfer.Equipment, equipmentTransfer.Quantity, GenerateRoomEquipmentId()));
        }

        private bool CheckEquipmentTransfer(EquipmentTransfer equipmentTransfer) {
            if (equipmentTransfer.SenderRoom == null || equipmentTransfer.RecipientRoom == null || equipmentTransfer.Equipment == null)
                return true;

            if (equipmentTransfer.SenderRoom.Id.Equals(equipmentTransfer.RecipientRoom.Id))
                return true;

            if (DateTime.Compare(equipmentTransfer.SheduledDate.Date, DateTime.Today) < 0)
                return true;

            return false;
        }

        private int GenerateRoomEquipmentId()
        {
            int id = this.GetAll().Count() == 0 ? 0 : this.GetAll().Max(RoomEquipment => RoomEquipment.Id);
            return ++id;
        }
    }
}