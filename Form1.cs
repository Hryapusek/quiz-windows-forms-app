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
    public partial class Form1 : Form
    {
        Quiz m_quiz;
        Theme m_choosenTheme;

        public Form1()
        {
            InitializeComponent();
            if (! ShowLoadQuizForm())
            {
                this.Close();
                return;
            }

            while (true)
            {
                if (!ShowChooseThemeForm())
                {
                    this.Close();
                    return;
                }

                ShowTestForm();
            }
        }

        private bool LoadQuizFromFile(String fileName)
        {
            try
            {
                m_quiz = Quiz.LoadFromFile(fileName);
                return true;
            } catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ShowLoadQuizForm()
        {
            while (true)
            {
                LoadQuizForm loadQuizForm = new LoadQuizForm();
                loadQuizForm.ShowDialog();
                if (loadQuizForm.result == DialogResult.Cancel)
                {
                    return false;
                }
                if (LoadQuizFromFile(loadQuizForm.PathToFile))
                {
                    loadQuizForm.Close();
                    return true;
                }
            }
        }

        private bool ShowChooseThemeForm()
        {
            while (true)
            {
                var themeChooser = new ThemeChooser();
                themeChooser.themes = m_quiz.Themes;
                themeChooser.UpdateComponents();
                themeChooser.ShowDialog();
                if (themeChooser.result == DialogResult.OK)
                {
                    m_choosenTheme = themeChooser.SelectedTheme;
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        private void ShowTestForm()
        {
            var testForm = new TestForm(m_choosenTheme.CurrentLevel);
            testForm.ShowDialog();
            var score = testForm.CalculateScore();
            if (score >= m_choosenTheme.CurrentLevel.MinScore)
            {
                MessageBox.Show($"Вы набрали {score} баллов. Поздравляем, вы справились с тестом!", "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_choosenTheme.NextLevel();
            } else
            {
                MessageBox.Show($"Вы набрали {score} баллов. Минимальный проходной балл {m_choosenTheme.CurrentLevel.MinScore}. Надеемся в следующий раз вам повезет", "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
