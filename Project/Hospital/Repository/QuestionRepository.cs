using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class QuestionRepository
    {
        public List<Question> questions;
        private EmployeeRepository employeeRepository;

        public FileHandler.QuestionFileHandler questionFileHandler;

        public QuestionRepository(EmployeeRepository employeeRepository)
        {
            questionFileHandler = new FileHandler.QuestionFileHandler();
            this.employeeRepository = employeeRepository;
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
            
            questions.Clear();

            foreach (Question question in questionFileHandler.Read())
            {
                if (question.Employee != null)
                    question.Employee = employeeRepository.GetById(question.Employee.CitizenId);
                questions.Add(question);
                
            }
        }



        public List<Question> GetAllQuestionForEmployee()
        {
            List<Question> newQuestions = new List<Question>();
            foreach (Question question in this.GetAll())
            {
                if (question.Employee != null)
                    newQuestions.Add(question);
            }
            return newQuestions;
        }
        public List<Question> GetAllQuestionForHospital()
        {
            List<Question> newQuestions = new List<Question>();
            foreach (Question question in this.GetAll())
            {
                if (question.Employee == null)
                    newQuestions.Add(question);
            }
            return newQuestions;
        }

        public List<Question> GetAllByQuestionNumber(int questionNumber, List<Question> oldQuestion)
        {
            List<Question> newQuestions = new List<Question>();

            foreach (Question question in oldQuestion)
            {
                if (question.QuestionNumber == questionNumber)
                    newQuestions.Add(question);
            }

            return newQuestions;
        }

        public List<Question> GetAllByEmployee(int id)
        {
            List<Question> newQuestion = new List<Question>();

            foreach (Question question in this.GetAllQuestionForEmployee())
            {
                if (question.Employee.CitizenId.Equals(id))
                {
                    newQuestion.Add(question);
                }
            }

            return newQuestion;
        }
    }
}
