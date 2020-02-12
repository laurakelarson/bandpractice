﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public HomePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Example of a Button Click (this one is Sync, if calling Async then needs to be Async)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public async void GameButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new GamePage());
		}

		/*public async void AutoButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AutoBattlePage());
		}*/

		public async void EncyclopediaButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new VillagePage());
		}

		/*public async void HighScoreButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GamePage());
		}*/
	}
}