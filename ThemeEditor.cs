using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tema6
{
    public partial class ThemeEditor : Form
    {
        Quiz m_quiz;
        internal ThemeEditor(Quiz quiz)
        {
            m_quiz = quiz;
            InitializeComponent();
            FillThemes();
            this.addThemeBtn.Click += (object sender, EventArgs e) => { AddTheme(); };
            this.themeListBox.SelectedIndexChanged += OnThemeChanged;
            this.levelsListBox.SelectedIndexChanged += OnLevelChanged;
            this.questionsListBox.SelectedIndexChanged += OnQuestionChanged;
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            FillLevels();
            if (themeListBox.SelectedIndex != -1)
                themeNameEditor.Text = m_quiz.Themes[themeListBox.SelectedIndex].Name;
        }

        private void FillThemes()
        {
            themeListBox.Items.Clear();
            foreach (var theme in m_quiz.Themes)
            {
                themeListBox.Items.Add(theme.Name);
            }
            if (m_quiz.Themes.Count > 0)
            {
                themeListBox.SelectedIndex = 0;
            }
        }

        private void OnLevelChanged(object sender, EventArgs e)
        {
            if (levelsListBox.SelectedIndex != -1)
                levelNameEditor.Text = m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].DifficultyLevel;
            FillQuestions();
        }

        private void FillLevels()
        {
            levelsListBox.Items.Clear();
            if (themeListBox.SelectedIndex != -1)
            {
                foreach (var level in m_quiz.Themes[themeListBox.SelectedIndex].Levels)
                {
                    levelsListBox.Items.Add(level.DifficultyLevel);
                }
                if (m_quiz.Themes[themeListBox.SelectedIndex].Levels.Count > 0)
                {
                    levelsListBox.SelectedIndex = 0;
                }
            }
        }

        private void FillQuestions()
        {
            questionsListBox.Items.Clear();

            if (levelsListBox.SelectedIndex != -1)
            {
                var theme = m_quiz.Themes[themeListBox.SelectedIndex];
                var level = theme.Levels[levelsListBox.SelectedIndex];

                foreach (var question in level.Questions)
                {
                    questionsListBox.Items.Add(question.Text);
                }

                if (level.Questions.Count > 0)
                {
                    questionsListBox.SelectedIndex = 0;
                }
            }
        }

        private void OnQuestionChanged(object sender, EventArgs e)
        {
            if (questionsListBox.SelectedIndex != -1)
                questionBox.Text = m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions[questionsListBox.SelectedIndex].Text;
        }

        private void AddTheme()
        {
            var newTheme = new Theme("Новая тема");
            m_quiz.AddTheme(newTheme);
            themeListBox.Items.Add(newTheme.Name);
            themeListBox.SelectedIndex = themeListBox.Items.Count - 1;
        }
    }
}
