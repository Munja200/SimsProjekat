using Model;
using Service;
using System;
using System.Collections.ObjectModel;

namespace Controller
{
   public class EquipmentController
   {
        public EquipmentService equipmentService;
        public EquipmentController(EquipmentService equipmentService) 
        {
            this.equipmentService = equipmentService;
        }
        public Equipment GetById(int id)
        {
            return equipmentService.GetById(id);
        }

        public Equipment GetByName(String name)
        {
            return equipmentService.GetByName(name);
        }


        public ref ObservableCollection<Equipment> GetAll()
        {
            return ref equipmentService.GetAll();
        }
      
        public bool Delete(int id)
        {
            return equipmentService.Delete(id);
        }
      
        public bool Edit(Equipment equipment)
        {
            return equipmentService.Edit(equipment);
        }
      
        public bool Create(Equipment equipment)
        {
            return equipmentService.Create(equipment);
        }   
   }
}