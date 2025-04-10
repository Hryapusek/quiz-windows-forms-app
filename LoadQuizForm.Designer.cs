namespace tema6
{
    partial class LoadQuizForm
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
            chooseFileButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // chooseFileButton
            // 
            chooseFileButton.Location = new System.Drawing.Point(261, 75);
            chooseFileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chooseFileButton.Name = "chooseFileButton";
            chooseFileButton.Size = new System.Drawing.Size(166, 42);
            chooseFileButton.TabIndex = 0;
            chooseFileButton.Text = "Выбрать файл";
            chooseFileButton.UseVisualStyleBackColor = true;
            chooseFileButton.Click += chooseFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(99, 14);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(499, 40);
            label1.TabIndex = 1;
            label1.Text = "Добро пожаловать в приложение для прохождения квизов!\r\nПожалуйста, выберите файл с квизом для начала прохождения";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadQuizForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(705, 153);
            Controls.Add(label1);
            Controls.Add(chooseFileButton);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LoadQuizForm";
            Text = "LoadQuizForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Label label1;
    }
}