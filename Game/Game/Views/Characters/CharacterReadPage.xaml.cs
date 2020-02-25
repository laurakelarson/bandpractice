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
    public partial class CharacterReadPage : ContentPage
    {
        // View Model for item
        readonly GenericViewModel<CharacterModel> ViewModel;

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            // Display the item names
            DisplayItemNames();
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls to delete the object in question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterDeletePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Displays the names of equipped items by querying the ItemIndexViewModel
        /// </summary>
        public void DisplayItemNames()
        {
            // walk through locations and display item name
            HeadLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.HeadItem);

            BodyLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.NecklassItem);

            PrimaryHandLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.PrimaryHandItem);

            OffHandLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.OffHandItem);

            RightFingerLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.RightFingerItem);

            LeftFingerLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.LeftFingerItem);

            FeetLabel.Text = ItemIndexViewModel.Instance.GetItemNameById(ViewModel.Data.FeetItem);
        }
    }
}