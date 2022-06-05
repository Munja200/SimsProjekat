using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Results
    {
        public float AverageGrades { get; set; }
        public String Question { get; set; }
        public int CountFive { get; set; }
        public int CountFore { get; set; }
        public int CountThree { get; set; }
        public int CountTwo { get; set; }
        public int CountOne { get; set; }
        public Results()
        {
        }

        public Results(float averageGrades, String question, int countFive, int countFour, int countThree, int conutTwo, int countOne)
        {
            AverageGrades = averageGrades;
            Question = question;
            CountFive = countFive;
            CountFore = countFour;
            CountThree = CountThree;
            CountTwo = CountTwo;
            CountOne = countOne;

        }
    }
}
