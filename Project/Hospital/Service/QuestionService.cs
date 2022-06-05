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
    public class QuestionService
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
            return questionRepository.GetAllQuestionForEmployee();
        }
        private List<Question> GetAllQuestionForHospital()
        {      
            return questionRepository.GetAllQuestionForHospital();
        }

        private List<Question> GetAllByEmployee(int id)
        {
            return questionRepository.GetAllByEmployee(id);   
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

        private List<Question> GetAllByQuestionNumber(int questionNumber,List<Question> questions)
        {
            return questionRepository.GetAllByQuestionNumber(questionNumber, questions);
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
        private String GetQuestionText(int questionNumber, List<Question> oldQuestions)
        {

            List<Question> questions = this.GetAllByQuestionNumber(questionNumber, oldQuestions);
            if (questions.Count == 0)
                return "";
            return questions[0].QuestionText;
        }

        private Results GetResultForOneQuestion(int questionNumber, List<Question> oldQuestions)
        {
            Results result = new Results();
            result.AverageGrades = AverageQuestionGrade(this.GetAllByQuestionNumber(questionNumber, oldQuestions));
            result.Question = GetQuestionText(questionNumber, oldQuestions);
            List<Question> questions = this.GetAllByQuestionNumber(questionNumber, oldQuestions);
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
                return results;
          
            for (int i = 1; i <= NumberOfInterviewerQuestions; i++)
                results.Add(GetResultForOneQuestion(i, this.GetAllByEmployee(employee.CitizenId)));    

            return results;
        }


        public List<Results> GetResultsForHospital()
        {
            List<Results> results = new List<Results>();
            for (int i = 1; i <= NumberOfInterviewerQuestions; i++)
                results.Add(GetResultForOneQuestion(i, this.GetAllQuestionForHospital()));

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
