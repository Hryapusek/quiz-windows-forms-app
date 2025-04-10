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
            this.label1 = new System.Windows.Forms.Label();
            this.themeCombobox = new System.Windows.Forms.ComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.chooseTheme = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.editThemeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите тему";
            // 
            // themeCombobox
            // 
            this.themeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeCombobox.FormattingEnabled = true;
            this.themeCombobox.Location = new System.Drawing.Point(204, 97);
            this.themeCombobox.Name = "themeCombobox";
            this.themeCombobox.Size = new System.Drawing.Size(341, 28);
            this.themeCombobox.TabIndex = 1;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(200, 54);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(73, 20);
            this.levelLabel.TabIndex = 2;
            this.levelLabel.Text = "Уровень";
            // 
            // chooseTheme
            // 
            this.chooseTheme.Location = new System.Drawing.Point(52, 164);
            this.chooseTheme.Name = "chooseTheme";
            this.chooseTheme.Size = new System.Drawing.Size(114, 44);
            this.chooseTheme.TabIndex = 3;
            this.chooseTheme.Text = "Выбрать";
            this.chooseTheme.UseVisualStyleBackColor = true;
            this.chooseTheme.Click += new System.EventHandler(this.chooseTheme_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(431, 164);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(114, 44);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // editThemeBtn
            // 
            this.editThemeBtn.Location = new System.Drawing.Point(232, 164);
            this.editThemeBtn.Name = "editThemeBtn";
            this.editThemeBtn.Size = new System.Drawing.Size(144, 44);
            this.editThemeBtn.TabIndex = 5;
            this.editThemeBtn.Text = "Редактировать";
            this.editThemeBtn.UseVisualStyleBackColor = true;
            // 
            // ThemeChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 239);
            this.Controls.Add(this.editThemeBtn);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.chooseTheme);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.themeCombobox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ThemeChooser";
            this.Text = "ThemeChooser";
            this.ResumeLayout(false);
            this.PerformLayout();

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