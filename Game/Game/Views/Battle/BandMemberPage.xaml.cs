﻿using System;
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
        void Remove_Clicked(object sender, EventArgs e)
        {
            // if user has already clicked Remove once, then we can proceed
            if (RemoveConfirmedMessage.IsVisible == true)
            {
                RemoveConfirmed_Clicked(sender, e);
            }

            RemoveConfirmedMessage.IsVisible = true;
        }

        /// <summary>
        /// Handle event when user confirms they want to remove this band member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void RemoveConfirmed_Clicked(object sender, EventArgs e)
        {
            // Refund Beats and remove character from band
            EngineViewModel.Beats += ViewModel.Data.TotalExperience;
            EngineViewModel.PartyCharacterList.Remove(ViewModel.Data);

            await Navigation.PopAsync();
        }
    }
}
