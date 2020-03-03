using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// Create Item Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ItemCreatePage : ContentPage
    {
        // The item to create
        GenericViewModel<ItemModel> ViewModel { get; set; }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            data.Data = new ItemModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = data.Data.Location.ToString();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();

            // Force the pickers to be in selected state, so user must pick a valid selection
            LocationPicker.SelectedIndex = 0;
            AttributePicker.SelectedIndex = 0;
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Check input of Name and Description (cannot be empty)
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                NameWarning.IsVisible = true;
                return;
            }
            if (string.IsNullOrEmpty(ViewModel.Data.Description))
            {
                DescriptionWarning.IsVisible = true;
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
        /// Catch the change to the Stepper for Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Range_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            RangeValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Damage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Damage_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DamageValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}