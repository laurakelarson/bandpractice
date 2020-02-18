﻿using Xamarin.Forms;
using Game.Views;
using Game.ViewModels;
using Game.Helpers;

namespace Game
{
    /// <summary>
    /// Main Application entry point
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Default App Constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            DataSetsHelper.WarmUp();
            // Add each model here to warm up and load it.
            //ScoreIndexViewModel.Instance.GetCurrentDataSource();
            //ItemIndexViewModel.Instance.GetCurrentDataSource();
            //MonsterIndexViewModel.Instance.GetCurrentDataSource();
            //CharacterIndexViewModel.Instance.GetCurrentDataSource();

            // Call the Main Page to open
            MainPage = new MainPage();
        }

        /// <summary>
        /// On Startup code if needed
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// On Sleep code if needed
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// On App Resume code if needed
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}