using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;
using Model;

namespace Hospital.Service
{
    public class SpecialistService
    {
        public Repository.SpecialistRepository specialistRepository;

        public SpecialistService(SpecialistRepository specialistRepository)
        {
            this.specialistRepository = specialistRepository;
        }

        public List<Specialist> GetAll()
        {
            return specialistRepository.GetAll();
        }

        public bool CreateSpecialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime, 
            string username, string password, string name, string surname, int citid, Gender gender, DateTime dateOfBirth, string email,
            string phoneNumber, Address address)
        {
            return specialistRepository.CreateSpecialist(speciality, averageRating, role, workingTime, username, password, name, surname,
                citid, gender, dateOfBirth, email, phoneNumber, address);

        }

        public bool DeleteSpecialist(int citizenId)
        {
            return specialistRepository.DeleteSpecialist(citizenId);
        }

        public bool EditSpecialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime,
            string username, string password, string name, string surname, int citid, Gender gender, DateTime dateOfBirth, string email,
            string phoneNumber, Address address)
        {
            return specialistRepository.EditSpecialist(speciality, averageRating, role, workingTime, username, password, name,surname,
                citid, gender, dateOfBirth, email, phoneNumber, address);
        }

        public Specialist GetSpecialistById(int citizenId)
        {
            return specialistRepository.GetSpecialistById(citizenId);
        }

    }

}
