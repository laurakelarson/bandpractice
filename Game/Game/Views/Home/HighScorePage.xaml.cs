using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HighScorePage : ContentPage
    {
        private GenericViewModel<ScoreModel> genericViewModel;

        GenericViewModel<ScoreModel> ViewModel { get; set; }

        public HighScorePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();


        }

        /// <summary>
        /// Close the modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cool_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }


}