﻿using System;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyBandPage : ContentPage
	{
        // Index View Model to help manage battle data across pages
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

		/// <summary>
		/// Constructor
		/// </summary>
		public MyBandPage()
		{
			InitializeComponent();
			Title = "My Band";

            // Start battle engine state with a cleared character list
			BindingContext = EngineViewModel;
			EngineViewModel.PartyCharacterList.Clear();
		}

		/// <summary>
		/// Jump to the Battle
		/// 
		/// Its Modal because don't want user to come back...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void BattleButton_Clicked(object sender, EventArgs e)
		{
			//Disabled until we implement Battle engine!
			//await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
			//await Navigation.PopAsync();
		}

        /// <summary>
        /// Open a character recruit page so user can add a character to the band.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void RecruitCharacter_Clicked(object sender, EventArgs e)
        {

        }
	}
}