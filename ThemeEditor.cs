using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            this.addThemeBtn.Click += (object sender, EventArgs e) => { AddTheme(); };
            this.deleteThemeBtn.Click += (object sender, EventArgs e) => { DeleteTheme(); };
            this.addLevelBtn.Click += (object sender, EventArgs e) => { AddLevel(); };
            this.deleteLevelBtn.Click += (object sender, EventArgs e) => { DeleteLevel(); };
            this.addQuestionBtn.Click += (object sender, EventArgs e) => { AddQuestion(); };
            this.deleteQuestionBtn.Click += (object sender, EventArgs e) => { DeleteQuestion(); };
            this.addOptionBtn.Click += (object sender, EventArgs e) => { AddOption(); };
            this.deleteOptionBtn.Click += (object sender, EventArgs e) => { DeleteOption(); };
            this.themeListBox.SelectedIndexChanged += OnThemeChanged;
            this.levelsListBox.SelectedIndexChanged += OnLevelChanged;
            this.questionsListBox.SelectedIndexChanged += OnQuestionChanged;
            this.themeNameEditor.TextChanged += OnThemeNameChanged;
            this.levelNameEditor.TextChanged += OnLevelNameChanged;
            this.minimalScoreBox.TextChanged += OnMinimalScoreChanged;
            this.questionBox.TextChanged += OnQuestionTextChanged;
            this.chooseImageBtn.Click += OnChooseImageBtnClick;
            this.minimalScoreBox.TextChanged += OnQuestionMinimalScoreChanged;
            FillThemes();
        }

        private void OnThemeChanged(object sender, EventArgs e)
        {
            FillLevels();
            if (themeListBox.SelectedIndex != -1)
                themeNameEditor.Text = m_quiz.Themes[themeListBox.SelectedIndex].Name;
        }

        private void OnThemeNameChanged(object sender, EventArgs e)
        {
            if (themeListBox.SelectedIndex != -1)
            {
                m_quiz.Themes[themeListBox.SelectedIndex].Name = themeNameEditor.Text;
                this.themeListBox.Items[themeListBox.SelectedIndex] = themeNameEditor.Text;
            }
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
                levelNameEditor.Text = m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Name;
            FillQuestions();
        }

        private void OnLevelNameChanged(object sender, EventArgs e)
        {
            if (levelsListBox.SelectedIndex != -1)
            {
                m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Name = levelNameEditor.Text;
                this.levelsListBox.Items[levelsListBox.SelectedIndex] = levelNameEditor.Text;
            }
        }

        private void FillLevels()
        {
            levelsListBox.Items.Clear();
            if (themeListBox.SelectedIndex != -1)
            {
                foreach (var level in m_quiz.Themes[themeListBox.SelectedIndex].Levels)
                {
                    levelsListBox.Items.Add(level.Name);
                }
                if (m_quiz.Themes[themeListBox.SelectedIndex].Levels.Count > 0)
                {
                    levelsListBox.SelectedIndex = 0;
                }
            }
        }

        private void OnMinimalScoreChanged(object sender, EventArgs e)
        {
            if (levelsListBox.SelectedIndex != -1)
            {
                if (int.TryParse(minimalScoreBox.Text, out var score))
                {
                    minimalScoreBox.BorderStyle = BorderStyle.None;
                    minimalScoreBox.ForeColor = Color.Black;
                    m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].MinScore = score;
                } else {
                    minimalScoreBox.BorderStyle = BorderStyle.FixedSingle;
                    minimalScoreBox.ForeColor = Color.Red;                    
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
            FillOptions();
        }

        private void OnQuestionTextChanged(object sender, EventArgs e)
        {
            if (questionsListBox.SelectedIndex != -1)
            {
                m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions[questionsListBox.SelectedIndex].Text = questionBox.Text;
                this.questionsListBox.Items[questionsListBox.SelectedIndex] = questionBox.Text;
            }
        }

        private void FillOptions()
        {
            int y = 20;
            optionsBox.Controls.Clear();
            var options = m_quiz.Themes[themeListBox.SelectedIndex]
                                  .Levels[levelsListBox.SelectedIndex]
                                  .Questions[questionsListBox.SelectedIndex].Options;
            foreach (var option in options)
            {
                var radioButton = new RadioButton();
                radioButton.Width = 20;
                radioButton.Location = new Point(20, y);
                radioButton.Checked = option.IsCorrect;
                radioButton.CheckedChanged += (object sender, EventArgs e) => { 
                    option.IsCorrect = true;
                    foreach (var otherOption in options)
                    {
                        if (otherOption != option)
                        {
                            otherOption.IsCorrect = false;
                        }
                    }
                };

                var textBox = new TextBox();
                textBox.BringToFront();
                textBox.Text = option.Value;
                textBox.Location = new Point(50, y);
                textBox.Width = 200;
                textBox.TextChanged += (object sender, EventArgs e) => {
                    option.Value = textBox.Text;
                };

                y += 30;
                optionsBox.Controls.Add(radioButton);
                optionsBox.Controls.Add(textBox);
            }
        }

        private void OnChooseImageBtnClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions[questionsListBox.SelectedIndex].ImagePath = dialog.FileName;
                this.pictureBox.ImageLocation = dialog.FileName;
            }
        }

        private void AddTheme()
        {
            var newTheme = new Theme("Новая тема");
            m_quiz.AddTheme(newTheme);
            themeListBox.Items.Add(newTheme.Name);
            themeListBox.SelectedIndex = themeListBox.Items.Count - 1;
        }

        private void DeleteTheme()
        {
            if (themeListBox.SelectedIndex != -1)
            {
                m_quiz.Themes.RemoveAt(themeListBox.SelectedIndex);
                themeListBox.Items.RemoveAt(themeListBox.SelectedIndex);
            }
        }

        private void AddLevel()
        {
            var newLevel = new Level("Новый уровень");
            m_quiz.Themes[themeListBox.SelectedIndex].AddLevel(newLevel);
            FillLevels();
        }

        private void DeleteLevel()
        {
            if (levelsListBox.SelectedIndex != -1)
            {
                m_quiz.Themes[themeListBox.SelectedIndex].Levels.RemoveAt(levelsListBox.SelectedIndex);
                FillLevels();
            }
        }

        private void AddQuestion()
        {
            var newQuestion = new Question("Новый вопрос");
            m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].AddQuestion(newQuestion);
            this.questionsListBox.Items.Add(newQuestion.Text);
            this.questionsListBox.SelectedIndex = this.questionsListBox.Items.Count - 1;
            FillQuestions();
        }

        private void DeleteQuestion()
        {
            if (questionsListBox.SelectedIndex != -1)
            {
                m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions.RemoveAt(questionsListBox.SelectedIndex);
                FillQuestions();
            }
        }

        private void OnQuestionMinimalScoreChanged(object sender, EventArgs e)
        {
            if (questionsListBox.SelectedIndex != -1)
            {
                if (int.TryParse(minimalScoreBox.Text, out var points))
                {
                    minimalScoreBox.BorderStyle = BorderStyle.None;
                    minimalScoreBox.ForeColor = Color.Black;
                    m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions[questionsListBox.SelectedIndex].Points = points;
                } else {
                    minimalScoreBox.BorderStyle = BorderStyle.FixedSingle;
                    minimalScoreBox.ForeColor = Color.Red;
                }
            }
        }

        private void AddOption()
        {
            var newOption = new Option("Новый вариант ответа", false);
            m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions[questionsListBox.SelectedIndex].AddOption(newOption);
            FillOptions();
        }

        private void DeleteOption()
        {
            var options = m_quiz.Themes[themeListBox.SelectedIndex].Levels[levelsListBox.SelectedIndex].Questions[questionsListBox.SelectedIndex].Options;
            if (options.Count > 0)
            {
                options.RemoveAt(options.Count - 1);
                FillOptions();
            }
        }
    }
}
