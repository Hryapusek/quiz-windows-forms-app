using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace tema6
{
    public partial class Form1 : Form
    {
        Quiz m_quiz;
        Theme m_choosenTheme;

        Timer timer = new();

        public Form1()
        {
            AllocConsole();
            timer.Interval = 100;
            timer.Tick += (object sender, EventArgs e) =>
            {
                ((Timer)sender).Enabled = false;
                this.Close();
            };
            if (!ShowLoadQuizForm())
            {
                timer.Start();
                return;
            }

            while (true)
            {
                var result = ShowChooseThemeForm();
                if (result == ThemeChooser.ChoosedOption.Close)
                {
                    timer.Start();
                    return;
                }
                else if (result == ThemeChooser.ChoosedOption.StartTest)
                {
                    ShowTestForm();
                }
                else if (result == ThemeChooser.ChoosedOption.EditTheme)
                {
                    ShowEditThemeForm();
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void ShowEditThemeForm()
        {
            var testForm = new ThemeEditor(m_quiz);
            testForm.ShowDialog();
        }

        private bool LoadQuizFromFile(String fileName)
        {
            try
            {
                m_quiz = Quiz.LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
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

        private ThemeChooser.ChoosedOption ShowChooseThemeForm()
        {
            while (true)
            {
                var themeChooser = new ThemeChooser();
                themeChooser.themes = m_quiz.Themes;
                themeChooser.UpdateComponents();
                themeChooser.ShowDialog();
                if (themeChooser.result == ThemeChooser.ChoosedOption.StartTest)
                {
                    m_choosenTheme = themeChooser.SelectedTheme;
                    return themeChooser.result;
                }
                else
                {
                    return themeChooser.result;
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
            }
            else
            {
                MessageBox.Show($"Вы набрали {score} баллов. Минимальный проходной балл {m_choosenTheme.CurrentLevel.MinScore}. Надеемся в следующий раз вам повезет", "Результаты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
