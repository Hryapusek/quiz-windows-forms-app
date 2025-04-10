using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Level
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new();
        public int MinScore { get; set; }

        public Level(List<Question> questions, string name, int minScore)
        {
            Name = name;
            Questions = questions;
            MinScore = minScore;
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
    }
}
