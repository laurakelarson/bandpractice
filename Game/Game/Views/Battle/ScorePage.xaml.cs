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
		/// <summary>
		/// Constructor
		/// </summary>
		public ScorePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Attack Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void CloseButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		/// <summary>
		/// Button click method to open High Score modal page to display highest achieved score
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void HighScoreButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new HighScorePage(new GenericViewModel<ScoreModel>())));
		}
	}
}