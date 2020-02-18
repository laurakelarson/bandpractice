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

            ItemModel getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.HeadItem);
            if (getItem != null)
            {
                HeadLabel.Text = getItem.Name;
            }

            getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.BodyItem);
            if (getItem != null)
            {
                BodyLabel.Text = getItem.Name;
            }

            getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.PrimaryHandItem);
            if (getItem != null)
            {
                PrimaryHandLabel.Text = getItem.Name;
            }

            getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.OffHandItem);
            if (getItem != null)
            {
                OffHandLabel.Text = getItem.Name;
            }

            getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.RightFingerItem);
            if (getItem != null)
            {
                RightFingerLabel.Text = getItem.Name;
            }

            getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.LeftFingerItem);
            if (getItem != null)
            {
                LeftFingerLabel.Text = getItem.Name;
            }

            getItem = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.FeetItem);
            if (getItem != null)
            {
                FeetLabel.Text = getItem.Name;
            }
        }
    }
}