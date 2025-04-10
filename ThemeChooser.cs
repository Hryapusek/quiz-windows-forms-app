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
    public partial class ThemeChooser : Form
    {
        internal enum ChoosedOption
        {
            StartTest,
            EditTheme,
            Close
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<Theme> themes { get; set; }
        internal ChoosedOption result = ChoosedOption.Close;
        internal Theme SelectedTheme
        {
            get
            {
                return themes[this.themeCombobox.SelectedIndex];
            }
        }

        public ThemeChooser()
        {
            InitializeComponent();
            this.themeCombobox.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (themes.Count == 0 || this.themeCombobox.SelectedIndex == -1)
            {
                return;
            }
            this.levelLabel.Text = "Уровень " + this.themes[this.themeCombobox.SelectedIndex].CurrentLevel.DifficultyLevel;
        }

        public void UpdateComponents()
        {
            this.themeCombobox.Items.Clear();
            foreach (Theme theme in this.themes)
            {
                this.themeCombobox.Items.Add(theme.Name);
            }
            if (themes.Count > 0)
            {
                this.themeCombobox.SelectedIndex = 0;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            result = ChoosedOption.Close;
            this.Close();
        }

        private void chooseTheme_Click(object sender, EventArgs e)
        {
            result = ChoosedOption.StartTest;
            this.Close();
        }

        private void editThemeBtn_Click(object sender, EventArgs e)
        {
            result = ChoosedOption.EditTheme;
            this.Close();
        }
    }
}
