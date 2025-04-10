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
    public partial class TestForm : Form
    {
        int m_currentQuestion = 0;
        Level m_level;
        List<bool> answers;

        internal TestForm(Level level)
        {
            m_level = level;
            answers = new List<bool>();
            for (int i = 0; i < level.Questions.Count; i++)
            {
                answers.Add(level.Questions[i].Options[0].IsCorrect);
            }
            InitializeComponent();
            ShowCurrentQuestion();
        }

        void ShowCurrentQuestion()
        {
            nextQuestionBtn.Enabled = (m_currentQuestion + 1 != m_level.Questions.Count);
            prevQuestionBtn.Enabled = (m_currentQuestion > 0);
            this.progressLabel.Text = $"{m_currentQuestion + 1}/{m_level.Questions.Count}";
            questionLabel.Text = m_level.Questions[m_currentQuestion].Text;
            questionsBox.Controls.Clear();
            int i = 0;
            int baseYOffset = 10;
            foreach (Option option in m_level.Questions[m_currentQuestion].Options)
            {
                var radioButton = new RadioButton();
                radioButton.Text = option.Value;
                var new_location = radioButton.Location;
                new_location.X = 20;
                new_location.Y += baseYOffset + i * 20;
                radioButton.Location = new_location;
                questionsBox.Controls.Add(radioButton);
                pictureBox.ImageLocation = m_level.Questions[m_currentQuestion].ImagePath;
                radioButton.CheckedChanged += (object sender, EventArgs e) =>
                {
                    if (radioButton.Checked)
                    {
                        answers[m_currentQuestion] = option.IsCorrect;
                    }
                };
                if (i == 0)
                {
                    radioButton.Checked = true;
                }
                i++;
            }
        }

        private void nextQuestionBtn_Click(object sender, EventArgs e)
        {
            if (m_currentQuestion < (m_level.Questions.Count - 1))
            {
                m_currentQuestion += 1;
                ShowCurrentQuestion();
            }
        }

        private void prevQuestionBtn_Click(object sender, EventArgs e)
        {
            if (m_currentQuestion > 0)
            {
                m_currentQuestion -= 1;
                ShowCurrentQuestion();
            }
        }

        override protected void OnFormClosing(FormClosingEventArgs e)
        {
            var result = ShowConfirmExitDialog();
            if (result == DialogResult.Cancel || result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            } else
            {
                // Finish test
            }
        }

        DialogResult ShowConfirmExitDialog()
        {
            return MessageBox.Show("Вы уверены что хотите завершить тестирование?", "Выход", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            var result = ShowConfirmExitDialog();
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public int CalculateScore()
        {
            var result = 0;
            for (int i = 0; i < m_level.Questions.Count; i++)
            {
                if (answers[i])
                {
                    result += m_level.Questions[i].Points;
                }
            }
            return result;
        }
    }
}
