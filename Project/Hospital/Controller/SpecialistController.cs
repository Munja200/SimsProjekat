using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;
using Model;

namespace Hospital.Controller
{
    public class SpecialistController
    {
            private readonly SpecialistService _service;

        public SpecialistController(SpecialistService service)
            {
                _service = service;
            }

        public List<Specialist> GetAll()
            {
                return _service.GetAll();
            }

        public bool CreateSpecialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime, string username, 
            string password, string name, string surname, int citid, Gender gender, DateTime dateOfBirth, string email, string phoneNumber, Address address)
        {
            return _service.CreateSpecialist(speciality, averageRating, role, workingTime, username, password, name, surname, citid, gender, dateOfBirth,
                email, phoneNumber, address);

        }

        public bool DeleteSpecialist(int citizenId)
        {
            return _service.DeleteSpecialist(citizenId);
        }

        public bool EditSpecialist(Speciality speciality, float averageRating, EmployeeRole role, WorkingTime workingTime, string username, 
            string password, string name, string surname, int citid, Gender gender, DateTime dateOfBirth, string email, string phoneNumber, Address address)
        {
            return _service.EditSpecialist(speciality, averageRating, role, workingTime, username, password, name, surname, citid, gender, dateOfBirth,
                email, phoneNumber, address);
        }

        public Specialist GetSpecialistById(int citizenId)
        {
            return _service.GetSpecialistById(citizenId);
        }

    }
}
