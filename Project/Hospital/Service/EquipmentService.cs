using Model;
using Repository;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Service
{
   public class EquipmentService
   {
        public EquipmentRepository equipmentRepository;
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
      
        public bool Edit(Equipment equipment)
        {
            return equipmentRepository.Edit(equipment);
        }
      
        public bool Create(Equipment equipment)
        {
            if (equipment.Quantity <= 0) 
                return false;

            foreach (Equipment e in equipmentRepository.GetAll())
            {
                if (e.Name.ToLower().Equals(equipment.Name.ToLower()))
                {
                    int pom = e.Quantity + equipment.Quantity;
                    return equipmentRepository.Edit(equipment);
                }
            }
            equipment.Id = GenerateEquipmentId();
            return equipmentRepository.Create(equipment);
        }

        private int GenerateEquipmentId() {
            int id = equipmentRepository.GetAll().Count() == 0 ? 0 : equipmentRepository.GetAll().Max(Equipment => Equipment.Id);
            return ++id;
        }
    }
}