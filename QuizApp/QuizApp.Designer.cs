namespace QuizInterface
{
    partial class Form1
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
            this.quizNum = new System.Windows.Forms.Label();
            this.textQuestion = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.infoLbl = new System.Windows.Forms.Label();
            this.welcomeNote = new System.Windows.Forms.Label();
            this.scoreLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // quizNum
            // 
            this.quizNum.AutoSize = true;
            this.quizNum.Location = new System.Drawing.Point(22, 10);
            this.quizNum.Name = "quizNum";
            this.quizNum.Size = new System.Drawing.Size(96, 25);
            this.quizNum.TabIndex = 0;
            this.quizNum.Text = "quizNum";
            // 
            // textQuestion
            // 
            this.textQuestion.AutoSize = true;
            this.textQuestion.CausesValidation = false;
            this.textQuestion.Location = new System.Drawing.Point(60, 10);
            this.textQuestion.MaximumSize = new System.Drawing.Size(800, 300);
            this.textQuestion.MinimumSize = new System.Drawing.Size(200, 10);
            this.textQuestion.Name = "textQuestion";
            this.textQuestion.Size = new System.Drawing.Size(200, 25);
            this.textQuestion.TabIndex = 1;
            this.textQuestion.Text = "question";
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.nextBtn.Location = new System.Drawing.Point(669, 650);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Padding = new System.Windows.Forms.Padding(10);
            this.nextBtn.Size = new System.Drawing.Size(174, 69);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLbl.Location = new System.Drawing.Point(93, 560);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(58, 31);
            this.infoLbl.TabIndex = 3;
            this.infoLbl.Text = "info";
            // 
            // welcomeNote
            // 
            this.welcomeNote.AutoSize = true;
            this.welcomeNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeNote.Location = new System.Drawing.Point(663, 167);
            this.welcomeNote.Name = "welcomeNote";
            this.welcomeNote.Size = new System.Drawing.Size(126, 31);
            this.welcomeNote.TabIndex = 4;
            this.welcomeNote.Text = "Welcome";
            // 
            // scoreLbl
            // 
            this.scoreLbl.AutoSize = true;
            this.scoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLbl.Location = new System.Drawing.Point(1338, 10);
            this.scoreLbl.Name = "scoreLbl";
            this.scoreLbl.Size = new System.Drawing.Size(81, 31);
            this.scoreLbl.TabIndex = 5;
            this.scoreLbl.Text = "score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 791);
            this.Controls.Add(this.scoreLbl);
            this.Controls.Add(this.welcomeNote);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.textQuestion);
            this.Controls.Add(this.quizNum);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label quizNum;
        private System.Windows.Forms.Label textQuestion;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Label welcomeNote;
        private System.Windows.Forms.Label scoreLbl;
    }
}

