using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema6
{
    internal class Level
    {
        public List<Question> Questions {
            get {
                return m_questions;
            }
        }

        public String DifficultyLevel
        {
            get
            {
                return m_level;
            }
        }

        public int MinScore
        { 
            get
            {
                return m_minScore;
            }
        }

        public int QuestionsPerSession
        {
            get
            {
                return m_questionsPerSession;
            }
        }

        public int TimeLimit
        {
            get
            {
                return m_timeLimit;
            }
        }

        public Level(List<Question> questions, string level, int minScore, int questionsPerSession, int time_limit)
        {
            m_questions = questions;
            m_level = level;
            m_minScore = minScore;
            m_questionsPerSession = questionsPerSession;
            m_timeLimit = time_limit;
        }

        public void AddQuestion(Question question)
        {
            m_questions.Add(question);
        }

        List<Question> m_questions;
        String m_level;
        int m_minScore;
        int m_questionsPerSession;
        int m_timeLimit;
    }
}
