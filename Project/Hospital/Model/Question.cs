using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Question
    {
        public String QuestionText { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionGroup { get; set; }
        public int Mark { get; set; }
        public Employee Employee { get; set; }


        public Question(String questionText, int questionNumber, int questionGroup, int mark, Employee emploee)
        {
            QuestionText = questionText;
            QuestionNumber = questionNumber;
            QuestionGroup = questionGroup;
            Mark = mark;
            Employee = emploee;
        }

        public bool ShouldSerializeEmployee()
        {
            this.Employee.Serialize = false;
            return true;
        }
    }
}
