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
        public async void MyBand_Button_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new MyBandPage()); 
		}


		public async void Encyclopedia_Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EncyclopediaPage());
		}

		public async void HighScore_Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new HighScorePage(new GenericViewModel<ScoreModel>())));
		}

		/*public async void Demotape_Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new GamePage());
		}*/
	}
}