using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileHandler
{
    public class QuestionFileHandler
    {
        private readonly string path = @"../../Resources/QuestionGrades.txt";

        public List<Question> Read()
        {

            string serializedQuestions = System.IO.File.ReadAllText(path);
            List<Question> questions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Question>>(serializedQuestions);
            return questions;
        }

        public void Write(List<Question> questions)
        {
            string serializedQuestions = Newtonsoft.Json.JsonConvert.SerializeObject(questions);
            System.IO.File.WriteAllText(path, serializedQuestions);
        }

    }
}
