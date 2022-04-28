using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Controller
{
   public class PatientAccountController
   {

        public PatientAccountController(PatientAccountService patientAccountService)
        {
            this.patientAccountService = patientAccountService;
        }

        public bool Create(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
            return patientAccountService.Create(name, surname, citizenId, dateOfBirth, email, phoneNumber, username, password, isGuest, healthCardId, allergies, address, gender);
      }
      
      public ref ObservableCollection<PatientAccount> GetValues()
      {
            return ref patientAccountService.GetValues();
      }
      
      public PatientAccount GetById(int id)
      {
            return patientAccountService.GetById(id);
      }
      
      public bool Update(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
         return patientAccountService.Update(name, surname, citizenId, dateOfBirth, email, phoneNumber, username, password, isGuest, healthCardId, allergies, address, gender);
        }
      
      public bool DeleteById(int id)
      {
            return patientAccountService.DeleteById(id);
        }
      
      public Service.PatientAccountService patientAccountService;

      
    }
}