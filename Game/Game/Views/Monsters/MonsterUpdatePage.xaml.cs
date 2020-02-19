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
        int OriginalLevel = 1;
        string Img;

        /// <summary>
        /// Constructor for Monster Update Page. 
        /// </summary>
        /// <param name="data"></param>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
            MonsterLevelPicker.SelectedItem = data.Data.Level.ToString();
            OriginalLevel = ViewModel.Data.Level;
            Img = ViewModel.Data.ImageURI;
            LevelLabel.Text = OriginalLevel.ToString();
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
            int newLevel = int.Parse((string)MonsterLevelPicker.SelectedItem);

            ViewModel.Data.Update(new MonsterModel());
            ViewModel.Data.ScaleToLevel(OriginalLevel, newLevel);

            ViewModel.Data.Name = currName;
            ViewModel.Data.Level = newLevel;
            ViewModel.Data.ImageURI = Img;

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

        ///// <summary>
        ///// Catch the change to the Stepper for Range
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Range_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    RangeValue.Text = String.Format("{0}", e.NewValue);
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
        ///// Catch the change to the Stepper for Defense
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    DefenseValue.Text = String.Format("{0}", e.NewValue);
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
        ///// Catch the change to the Stepper for Health
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void Health_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //    Health.Text = String.Format("{0}", e.NewValue);
        //}
    }
}