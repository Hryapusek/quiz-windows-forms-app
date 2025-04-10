namespace tema6
{
    partial class TestForm
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.questionsBox = new System.Windows.Forms.GroupBox();
            this.nextQuestionBtn = new System.Windows.Forms.Button();
            this.prevQuestionBtn = new System.Windows.Forms.Button();
            this.finishBtn = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionLabel.AutoSize = true;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionLabel.Location = new System.Drawing.Point(314, 94);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(292, 29);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "Здесь будет ваш вопрос";
            // 
            // questionsBox
            // 
            this.questionsBox.Location = new System.Drawing.Point(186, 580);
            this.questionsBox.Name = "questionsBox";
            this.questionsBox.Size = new System.Drawing.Size(672, 192);
            this.questionsBox.TabIndex = 1;
            this.questionsBox.TabStop = false;
            // 
            // nextQuestionBtn
            // 
            this.nextQuestionBtn.Location = new System.Drawing.Point(834, 812);
            this.nextQuestionBtn.Name = "nextQuestionBtn";
            this.nextQuestionBtn.Size = new System.Drawing.Size(188, 35);
            this.nextQuestionBtn.TabIndex = 2;
            this.nextQuestionBtn.Text = "Следующий вопрос";
            this.nextQuestionBtn.UseVisualStyleBackColor = true;
            this.nextQuestionBtn.Click += new System.EventHandler(this.nextQuestionBtn_Click);
            // 
            // prevQuestionBtn
            // 
            this.prevQuestionBtn.Location = new System.Drawing.Point(57, 811);
            this.prevQuestionBtn.Name = "prevQuestionBtn";
            this.prevQuestionBtn.Size = new System.Drawing.Size(202, 37);
            this.prevQuestionBtn.TabIndex = 3;
            this.prevQuestionBtn.Text = "Предыдущий вопрос";
            this.prevQuestionBtn.UseVisualStyleBackColor = true;
            this.prevQuestionBtn.Click += new System.EventHandler(this.prevQuestionBtn_Click);
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(464, 812);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(188, 35);
            this.finishBtn.TabIndex = 4;
            this.finishBtn.Text = "Завершить";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressLabel.Location = new System.Drawing.Point(978, 43);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(59, 29);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.Text = "1/15";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(186, 175);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(672, 397);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 900);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.prevQuestionBtn);
            this.Controls.Add(this.nextQuestionBtn);
            this.Controls.Add(this.questionsBox);
            this.Controls.Add(this.questionLabel);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.GroupBox questionsBox;
        private System.Windows.Forms.Button nextQuestionBtn;
        private System.Windows.Forms.Button prevQuestionBtn;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}