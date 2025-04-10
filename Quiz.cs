using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tema6
{
    internal class Quiz
    {
        public List<Theme> Themes
        {
            get
            {
                return m_themes;
            }
        }

        public int PassingScore
        { 
            get
            {
                return m_passingScore;
            }
        }

        public int MaxAttempts
        {
            get
            {
                return m_maxAttempts;
            }
        }

        Quiz(int passingScore, int maxAttemps)
        {
            m_passingScore = passingScore;
            m_maxAttempts = maxAttemps;
        }

        public void AddTheme(Theme theme)
        {
            m_themes.Add(theme);
        }

        public static Quiz LoadFromFile(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            var xRoot = xmlDoc.DocumentElement;

            // Parse global settings
            int passingScore = int.Parse(xRoot.SelectSingleNode("settings/passing_score").InnerText);
            int maxAttempts = int.Parse(xRoot.SelectSingleNode("settings/max_attempts").InnerText);
            
            Quiz quiz = new Quiz(passingScore, maxAttempts);
            
            // Parse themes
            XmlNodeList themeNodes = xRoot.SelectNodes("themes/theme");
            foreach (XmlNode themeNode in themeNodes)
            {
                string themeName = themeNode.Attributes["name"].Value;
                
                Theme theme = new Theme(themeName);
                
                // Parse difficulty levels
                XmlNodeList levelNodes = themeNode.SelectNodes("difficulty_level");
                foreach (XmlNode levelNode in levelNodes)
                {
                    string levelName = levelNode.Attributes["level"].Value;
                    int minScore = int.Parse(levelNode.Attributes["min_score"].Value);
                    
                    List<Question> questions = new List<Question>();
                    
                    // Parse questions
                    XmlNodeList questionNodes = levelNode.SelectNodes("questions/question");
                    foreach (XmlNode questionNode in questionNodes)
                    {
                        int points = int.Parse(questionNode.Attributes["points"].Value);
                        string questionText = questionNode.SelectSingleNode("text").InnerText;
                        string imagePath = questionNode.SelectSingleNode("image").InnerText;
                        
                        // Parse answers/options
                        XmlNodeList answerNodes = questionNode.SelectNodes("answers/answer");
                        List<Option> options = new List<Option>();
                        foreach (XmlNode answerNode in answerNodes)
                        {
                            bool isCorrect = bool.Parse(answerNode.Attributes["correct"].Value);
                            string value = answerNode.InnerText;
                            options.Add(new Option(value, isCorrect));
                        }
                        
                        // Create question with first option (you might need to modify this)
                        // Note: Your Question class only takes one Option but XML has multiple
                        // You'll need to decide how to handle this
                        questions.Add(new Question(points, questionText, imagePath));
                        questions.Last().SetOptions(options);
                    }
                    
                    Level level = new Level(questions, levelName, minScore);
                    theme.AddLevel(level);
                }
                
                quiz.AddTheme(theme);
            }
            
            return quiz;
        }

        List<Theme> m_themes = new List<Theme>();
        int m_passingScore;
        int m_maxAttempts;
    }
}
