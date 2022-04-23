using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Service
{
   public class PatientAccountService
   {

        public PatientAccountService(PatientAccountRepository patientAccountRepository)
        {
            this.patientAccountRepository = patientAccountRepository;
        }

        public bool Create(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
            return patientAccountRepository.Create(name, surname, citizenId, dateOfBirth, email, phoneNumber, username, password, isGuest, healthCardId, allergies, address, gender);
      }
      
      public ref ObservableCollection<PatientAccount> GetValues()
      {
            return ref patientAccountRepository.GetValues();
      }
      
      public PatientAccount GetById(int id)
      {
            return patientAccountRepository.GetById(id);
        }
      
      public bool Update(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
            return patientAccountRepository.Update(name, surname, citizenId, dateOfBirth, email, phoneNumber, username, password, isGuest, healthCardId, allergies, address, gender);
      }
      
      public bool DeleteById(int id)
      {
            return patientAccountRepository.DeleteById(id);
      }
      
      public Repository.PatientAccountRepository patientAccountRepository;

        
    }
}