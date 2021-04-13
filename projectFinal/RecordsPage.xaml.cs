using System;
using System.Collections.Generic;
using projectFinal.Model;

using Xamarin.Forms;

namespace projectFinal
{
    public partial class RecordsPage : ContentPage
    {
        FirebaseHelper fh = new FirebaseHelper();
        public RecordsPage()
        {
            InitializeComponent();
            playerName.Text = Global.name;
            displayRecords();
            
        }
        //display record 
        public async void displayRecords()
        {
            var record = await fh.getScore(Global.name);
            recordlView.ItemsSource = record;
        }

        void btnBackToThemePage_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ThemePage());
        }
    }
}
