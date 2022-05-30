using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class EquipmentRepository
   {
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

            foreach (Equipment e in list)
            { equipments.Add(e); }

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
      
      public bool Edit(int id, String name, String manufacturer, int quantity, String description)
      {
            foreach (Equipment es in equipments)
            {
                if (es.Id.Equals(id))
                {
                    es.Id = id;
                    es.Name = name;
                    es.Manufacturer = manufacturer;
                    es.Quantity = quantity;
                    es.Description = description;
                    equipmentFileHandler.Write(equipments.ToList());

                    return true;
                }
            }

            return false;
        }
      
      public bool Create(int id, String name, String manufacturer, int quantity, String description)
      {
            equipments.Add(new Equipment(id, name, manufacturer, quantity, description));
            equipmentFileHandler.Write(equipments.ToList());
            return true;
        }
      
      public ObservableCollection<Equipment> equipments;
      
      public FileHandler.EquipmentFileHandler equipmentFileHandler;
   
   }
}