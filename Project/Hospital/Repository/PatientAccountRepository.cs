using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Repository
{
   public class PatientAccountRepository
   {
        ObservableCollection<PatientAccount> patients;

        public PatientAccountRepository()
        {
            patientAccountFileHandler = new FileHandler.PatientAccountFileHandler();
            patients = new ObservableCollection<PatientAccount>();
        }

        public bool Create(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
            patients.Add(new PatientAccount(name, surname, citizenId, gender, dateOfBirth, email, phoneNumber, address, username, password, isGuest, healthCardId, allergies));
            patientAccountFileHandler.Write(patients.ToList());
            return true;
      }
      
      public ref ObservableCollection<PatientAccount> GetValues()
      {
         if(patientAccountFileHandler.Read() == null)
            {
                return ref patients;
            }

            patients.Clear();
            List<PatientAccount> list = patientAccountFileHandler.Read();

            foreach(PatientAccount patient in list)
            {
                patients.Add(patient);
            }
            return ref patients;
      }
      
      public PatientAccount GetById(int id)
      {
         foreach(PatientAccount patient in patients)
            {
                if (patient.citizenId.Equals(id))
                {
                    return patient;
                }
            }
            return null;
      }
      
      public bool Update(String name, String surname, int citizenId, DateTime dateOfBirth, String email, String phoneNumber, String username, String password, bool isGuest, int healthCardId, String allergies, Address address, Gender gender)
      {
         foreach(PatientAccount patient in patients)
            {
                if (patient.citizenId.Equals(citizenId))
                {
                    patient.citizenId = citizenId;
                    patient.name = name;
                    patient.surname = surname;
                    patient.dateOfBirth = dateOfBirth;
                    patient.email = email;
                    patient.phoneNumber = phoneNumber;
                    patient.username = username;
                    patient.password = password;
                    patient.isGuest = isGuest;
                    patient.healthCardId = healthCardId;
                    patient.allergies = allergies;
                    patient.address = address;
                    patient.gender = gender;
                    patientAccountFileHandler.Write(patients.ToList());

                    return true;
                }
            }
            return false;
      }
      
      public bool DeleteById(int id)
      {
         foreach(PatientAccount patient in patients)
            {
                if (patient.citizenId.Equals(id))
                {
                    patients.Remove(patient);
                    patientAccountFileHandler.Write(patients.ToList());
                    return true;
                }
            }
            return false;
      }
      
      public FileHandler.PatientAccountFileHandler patientAccountFileHandler;
   
   }
}