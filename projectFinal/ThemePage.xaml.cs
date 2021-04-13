using System;
using System.Collections.Generic;
using projectFinal.Model;
using Xamarin.Forms;

namespace projectFinal
{
    public partial class ThemePage : ContentPage
    {
        public ThemePage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.name = enterName.Text.ToString();
            Navigation.PushAsync(new SelectType());

        }

        void btnSeeRecord_Clicked(System.Object sender, System.EventArgs e)
        {
            Global.name = enterName.Text.ToString();
            Navigation.PushAsync(new RecordsPage());
        }
    }
}
