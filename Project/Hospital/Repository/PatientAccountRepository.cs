using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class PatientAccountRepository
   {
      public void Create(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
         throw new NotImplementedException();
      }
      
      public List<int> GetValues()
      {
         throw new NotImplementedException();
      }
      
      public int GetById(int id)
      {
         throw new NotImplementedException();
      }
      
      public void Update(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteById(int id)
      {
         throw new NotImplementedException();
      }
      
      public FileHandler.PatientAccountFileHandler patientAccountFileHandler;
   
   }
}