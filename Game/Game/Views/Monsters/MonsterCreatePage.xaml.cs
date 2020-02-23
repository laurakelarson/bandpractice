using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using Game.Views.Monsters;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// Create Monster
    /// </summary>
   // [DesignTimeVisible(false)]
    public partial class MonsterCreatePage : ContentPage
    {
        // The Monster to create
        GenericViewModel<MonsterModel> ViewModel;

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            data.Data = new MonsterModel();

            BindingContext = this.ViewModel = data;
            for (var i = 1; i <= 20; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }
            LevelPicker.SelectedItem = 1.ToString();

            this.ViewModel.Title = "Create";
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.EntityService.DefaultMonsterImageURI;
            }

            // Send "Create" message and pop the page from the stack 
            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Event handler for level picker - sets the monster stats to the level table values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterLevelPicker(object sender, EventArgs e)
        {
            // Update default character type
            var currName = ViewModel.Data.Name;
            int newLevel = int.Parse((string)LevelPicker.SelectedItem);

            ViewModel.Data.ChangeLevel(newLevel);

            ViewModel.Data.Name = currName;
            ViewModel.Data.Level = newLevel;

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
        /// Event handler for type picker - sets the character stats to the type default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterTypePicker(object sender, EventArgs e)
        {
            // Update default monster type
            var currName = ViewModel.Data.Name;

            var newType = DefaultMonsterHelper.ConvertStringToEnum(MonsterTypePicker.SelectedItem.ToString());

            ViewModel.Data.Update(DefaultMonsterHelper.DefaultMonster(newType));

            ViewModel.Data.Name = currName;

            // Update displayed monster image
            IconImage.Source = ViewModel.Data.ImageURI;
        }

        /// <summary>
        /// Opens item selection modal page
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