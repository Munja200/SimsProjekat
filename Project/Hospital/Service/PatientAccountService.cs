using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.View;
using Model;
using Repository;

namespace Service
{
    public class PatientAccountService
    {

        public PatientAccountService(PatientAccountRepository patientAccountRepository)
        {
            this.patientAccountRepository = patientAccountRepository;
        }

        public bool Create(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, List<Allergy> allergies, List<Ingredient>ingredients, Address address, Gender gender)
        {
            return patientAccountRepository.Create(name, surname, citizenId, dateOfBirth, email, phoneNumber, username, password, isGuest, healthCardId, allergies, ingredients, address, gender);
        }

        public ref ObservableCollection<PatientAccount> GetValues()
        {
            return ref patientAccountRepository.GetValues();
        }

        public PatientAccount GetById(int id)
        {
            return patientAccountRepository.GetById(id);
        }

        public bool Update(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, List<Allergy> allergies, List<Ingredient>ingredients, Address address, Gender gender)
        {
            return patientAccountRepository.Update(name, surname, citizenId, dateOfBirth, email, phoneNumber, username, password, isGuest, healthCardId, allergies, ingredients, address, gender);
        }

        public bool DeleteById(int id)
        {
            return patientAccountRepository.DeleteById(id);
        }
        
        public List<PatientAccount> GetAll()
        {
            return patientAccountRepository.GetAll();
        }
        
        /*
        public ref MTObservableCollection<PatientAccount> GetAll()
        {
            return ref patientAccountRepository.GetAll();
        }
        */
        public Repository.PatientAccountRepository patientAccountRepository;


    }
}