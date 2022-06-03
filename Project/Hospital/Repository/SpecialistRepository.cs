using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Model;

namespace Hospital.Repository
{
    public class SpecialistRepository
    {
        public List<Specialist> specialists;
        public FileHandler.SpecialistFileHandler specialistFileHandler;

        public SpecialistRepository()
        {
            specialistFileHandler = new FileHandler.SpecialistFileHandler();
            specialists = new List<Specialist>();
        }
        public bool CreateSpecialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime, string username,
            string password, string name, string surname, int citid, Gender gender, DateTime dateOfBirth, string email, string phoneNumber,
            Address address)
        {
            specialists.Add(new Specialist(speciality, averageRating, role, workingTime, username, password, name, surname, citid, gender,
                dateOfBirth, email, phoneNumber, address));
            specialistFileHandler.Write(specialists);
            return true;
        }

        public bool DeleteSpecialist(int citizenId)
        {
            foreach (Specialist specialist in specialists)
            {
                if (specialist.CitizenId.Equals(citizenId))
                    specialists.Remove(specialist);
                    specialistFileHandler.Write(specialists);
                    return true;

            }
            return false;
        }

        public bool EditSpecialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime, string username,
            string password, string name, string surname, int citid, Gender gender, DateTime dateOfBirth, string email, string phoneNumber,
            Address address)
        {

            foreach (Specialist specialist in specialists)
            {
                SpecialistsSpecialityEquals(specialist, speciality,  averageRating, role, workingTime, username, password, name, surname,
                    citid, gender, dateOfBirth, email, phoneNumber, address);
            }

            return false;
        }

        public bool SpecialistsSpecialityEquals(Specialist specialist, Speciality speciality, float averageRating, EmployeeRole role, 
            WorkingTime workingTime, string username, string password, string name, string surname, int citid, Gender gender, 
            DateTime dateOfBirth, string email, string phoneNumber, Address address)
        {
            if (specialist.Speciality.Equals(speciality))
            {

                specialist.Speciality = speciality;
                specialist.AverageRating = averageRating;
                specialist.role = role;
                specialist.WorkingTime = workingTime;
                specialist.Username = username;
                specialist.Password = password;
                specialist.Name = name;
                specialist.Surname = surname;
                specialist.CitizenId = citid;
                specialist.Gender = gender;
                specialist.DateOfBirth = dateOfBirth;
                specialist.Email = email;
                specialist.PhoneNumber = phoneNumber;
                specialist.Address = address;

                return true;
            }
            return false;
        }

        public List<Specialist> GetAll()
        {
            if (specialistFileHandler.Read() == null)
                return specialists;

            specialists = specialistFileHandler.Read();

            return specialists;
        }

        public Specialist GetSpecialistById(int citizenId)
        {
            foreach (Specialist specialist in specialists)
            {
                if (specialist.CitizenId.Equals(citizenId))
                    return specialist;
            }
            return null;
        }

    }
}
