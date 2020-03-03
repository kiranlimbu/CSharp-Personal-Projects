using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace QuizInterface
{
    public partial class Form1 : Form
    {
        /* Global variables */
        Button btn;

        //first question
        int idx = 0;

        int score = 0;
        int scoreChoice = 0;
        int totalScore = 0;
        bool value = false;
 
        int questionNumber = 1; // initialize question number
        string result = "ans"; // initialize correct answer name

        public Form1()
        {
            InitializeComponent();
            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 4;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 4;

            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            infoLbl.Visible = false;
            textQuestion.Visible = false;
            quizNum.Visible = false;
            scoreLbl.Visible = false;
            EntryNote();
            welcomeNote.Visible = false;
        }

        public void EntryNote()
        {
            welcomeNote.Text = "Welcome to Microsoft System and Software Academy compitency test. \r\nThere are 40 questions.\r\nFor each question you will receive 1 points. \r\nYour score will be added and displayed at the end. \r\n\nGood Luck! \r\nHit next to start your test.";
            welcomeNote.Location = new Point(120, 100);
            welcomeNote.Size = new Size(300, 40);
        }

        
        private void nextBtn_Click(object sender, EventArgs e)
        {
            // Clear and Reset
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load_1(e, e);

            // Read JSON file
            string compitencyQuiz = File.ReadAllText(@"Compitency.json");
            Random rnd = new Random();
            QuestionCollection quesCollection;

            welcomeNote.Visible = false;
            scoreLbl.Visible = true;
            scoreLbl.Text = "Score: " + totalScore.ToString();
            scoreLbl.Location = new Point(600, 10);

            textQuestion.Visible = true;
            quizNum.Visible = true;

            quesCollection = JsonConvert.DeserializeObject<QuestionCollection>(compitencyQuiz);
            // generate random number
            //List<int> quizNumContainer = new List<int>();
            //idx = rnd.Next(0, quesCollection.Questions.Count);
            //while (quizNumContainer.Contains(idx) == true)
            //{
            //    idx = rnd.Next(0, quesCollection.Questions.Count);
            //}
            //quizNumContainer.Add(idx);

            // check if not last question
           if (idx < quesCollection.Questions.Count)
            {
                // display question number
                quizNum.Text = questionNumber.ToString() + ")";
                quizNum.Location = new Point(0, 10);
                quizNum.Padding = new Padding(5, 0, 5, 0);
                questionNumber++;

                // display question
                textQuestion.Text = quesCollection.Questions[idx].Quiz.ToString();
                textQuestion.Location = new Point(30, 10);
                textQuestion.Padding = new Padding(0, 0, 0, 10);

                // get Answers
                var answer = quesCollection.Questions[idx].Answer;

                // Create Dynamic Answer/Button
                // place dynamic Answer/Button
                int i = 0;
                int top = textQuestion.Height + 10;
                foreach (KeyValuePair<string, bool> item in answer)
                {
                    btn = new Button();
                    btn.Name = "ans" + i.ToString();
                    btn.Text = item.Key;
                    btn.AutoSize = true;
                    btn.Location = new Point(60, top);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.LightBlue;
                    this.Controls.Add(btn);
                    btn.Click += new EventHandler(this.button_click);
                    top += btn.Height + 10;
                    i += 1;
                    // capture correct answer
                    if (item.Value)
                    {
                        result = btn.Name;
                    }
                }

                // place label
                infoLbl.Location = new Point(60, top + 10);

                // Dynamic placement of Button NEXT
                nextBtn.Location = new Point(this.Width / 2, top + 30);

                // resets choice
                scoreChoice = 0;

                // next question
                idx += 1;
            }
           // if last question
           else 
            {
                afterLastQuestion(totalScore, quesCollection.Questions.Count, e);
            }
        }

        // Dynamic button even handler
        void button_click(object sender, EventArgs e)
        {
            // get avtive button
            Button btn = sender as Button;

            // check if active button is correct
            if (btn.Name == result)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Green;
            }
            else if (btn.Name != result)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.Red;
            }
            // display info Correct/Wrong
            value = (btn.Name == result);
            information(value);

            // takes only first answer
            scoreChoice += 1;

            // get score
            totalScore = scoreCalc(scoreChoice, value);

            // highlight next button
            nextBtn.FlatStyle = FlatStyle.Flat;
            nextBtn.FlatAppearance.BorderSize = 1;
            nextBtn.FlatAppearance.BorderColor = Color.Blue;
        }

        // score calculator
        public int scoreCalc(int x, bool y)
        {
            
            if (x <= 1 && y)
            {
                score += 1;
            }
            return score;
        }

        // Correct/Wrong info
        void information(bool condition)
        {
            infoLbl.Visible = true;
            infoLbl.ForeColor = Color.Red;

            if (condition)
            {
                infoLbl.ForeColor = Color.Green;
                infoLbl.Text = "Correct!";
            }
            else
            {
                infoLbl.Text = "Incorrect!";
            }  
        }

        public void afterLastQuestion(int x, int count, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load_1(e, e);

            infoLbl.Visible = false;
            textQuestion.Visible = false;
            quizNum.Visible = false;
            scoreLbl.Visible = false;
            nextBtn.Visible = false;

            welcomeNote.Visible = true;
            welcomeNote.Location = new Point(240, 100);

            float flt1 = x;
            float flt2 = count;
            float calc = (flt1 / flt2) * 100;
            int total = Convert.ToInt16(calc);

            if (total >= 60)
            {
                welcomeNote.Text = "Congratulation! You passed.\r\nYou scored: " + total.ToString() + "%";
            }
            else
            {
                welcomeNote.Text = "Sorry! You did not pass.\r\nYou scored: " + total.ToString() + "%";
            }
        }
    }
}
