using Hospital.Model;
using Hospital.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class QuestionService
    {
        private const int NumberOfInterviewerQuestions = 9;
        public QuestionRepository questionRepository;
        public QuestionService(QuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public List<Question> GetAll()
        {
            return questionRepository.GetAll();
        }

        private List<Question> GetAllQuestionForEmployees()
        {
            List<Question> questions = new List<Question>();
            foreach (Question question in this.GetAll())
            {
                if (question.Employee != null)
                {
                    questions.Add(question);
                }
            }
            return questions;
        }
        private List<Question> GetAllQuestionForHospital()
        {
            List<Question> questions = new List<Question>();
            foreach (Question question in this.GetAll())
            {
                if (question.Employee == null)
                {
                    questions.Add(question);
                }
            }
            return questions;
        }

        private List<Question> GetAllByEmployee(int id)
        {
            List<Question> newQuestions = new List<Question>();

            foreach (Question question in this.GetAllQuestionForEmployees())
            {
                if (question.Employee.CitizenId.Equals(id))
                {
                    newQuestions.Add(question);
                }
            }

            return newQuestions;
        }
        
        private int CountGrades(int grade, List<Question> questions)
        {
            int number = 0;
            foreach (Question question in questions)
            {
                if (grade == question.Mark)
                    number++;
            }

            return number;
        }

        private List<Question> GetAllByQuestionNumber(int questionNumber, int id)
        {
            List<Question> questions = new List<Question>();

            foreach (Question question in this.GetAllByEmployee(id))
            {
                if (question.QuestionNumber == questionNumber)
                    questions.Add(question);
            }

            return questions;
        }

        private float AverageQuestionGrade(List<Question> questions)
        {
            float sumGrade = 0;
            int counter = 0;

            foreach (Question question in questions)
            {
                sumGrade += question.Mark;
                counter++;
            }
            return ChechAverageValue(sumGrade, counter);
        }

        private float ChechAverageValue(float sum, int counter)
        {
            if (counter == 0)
                return 0;
            return sum / counter;
        }
        private String GetQuestionText(int questionNumber, int id)
        {

            List<Question> question = this.GetAllByQuestionNumber(questionNumber, id);
            if (question.Count == 0)
                return "";
            return question[0].QuestionText;
        }

        private Results GetResultForOneQuestion(int questionNumber, int id)
        {
            Results result = new Results();
            result.AverageGrades = AverageQuestionGrade(this.GetAllByQuestionNumber(questionNumber, id));
            result.Question = GetQuestionText(questionNumber, id);
            List<Question> questions = this.GetAllByQuestionNumber(questionNumber, id);
            result.CountOne = CountGrades(1, questions);
            result.CountTwo = CountGrades(2, questions);
            result.CountThree = CountGrades(3, questions);
            result.CountFore = CountGrades(4, questions);
            result.CountFive = CountGrades(5, questions);

            return result;
        }

        public List<Results> GetResultsForOneEmployee(Employee employee)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Results> results = new List<Results>();

            if (employeeRepository.GetById(employee.CitizenId) == null)
            {
                return results;
            }

            for (int i = 1; i <= NumberOfInterviewerQuestions; i++)
            {
                results.Add(GetResultForOneQuestion(i, employee.CitizenId));
            }

            return results;
        }

        public float GetTotalGrade(List<Results> results)
        {
            int counter = 0;
            float sum = 0;
            foreach (Results result in results)
            {
                sum += result.AverageGrades;
                counter++;
            }

            return ChechAverageValue(sum, counter);
        }
    }
}
