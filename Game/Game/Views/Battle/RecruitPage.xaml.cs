using System;
using System.Collections.Generic;
using System.Linq;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;

namespace Game.Views.Battle
{
    /// <summary>
    /// Recruit Page, where user can recruit a character for their band
    /// </summary>
    public partial class RecruitPage : ContentPage
    {
        // Index View Model to help manage battle data across pages
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        // Character selected to recruit
        public CharacterModel Character;

        /// <summary>
        /// Constructor
        /// </summary>
        public RecruitPage()
        {
            InitializeComponent();
            Title = "Recruit";

            // Set up binding to BattleEngineViewModel
            BindingContext = EngineViewModel;

            // Character Picker should start at the first element
            CharacterPicker.SelectedIndex = 0;
        }

        /// <summary>
        /// Toolbar item for Cancel was clicked - pop the modal page and return to MyBandPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Toolbar item for Recruit was clicked - add this character to the band
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Recruit_Clicked(object sender, EventArgs e)
        {
            // Save a copy of the selected Character to the band/party
            EngineViewModel.PartyCharacterList.Add(new CharacterModel(Character));
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Event handler for character picker - sets the character selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_CharacterPicker(object sender, EventArgs e)
        {
            Character = (CharacterModel)CharacterPicker.SelectedItem;

            // Update display of stats
            LevelLabel.Text = Character.Level.ToString();
            ExperienceLabel.Text = Character.TotalExperience.ToString();
            HealthLabel.Text = Character.MaxHealth.ToString();
            DefenseLabel.Text = Character.Defense.ToString();
            AttackLabel.Text = Character.Attack.ToString();
            SpeedLabel.Text = Character.Speed.ToString();

            // Update image
            CharacterImage.Source = Character.IconURI;

            // Beats Required = Experience
            BeatsRequiredLabel.Text = Character.TotalExperience.ToString();
        }
    }
}
