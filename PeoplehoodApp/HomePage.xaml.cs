using PeoplehoodApp.Models;
using PeoplehoodApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeoplehoodApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        PeopleViewModel viewModel { get; set; }

        public HomePage()
        {
            viewModel = new PeopleViewModel();
            InitializeComponent();
        }

        void IsShowIndicator(bool isShown)
        {
            Indicator.IsVisible = isShown;
            Indicator.IsEnabled = isShown;
            Indicator.IsRunning = isShown;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string IdNumber = IDNumber.Text;
            if(string.IsNullOrWhiteSpace(IdNumber))
            {
                _ = DisplayAlert("Alert", "Please enter valid ID", "Ok");
            } else
            {
                IsShowIndicator(true);
                People people = await viewModel.GetPeopleWithID(IdNumber);
                IsShowIndicator(false);
                if (people != null)
                {
                    await Navigation.PushAsync(new PeopleDetailPage(people));
                }
                else
                {
                    _ = DisplayAlert("Alert", "Information is not available", "Ok");
                }
            }

        }

        private void ValidateButton_Clicked(Object sender, EventArgs e)
        {
            string IdNumber = IDNumber.Text;
            if (viewModel.IsValidSAID(IdNumber))
            {
                _ = DisplayAlert("Info", "Entered ID is a valid SA ID", "Ok");
            }
            else
            {
                _ = DisplayAlert("Info", "Entered ID is not valid SA ID", "Ok");
            }
        }
    }
}