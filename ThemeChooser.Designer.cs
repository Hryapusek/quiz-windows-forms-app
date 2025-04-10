namespace tema6
{
    partial class ThemeChooser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            themeCombobox = new System.Windows.Forms.ComboBox();
            levelLabel = new System.Windows.Forms.Label();
            chooseTheme = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            editThemeBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(41, 97);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 13);
            label1.TabIndex = 0;
            label1.Text = "Выберите тему";
            // 
            // themeCombobox
            // 
            themeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            themeCombobox.FormattingEnabled = true;
            themeCombobox.Location = new System.Drawing.Point(204, 97);
            themeCombobox.Name = "themeCombobox";
            themeCombobox.Size = new System.Drawing.Size(341, 21);
            themeCombobox.TabIndex = 1;
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new System.Drawing.Point(200, 54);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(51, 13);
            levelLabel.TabIndex = 2;
            levelLabel.Text = "Уровень";
            // 
            // chooseTheme
            // 
            chooseTheme.Location = new System.Drawing.Point(52, 164);
            chooseTheme.Name = "chooseTheme";
            chooseTheme.Size = new System.Drawing.Size(114, 44);
            chooseTheme.TabIndex = 3;
            chooseTheme.Text = "Выбрать";
            chooseTheme.UseVisualStyleBackColor = true;
            chooseTheme.Click += chooseTheme_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(431, 164);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(114, 44);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // editThemeBtn
            // 
            editThemeBtn.Location = new System.Drawing.Point(232, 164);
            editThemeBtn.Name = "editThemeBtn";
            editThemeBtn.Size = new System.Drawing.Size(144, 44);
            editThemeBtn.TabIndex = 5;
            editThemeBtn.Text = "Редактировать";
            editThemeBtn.UseVisualStyleBackColor = true;
            editThemeBtn.Click += editThemeBtn_Click;
            // 
            // ThemeChooser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(597, 239);
            Controls.Add(editThemeBtn);
            Controls.Add(cancelButton);
            Controls.Add(chooseTheme);
            Controls.Add(levelLabel);
            Controls.Add(themeCombobox);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            Name = "ThemeChooser";
            Text = "ThemeChooser";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox themeCombobox;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Button chooseTheme;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button editThemeBtn;
    }
}