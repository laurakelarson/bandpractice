using System;
using System.Collections.Generic;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;

namespace Game.Views.Battle
{
    /// <summary>
    /// Band Member page displays the character's details
    /// </summary>
    public partial class BandMemberPage : ContentPage
    {
        // View Model for item
        readonly GenericViewModel<CharacterModel> ViewModel;

        // Index View Model to help manage battle data across pages
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        public BandMemberPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();
            Title = "Band Member";

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Handle event when user clicks Remove toolbar item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Remove_Clicked(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handle event when user clicks OK toolbar item
        /// Pop the current page to return to My Band Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OK_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
