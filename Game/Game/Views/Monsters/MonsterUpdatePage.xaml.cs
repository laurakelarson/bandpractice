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
        MonsterModel ProposedMonster;

        /// <summary>
        /// Constructor for Monster Update Page. 
        /// </summary>
        /// <param name="data"></param>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = ViewModel = data;
            for (var i = 1; i <= 20; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }
            Img = ViewModel.Data.ImageURI;
            ProposedMonster = new MonsterModel();
            this.ViewModel.Title = "Update";
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Update", ProposedMonster);
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
            int newLevel = int.Parse((string)LevelPicker.SelectedItem);

            ProposedMonster.Update(new MonsterModel());
            //ProposedMonster.ScaleToLevel(OriginalLevel, newLevel);

            ProposedMonster.Name = currName;
            ProposedMonster.Level = newLevel;
            ProposedMonster.ImageURI = Img;

            // Update the labels to display monster type default stats
            LevelLabel.Text = ProposedMonster.Level.ToString();
            ExperienceLabel.Text = ProposedMonster.ExperienceGiven.ToString();
            MaxHealthLabel.Text = ProposedMonster.MaxHealth.ToString();
            DefenseLabel.Text = ProposedMonster.Defense.ToString();
            AttackLabel.Text = ProposedMonster.Attack.ToString();
            SpeedLabel.Text = ProposedMonster.Speed.ToString();
            RangeLabel.Text = ProposedMonster.Range.ToString();

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