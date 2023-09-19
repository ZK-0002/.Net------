using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int numQuestions = 10; 
        private int currentQuestion = 0;
        private int correctAnswers = 0;
        private int time = 10; 
        private Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartNewQuiz();
        }

        private void StartNewQuiz()
        {
            currentQuestion = 0;
            correctAnswers = 0;
            UpdateScore();
            GenerateQuestion();
            timer.Start();
        }

        private void GenerateQuestion()
        {
            int operand1 = random.Next(1, 11); 
            int operand2 = random.Next(1, 11);
            int operation = random.Next(0, 2); 

            string operatorStr = (operation == 0) ? "+" : "-";

            int answer = 0;

            switch (operation)
            {
                case 0:
                    answer = operand1 + operand2;
                    break;
                case 1:
                    answer = operand1 - operand2;
                    break;
            }

            label1.Text = operand1 + operatorStr + operand2 + "= ?";
            correctAnswer = answer;
        }

        private int correctAnswer;

        private void CheckAnswer(int userAnswer)
        {
            if (userAnswer == correctAnswer)
            {
                correctAnswers++;
                label2.Text = "回答正确！";
                label2.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label2.Text = "回答错误！";
                label2.ForeColor = System.Drawing.Color.Red;
            }

            currentQuestion++;

            if (currentQuestion < numQuestions)
            {
                GenerateQuestion();
                textBox1.Text = "";
            }
            else
            {
                EndQuiz();
            }
        }

        private void EndQuiz()
        {
            timer.Stop();
            MessageBox.Show("答题结束！你的得分是:" + correctAnswers + "/" + numQuestions);
            StartNewQuiz();
        }

        private void UpdateScore()
        {
            label3.Text = "得分:" + correctAnswers + "/" + currentQuestion;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;

            if (time <= 0)
            {
                timer.Stop();
                MessageBox.Show("时间到！本题跳过。");
                currentQuestion++;
                if (currentQuestion < numQuestions)
                {
                    GenerateQuestion();
                    textBox1.Text = "";
                    timer.Start();
                }
                else
                {
                    EndQuiz();
                }
            }

            label4.Text = "剩余时间: "+ time.ToString() + "秒";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int userAnswer))
            {
                CheckAnswer(userAnswer);
                UpdateScore();
            }
            else
            {
                MessageBox.Show("请输入一个有效的整数答案");
            }
        }
    }
}
