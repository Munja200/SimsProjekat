using Hospital.Model;
using Hospital.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class QuestionController
    {
        public QuestionService questionService;
        public QuestionController(QuestionService questionService)
        {
            this.questionService = questionService;
        }
        public List<Question> GetAll()
        {
            return questionService.GetAll();
        }

        public List<Results> GetResultsForOneEmployee(Employee employee)
        {
            return questionService.GetResultsForOneEmployee(employee);
        }

        public float GetTotalGrade(List<Results> results)
        {
            return questionService.GetTotalGrade(results);
        }

        public List<Results> GetResultsForHospital()
        {
            return questionService.GetResultsForHospital();
        }

    }
}
