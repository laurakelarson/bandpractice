using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Monsters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {

        // View Model for Monster
        readonly GenericViewModel<MonsterModel> ViewModel;
        // Variable to hold starting state of Monster in case 
        // user hits cancel during update
        MonsterModel startingState;
        int startingLevel;

        /// <summary>
        /// Constructor for Monster Update Page. 
        /// </summary>
        /// <param name="data"></param>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            startingLevel = data.Data.Level;
            InitializeComponent();

            BindingContext = ViewModel = data;
            LevelLabel.Text = startingLevel.ToString();

            // Load values into level picker
            for (var i = 1; i <= 20; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }

            startingState = new MonsterModel(data.Data);
            startingState.Level = startingLevel;

            this.ViewModel.Title = "Update";

        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

            // Revert Character attributes back to starting state
            ViewModel.Data.Update(startingState);
        }

        /// <summary>
        /// Event handler for type picker - sets the character stats to the type default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterLevelPicker(object sender, EventArgs e)
        {

            // Scale character to new level
            int level = int.Parse((string)LevelPicker.SelectedItem);
            ViewModel.Data.ChangeLevel(level);
            ViewModel.Data.ExperienceGiven = LevelAttributesHelper.Instance.LevelAttributesList[level].Experience;


            // Update the labels to display monster type default stats
            LevelLabel.Text = ViewModel.Data.Level.ToString();
            ExperienceLabel.Text = ViewModel.Data.ExperienceGiven.ToString();
            MaxHealthLabel.Text = ViewModel.Data.MaxHealth.ToString();
            DefenseLabel.Text = ViewModel.Data.Defense.ToString();
            AttackLabel.Text = ViewModel.Data.Attack.ToString();
            SpeedLabel.Text = ViewModel.Data.Speed.ToString();
            RangeLabel.Text = ViewModel.Data.Range.ToString();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Edit_Guaranteed_Items_Clicked(object sender, EventArgs e)
        {
            // Disable button until we can get CollectionView to work
            //await Navigation.PushModalAsync(new NavigationPage(new MonsterItemSelection()));

        }

        
    }
}