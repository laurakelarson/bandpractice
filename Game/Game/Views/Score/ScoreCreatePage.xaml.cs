﻿using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ScoreCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ScoreModel> ViewModel { get; set; }

        // Constructor for Unit Testing
        public ScoreCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ScoreCreatePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();

            data.Data = new ScoreModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create";
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // Check input of Name (cannot be empty)
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                NameWarning.IsVisible = true;
                return;
            }
            if (string.IsNullOrEmpty(ScoreEntry.Text))
            {
                ScoreWarning.IsVisible = true;
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
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}