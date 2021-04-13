using System;
using System.Collections.Generic;
using projectFinal.Model;
using Xamarin.Forms;

namespace projectFinal
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage(int score)
        {
            InitializeComponent();
            lblScore.Text = Global.score.ToString();
            FirebaseHelper fb = new FirebaseHelper();
            fb.AddScore();
        }

        void btnPlayAgain_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectType());
        }

    }
}
