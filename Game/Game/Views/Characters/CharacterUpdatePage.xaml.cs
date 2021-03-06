﻿using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {

        // The Character to create
        public GenericViewModel<CharacterModel> ViewModel { get; set; }

        // Empty Constructor for UTs
        public CharacterUpdatePage(bool UnitTest) { }

        // CharacterModel to hold starting state of Character
        // Use to restore CharacterModel in the event user cancels the update
        CharacterModel startingState;

        /// <summary>
        /// Constructor for CharacterUpdatePage
        /// </summary>
        /// <param name="data"></param>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            startingState = new CharacterModel(data.Data);

            this.ViewModel.Title = "Update";

            CharacterTypePicker.SelectedItem = data.Data.Type.ToString();
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // Check input of Name (cannot be empty)
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                NameWarning.IsVisible = true;
                return;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

            // Revert Character attributes back to starting state
            ViewModel.Data.Update(startingState);
        }

        /// <summary>
        /// Catch the change to the Stepper for Level.
        /// Character is scaled up/down to match the new Level,
        /// and displayed stats update to show the new values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Level_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            LevelLabel.Text = String.Format("{0}", e.NewValue);

            // Scale character to new level
            int level = (int)e.NewValue;
            ViewModel.Data.ChangeLevel(level);
            ViewModel.Data.TotalExperience = LevelAttributesHelper.Instance.LevelAttributesList[level].Experience;

            // Update the labels to display updated stats
            ExperienceLabel.Text = ViewModel.Data.TotalExperience.ToString();
            MaxHealthLabel.Text = ViewModel.Data.MaxHealth.ToString();
            DefenseLabel.Text = ViewModel.Data.Defense.ToString();
            AttackLabel.Text = ViewModel.Data.Attack.ToString();
            SpeedLabel.Text = ViewModel.Data.Speed.ToString();
        }

    }
}