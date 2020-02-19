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
        GenericViewModel<MonsterModel> ViewModel { get; set; }
        int[] LevelValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            data.Data = new MonsterModel();

            BindingContext = this.ViewModel = data;
            MonsterLevelPicker.SelectedItem = data.Data.Level.ToString();
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
        /// Event handler for type picker - sets the character stats to the type default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterLevelPicker(object sender, EventArgs e)
        {
            // Update default character type
            var currName = ViewModel.Data.Name;

            int newLevel = (int)MonsterLevelPicker.SelectedItem;

            ViewModel.Data.ScaleToLevel(newLevel);

            ViewModel.Data.Name = currName;

            // Update the labels to display character type default stats
            LevelLabel.Text = ViewModel.Data.Level.ToString();
            ExperienceLabel.Text = ViewModel.Data.ExperienceGiven.ToString();
            MaxHealthLabel.Text = ViewModel.Data.MaxHealth.ToString();
            DefenseLabel.Text = ViewModel.Data.Defense.ToString();
            AttackLabel.Text = ViewModel.Data.Attack.ToString();
            SpeedLabel.Text = ViewModel.Data.Speed.ToString();

        }


        ///// <summary>
        ///// Catch the change to the Stepper for Health
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Health_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    HealthValue.Text = String.Format("{0}", e.NewValue);
        //}

        ///// <summary>
        ///// Catch the change to the Stepper for Defense
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    DefenseValue.Text = String.Format("{0}", e.NewValue);
        //}

        ///// <summary>
        ///// Catch the change to the Stepper for Attack
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    AttackValue.Text = String.Format("{0}", e.NewValue);
        //}

        ///// <summary>
        ///// Catch the change to the Stepper for Speed
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    SpeedValue.Text = String.Format("{0}", e.NewValue);
        //}
        ///// <summary>
        ///// Catch the change to the Stepper for Range
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Range_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    RangeValue.Text = String.Format("{0}", e.NewValue);
        //}

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