using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Util;
using Hospital.View;
using Model;

namespace Repository
{
    public class PatientAccountRepository
    {
        ObservableCollection<PatientAccount> patients;
        List<PatientAccount> patientAccounts;
        //MTObservableCollection<PatientAccount> patientAccounts;


        public PatientAccountRepository()
        {
            patientAccountFileHandler = new FileHandler.PatientAccountFileHandler();
            patients = new MTObservableCollection<PatientAccount>();
            //patientAccounts = new MTObservableCollection<PatientAccount>();

            patients = new ObservableCollection<PatientAccount>();
            //this.GetAll();

        }

        public bool Create(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, List<Allergy> allergies, List<Ingredient> ingredientss, Address address, Gender gender)
        {
            patients.Add(new PatientAccount(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password, isGuest, healthCardId, allergies, ingredientss));
            patientAccountFileHandler.Write(patients.ToList());
            return true;
        }

        public ref ObservableCollection<PatientAccount> GetValues()
        {
            if (patientAccountFileHandler.Read() == null)
            {
                return ref patients;
            }

            patients.Clear();
            List<PatientAccount> list = patientAccountFileHandler.Read();

            foreach (PatientAccount patient in list)
            {
                patients.Add(patient);
            }
            return ref patients;
        }

        public PatientAccount GetById(int id)
        {
            foreach (PatientAccount patient in patients)
            {
                if (patient.CitizenId.Equals(id))
                {
                    return patient;
                }
            }
            return null;
        }

        public bool Update(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, List<Allergy> allergies, List<Ingredient> ingredients, Address address, Gender gender)
        {
            foreach (PatientAccount patient in patients)
            {
                if (patient.CitizenId.Equals(citizenId))
                {
                    patient.CitizenId = citizenId;
                    patient.Name = name;
                    patient.Surname = surname;
                    patient.DateOfBirth = dateOfBirth;
                    patient.Email = email;
                    patient.PhoneNumber = phoneNumber;
                    patient.Username = username;
                    patient.Password = password;
                    patient.IsGuest = isGuest;
                    patient.HealthCardId = healthCardId;
                    patient.DrugAllergies = allergies;
                    patient.IngredientsAllergies = ingredients;
                    patient.Address = address;
                    patient.Gender = gender;
                    patientAccountFileHandler.Write(patients.ToList());

                    return true;
                }
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            foreach (PatientAccount patient in patients)
            {
                if (patient.CitizenId.Equals(id))
                {
                    patients.Remove(patient);
                    patientAccountFileHandler.Write(patients.ToList());
                    return true;
                }
            }
            return false;
        }
        
        public List<PatientAccount> GetAll()
        {
            if (patientAccountFileHandler.Read() == null)
                return patientAccounts;

            patientAccounts = patientAccountFileHandler.Read();

            return patientAccounts;
        }
        
        /*
        public ref MTObservableCollection<PatientAccount> GetAll()
        {
            if (patientAccountFileHandler.Read() == null)
                return ref patientAccounts;
            patientAccounts.Clear();
            List<PatientAccount> list = patientAccountFileHandler.Read();

            foreach (PatientAccount patientAccount in list)
            { patientAccounts.Add(patientAccount); }

            return ref patientAccounts;
        }
        */
        public FileHandler.PatientAccountFileHandler patientAccountFileHandler;

    }
}