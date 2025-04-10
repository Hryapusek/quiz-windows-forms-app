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

        public void SaveToFile(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Create root element
            XmlElement rootElement = xmlDoc.CreateElement("test_program");
            xmlDoc.AppendChild(rootElement);

            // Create themes element
            XmlElement themesElement = xmlDoc.CreateElement("themes");
            rootElement.AppendChild(themesElement);

            // Save each theme
            foreach (Theme theme in m_themes)
            {
                XmlElement themeElement = xmlDoc.CreateElement("theme");
                themeElement.SetAttribute("name", theme.Name);
                themesElement.AppendChild(themeElement);

                // Save each level
                foreach (Level level in theme.Levels)
                {
                    XmlElement levelElement = xmlDoc.CreateElement("difficulty_level");
                    levelElement.SetAttribute("level", level.Name);
                    levelElement.SetAttribute("min_score", level.MinScore.ToString());
                    themeElement.AppendChild(levelElement);

                    // Create questions element
                    XmlElement questionsElement = xmlDoc.CreateElement("questions");
                    levelElement.AppendChild(questionsElement);

                    // Save each question
                    foreach (Question question in level.Questions)
                    {
                        XmlElement questionElement = xmlDoc.CreateElement("question");
                        questionElement.SetAttribute("points", question.Points.ToString());
                        questionsElement.AppendChild(questionElement);

                        // Add question text
                        XmlElement textElement = xmlDoc.CreateElement("text");
                        textElement.InnerText = question.Text;
                        questionElement.AppendChild(textElement);

                        // Add image path
                        if (!string.IsNullOrEmpty(question.ImagePath))
                        {
                            XmlElement imageElement = xmlDoc.CreateElement("image");
                            imageElement.InnerText = question.ImagePath;
                            questionElement.AppendChild(imageElement);
                        }

                        // Add answers
                        XmlElement answersElement = xmlDoc.CreateElement("answers");
                        questionElement.AppendChild(answersElement);

                        // Save each option
                        foreach (Option option in question.Options)
                        {
                            XmlElement answerElement = xmlDoc.CreateElement("answer");
                            answerElement.SetAttribute("correct", option.IsCorrect.ToString().ToLower());
                            answerElement.InnerText = option.Value;
                            answersElement.AppendChild(answerElement);
                        }
                    }
                }
            }

            // Add settings
            XmlElement settingsElement = xmlDoc.CreateElement("settings");
            rootElement.AppendChild(settingsElement);

            XmlElement passingScoreElement = xmlDoc.CreateElement("passing_score");
            passingScoreElement.InnerText = m_passingScore.ToString();
            settingsElement.AppendChild(passingScoreElement);

            XmlElement maxAttemptsElement = xmlDoc.CreateElement("max_attempts");
            maxAttemptsElement.InnerText = m_maxAttempts.ToString();
            settingsElement.AppendChild(maxAttemptsElement);

            // Save the document
            xmlDoc.Save(filename);
        }

        List<Theme> m_themes = new List<Theme>();
        int m_passingScore;
        int m_maxAttempts;
    }
}
