using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Newtonsoft.Json;
using Firebase.Auth;


//Comment-- General idea of the project
//https://opentdb.com/api.php?amount=3&category=18&difficulty=easy&type=boolean
//This the API that i want to use for this project.
//It is based on QUIZ questions as in this I will have 3 true/false questions
//I will read the question from this api into this application and will give the user 2 options.
//Either true or false. The selected option's data will be stored in a variable
// On submission, the  user will have an alert which will dispplay the right or wrong answer.
//THe use will perform the same step for all the three questions.
//There will be a SCORE button which on pressing will take the user to other page
//The user will be shown his scores.
//The scores will be stored in the Firebase database.


//Note:
// I still did not decide how to use this idea in 4 different pages
//I am figuring this out but this is what I have as a whole.

//sports api- https://opentdb.com/api.php?amount=3&category=21&difficulty=easy&type=boolean
//GK - https://opentdb.com/api.php?amount=3&category=9&difficulty=easy&type=boolean




namespace projectFinal
{
    public partial class MainPage : ContentPage
    {
        public string webApiKey = "AIzaSyConZ0ZalHGroQbLFQwkzI2yJC7E7sZTbI";

        public MainPage()
        {
            InitializeComponent();
        }

        async void sinupButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                await DisplayAlert("Sign-up", "New user is successfully created", "OK");
                UserNewEmail.Text = "";
                UserNewPassword.Text = "";
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }


        async private void loginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail.Text, UserPassword.Text);
                await DisplayAlert("Login successful", UserEmail.Text, "OK");
                UserEmail.Text = "";
                UserPassword.Text = "";
                await Navigation.PushAsync(new ThemePage());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
