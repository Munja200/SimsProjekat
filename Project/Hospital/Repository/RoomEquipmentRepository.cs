using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class RoomEquipmentRepository
   {
      public RoomEquipmentRepository()
      {
          roomEquipmentFileHandler = new FileHandler.RoomEquipmentFileHandler();
          roomEquipments = new ObservableCollection<RoomEquipment>();
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
      
      public List<RoomEquipment> GetAll()
      {
            if (roomEquipmentFileHandler.Read() == null)
                return  roomEquipments.ToList();
            roomEquipments.Clear();
            List<RoomEquipment> list = roomEquipmentFileHandler.Read();

            foreach (RoomEquipment r in list)
            { roomEquipments.Add(r); }

            return  roomEquipments.ToList();
        }
      
      public RoomEquipment GetByIds(int idRoom, int idEquipment)
      {
            foreach (RoomEquipment roomEquipment in roomEquipments.ToList())
            {
                if (roomEquipment.Room.Id.Equals(idRoom) && roomEquipment.Equipment.Id.Equals(idEquipment))
                    return roomEquipment;
            }
            return null;
        }
      
      public RoomEquipment GetById(int id)
      {
            foreach (RoomEquipment roomEquipment in roomEquipments.ToList())
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
                    roomEquipmentFileHandler.Write(roomEquipments.ToList());
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
                    roomEquipmentFileHandler.Write(roomEquipments.ToList());
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
                    roomEquipmentFileHandler.Write(roomEquipments.ToList());
                    return true;
                }
            }
            return false;

        }

        public bool Edit(Room room, Equipment equipment, int quantity, int id)
      {
            foreach (RoomEquipment re in roomEquipments)
            {
                if (re.Room.Id.Equals(room.Id) && re.Equipment.Id.Equals(equipment.Id))
                {
                    re.Room = room;
                    re.Equipment = equipment;
                    re.Quantity = quantity;
                    re.Id = id;
                    roomEquipmentFileHandler.Write(roomEquipments.ToList());

                    return true;
                }
            }

            return false;
        }
      
      public bool Create(Room room, Equipment equipment, int quantity, int id)
      {
            roomEquipments.Add(new RoomEquipment(room, equipment, quantity, id));
            roomEquipmentFileHandler.Write(roomEquipments.ToList());
            return true;
        }
      
      public bool MoveEquipment(EquipmentTransfer equipmentTransfer)
      {
            if (equipmentTransfer.SenderRoom.Id.Equals(equipmentTransfer.RecipientRoom.Id))
            {
                return true;
            }

            if (DateTime.Compare(equipmentTransfer.SheduledDate.Date, DateTime.Today) < 0)
            {
                return true;
            }

            RoomEquipment re = this.GetByIds(equipmentTransfer.SenderRoom.Id, equipmentTransfer.Equipment.Id);
            if (re == null)
                return true;
           
            if (re.Quantity == equipmentTransfer.Quantity)
            {
                this.DeleteById(re.Id);
            }
            else
            {
                this.Edit(re.Room, re.Equipment, re.Quantity - equipmentTransfer.Quantity, re.Id);
            }


            RoomEquipment res = this.GetByIds(equipmentTransfer.RecipientRoom.Id, equipmentTransfer.Equipment.Id);
            if (res != null)
            {
                this.Edit(res.Room, res.Equipment, res.Quantity + equipmentTransfer.Quantity, res.Id);

            }
            else
            {
                int ids = this.GetAll().Count() == 0 ? 0 : this.GetAll().Max(RoomEquipment => RoomEquipment.Id);
                this.Create(equipmentTransfer.RecipientRoom, equipmentTransfer.Equipment, equipmentTransfer.Quantity, ++ids);
            }


            return true;
        }
      
        public ObservableCollection<RoomEquipment> roomEquipments;
      
      public FileHandler.RoomEquipmentFileHandler roomEquipmentFileHandler;
   
   }
}