using Model;
using Service;
using System;
using System.Collections.ObjectModel;

namespace Controller
{
   public class EquipmentController
   {
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
      
      public bool Edit(int id, String name, String manufacturer, int quantity, String description)
      {
            return equipmentService.Edit(id, name, manufacturer, quantity, description);
      }
      
      public bool Create(int id, String name, String manufacturer, int quantity, String description)
      {
            return equipmentService.Create(id, name, manufacturer, quantity, description);
      }
      
      public Service.EquipmentService equipmentService;
   
   }
}