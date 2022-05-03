using Model;
using Repository;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Service
{
   public class EquipmentService
   {
      public EquipmentService(EquipmentRepository equipmentRepository)
      {
          this.equipmentRepository = equipmentRepository;
      }
        public Equipment GetById(int id)
      {
            return equipmentRepository.GetById(id);
        }
        public Equipment GetByName(String name)
        {
            return equipmentRepository.GetByName(name);
        }

        public ref ObservableCollection<Equipment> GetAll()
      {
            return  ref equipmentRepository.GetAll();
      }
      
      public bool Delete(int id)
      {
            return equipmentRepository.Delete(id);
      }
      
      public bool Edit(int id, String name, String manufacturer, int quantity, String description, Medicine medicine)
      {
            return equipmentRepository.Edit(id, name , manufacturer, quantity, description, medicine);
      }
      
      public bool Create(int id, String name, String manufacturer, int quantity, String description, Medicine medicine)
      {
            if (quantity <= 0) 
            {
                return false;
            }

            foreach (Equipment e in equipmentRepository.GetAll())
            {
                if (e.Name.ToLower().Equals(name.ToLower()))
                {
                    int pom = e.Quantity + quantity;
                    return equipmentRepository.Edit(e.Id, e.Name, e.Manufacturer, pom, e.Description, e.Medicine);
                }
            }
            int ids = equipmentRepository.GetAll().Count() == 0 ? 0 : equipmentRepository.GetAll().Max(Equipment => Equipment.Id);
            return equipmentRepository.Create(++ids, name, manufacturer, quantity, description, medicine);
      }
      
      public Repository.EquipmentRepository equipmentRepository;
   
   }
}