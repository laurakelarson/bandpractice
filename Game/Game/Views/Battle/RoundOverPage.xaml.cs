﻿using System;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Round Over Page
    /// Displays the items equipped from the item pool after the round is over.
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoundOverPage: ContentPage
	{
		// Index View Model to help manage battle data across pages
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

		/// <summary>
		/// Constructor
		/// </summary>
		public RoundOverPage()
		{
			InitializeComponent();

			// end the round - characters distribute item pool
			BattleEngineViewModel.Instance.Engine.EndRound();

			// Display the items equipped during the round
            ItemsLabel.Text = EngineViewModel.Engine.BattleMessages.GetItemsEquippedMessage();
        }

		/// <summary>
		/// Advance to the next round
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void NextRound_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}