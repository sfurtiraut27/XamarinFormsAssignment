using PeoplehoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeoplehoodApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleDetailPage : ContentPage
    {
        public People selectedPeople { get; set; }
        public PeopleDetailPage(People people)
        {
            selectedPeople = people;
            BindingContext = selectedPeople;
            InitializeComponent();
        }
    }
}