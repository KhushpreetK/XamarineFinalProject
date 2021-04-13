using System;
using System.Collections.Generic;
using projectFinal.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;



using Xamarin.Forms;

namespace projectFinal
{
    public partial class QuestionsPage : ContentPage
    {
       
        public QuestionsPage()
        {
            InitializeComponent();
            getQuiz();

        }

        
        private async void getQuiz()
        {
            string url = "";
            if (Global.type == "Computers")
            {
                url = "https://opentdb.com/api.php?amount=3&category=18&difficulty=easy&type=boolean";


            }
            if (Global.type == "Sports")
            {
                url = "https://opentdb.com/api.php?amount=3&category=21&difficulty=easy&type=boolean";


            }
            if (Global.type == "General Knowledge")
            {
                 url = "https://opentdb.com/api.php?amount=3&category=9&difficulty=easy&type=boolean";

                
            }

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var compCategory = JsonConvert.DeserializeObject<MainClass>(response);
                List<Result> cs = new List<Result>();
                cs = compCategory.results;
                Global.result = cs;

                label0.Text = cs[0].question.ToString();
                label1.Text = cs[1].question.ToString();
                label2.Text = cs[2].question.ToString();

                Global.ques1 = cs[0].question.ToString();
                Global.ques2 = cs[1].question.ToString();
                Global.ques3 = cs[2].question.ToString();


                Global.ques1ans = cs[0].correct_answer.ToString();
                Global.ques2ans = cs[1].correct_answer.ToString();
                Global.ques3ans = cs[2].correct_answer.ToString();

            }

        }
        void btn1True_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.ans1 = "True";
            btn1False.IsEnabled = false;
            btn1True.IsEnabled = false;
            btn1True.BackgroundColor = Color.MediumPurple;
            btn1True.TextColor = Color.Black;

            //this alert is just for testing our selected answer and the actual answer that is related to this question from API.
            DisplayAlert("Question 1", "Your selected answer is " + Global.ans1 + "\nThe actual answer is " + Global.ques1ans, "OK");
        }

        void btn1False_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.ans1 = "False";
            btn1False.IsEnabled = false;
            btn1False.BackgroundColor = Color.MediumPurple;
            btn1False.TextColor = Color.Black;
            btn1True.IsEnabled = false;
            DisplayAlert("Question 1", "Your selected answer is " + Global.ans1 + "\nThe actual answer is " + Global.ques1ans, "ok");
        }

        void btn2True_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.ans2 = "True";
            btn2False.IsEnabled = false;
            btn2True.IsEnabled = false;
            btn2True.BackgroundColor = Color.MediumPurple;
            btn2True.TextColor = Color.Black;
            DisplayAlert("Question 2", "Your selected answer is " + Global.ans2 + "\nThe actual answer is " + Global.ques2ans, "ok");
        }

        void btn2False_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.ans2 = "False";
            btn2False.IsEnabled = false;
            btn2False.BackgroundColor = Color.MediumPurple;
            btn2False.TextColor = Color.Black;
            btn2True.IsEnabled = false;
            DisplayAlert("Question 2", "Your selected answer is " + Global.ans2 + "\nThe actual answer is " + Global.ques2ans, "ok");
        }

        void btn3True_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.ans3 = "True";
            btn3False.IsEnabled = false;
            btn3True.IsEnabled = false;
            btn3True.BackgroundColor = Color.MediumPurple;
            btn3True.TextColor = Color.Black;
            DisplayAlert("Question 3", "Your selected answer is " + Global.ans3 + "\nThe actual answer is " + Global.ques3ans, "ok");
        }

        void btn3False_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.ans3 = "False";
            btn3False.IsEnabled = false;
            btn3False.BackgroundColor = Color.MediumPurple;
            btn3False.TextColor = Color.Black;
            btn3True.IsEnabled = false;
            DisplayAlert("Question 3", "Your selected answer is " + Global.ans3 + "\nThe actual answer is " + Global.ques3ans, "ok");
        }
        

        void btnSubmit_Clicked(System.Object sender, System.EventArgs e)
        {
            int count=0;
            
                if (Global.ques1ans == Global.ans1)
                {
                    count++;
                }
                else
                {
                count = 0;
                }
                if (Global.ques2ans == Global.ans2)
                {
                    count++;
                }
                
                if (Global.ques3ans == Global.ans3)
                {
                    count++;
                }
               
           

           
            Global.score = count;
            Navigation.PushAsync(new ResultPage(Global.score));

        }
    }
}
