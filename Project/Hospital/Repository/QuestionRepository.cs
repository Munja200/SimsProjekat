using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    class QuestionRepository
    {
        public List<Question> questions;

        public FileHandler.QuestionFileHandler questionFileHandler;

        public QuestionRepository()
        {
            questionFileHandler = new FileHandler.QuestionFileHandler();
            questions = new List<Question>();
            this.GetAll();
        }

        public List<Question> GetAll()
        {
            if (questionFileHandler.Read() == null)
                return questions;
            FillEmployeeList();

            return questions;
        }


        private void FillEmployeeList()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            questions.Clear();

            foreach (Question question in questionFileHandler.Read())
            {
                question.Employee = employeeRepository.GetById(question.Employee.CitizenId);
                questions.Add(question);
            }
        }
    }
}
