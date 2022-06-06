using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class EquipmentRepository
   {
        public ObservableCollection<Equipment> equipments;
        public FileHandler.EquipmentFileHandler equipmentFileHandler;

        public EquipmentRepository()
        {
            equipmentFileHandler = new FileHandler.EquipmentFileHandler();
            equipments = new ObservableCollection<Equipment>();
        }
        public Equipment GetById(int id)
        {
            foreach (Equipment equipment in equipments.ToList())
            {
                if (equipment.Id.Equals(id))
                    return equipment;
            }
            return null;
        }

        public Equipment GetByName(String name)
        {
            foreach (Equipment equipment in equipments.ToList())
            {
                if (equipment.Name.Equals(name))
                    return equipment;
            }
            return null;
        }

        public ref ObservableCollection<Equipment> GetAll()
        {
            if (equipmentFileHandler.Read() == null)
                return ref equipments;
            equipments.Clear();
            List<Equipment> list = equipmentFileHandler.Read();

            foreach (Equipment equipment in list)
            { equipments.Add(equipment); }

            return ref equipments;
        }
      
        public bool Delete(int id)
        {
            foreach (Equipment equipment in equipments)
            {
                if (equipment.Id.Equals(id))
                {
                    equipments.Remove(equipment);
                    equipmentFileHandler.Write(equipments.ToList());
                    return true;
                }
            }
            return false;
        }
      
        public bool Edit(Equipment equipment)
        {
            foreach (Equipment newEquipment in equipments)
            {
                if (newEquipment.Id.Equals(equipment.Id))
                {
                    newEquipment.Id = equipment.Id;
                    newEquipment.Name = equipment.Name;
                    newEquipment.Manufacturer = equipment.Manufacturer;
                    newEquipment.Quantity = equipment.Quantity;
                    newEquipment.Description = equipment.Description;
                    equipmentFileHandler.Write(equipments.ToList());

                    return true;
                }
            }
            return false;
        }
      
        public bool Create(Equipment equipment)
        {
            equipments.Add(equipment);
            equipmentFileHandler.Write(equipments.ToList());
            return true;
        }
   }
}