using System;
using System.Collections.Generic;
using projectFinal.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;

using Xamarin.Forms;

namespace projectFinal
{
    public partial class SelectType : ContentPage
    {
        public SelectType()
        {
            InitializeComponent();
            string[] type = { "Computers", "Sports", "General Knowledge" };
            selectTypeView.ItemsSource = type;
            
        }

        
        

        void selectTypeView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Global.type = selectTypeView.SelectedItem.ToString();
            Navigation.PushAsync(new QuestionsPage());

        }
    }
}
