using Game.Models;
using Game.ViewModels;
using Game.Views.Home;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScorePage: ContentPage
	{

		// View Model for Score
		readonly GenericViewModel<ScoreModel> ViewModel;

		/// <summary>
		/// Constructor
		/// </summary>
		public ScorePage (GenericViewModel<ScoreModel> data, ScoreModel score)
		{

			InitializeComponent ();
			data.Data = score;
			BindingContext = this.ViewModel = data;
			
		}

		/// <summary>
		/// Attack Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void CloseButton_Clicked(object sender, EventArgs e)
		{
			// also need to pop the autobattle page
			// Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count-1]);

			await Navigation.PopModalAsync();
			

		}

		/// <summary>
		/// Button click method to open High Score modal page to display highest achieved score
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void HighScoreButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new HighScorePage(ViewModel.Data)));
		}
	}
}