using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;
using Game.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreatePage : ContentPage
    {
        // View Model for Character
        GenericViewModel<CharacterModel> ViewModel;

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CharacterCreatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            data.Data = DataHelper.DefaultTambourine();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";

            CharacterTypePicker.SelectedItem = data.Data.Type.ToString();
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Check input of Name (cannot be empty)
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                NameWarning.IsVisible = true;
                return;
            }

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

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
        void Changed_CharacterTypePicker(object sender, EventArgs e)
        {
            // Update default character type
            var currName = ViewModel.Data.Name;

            var newType = CharacterTypeEnumHelper.ConvertStringToEnum(CharacterTypePicker.SelectedItem.ToString());

            ViewModel.Data.Update(DataHelper.DefaultCharacter(newType));

            ViewModel.Data.Name = currName;

            // Update the labels to display character type default stats
            LevelLabel.Text = ViewModel.Data.Level.ToString();
            ExperienceLabel.Text = ViewModel.Data.TotalExperience.ToString();
            MaxHealthLabel.Text = ViewModel.Data.MaxHealth.ToString();
            DefenseLabel.Text = ViewModel.Data.Defense.ToString();
            AttackLabel.Text = ViewModel.Data.Attack.ToString();
            SpeedLabel.Text = ViewModel.Data.Speed.ToString();

            // Update displayed character image
            IconImage.Source = ViewModel.Data.IconURI;
        }
    }
}