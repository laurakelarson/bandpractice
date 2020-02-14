using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public GamePage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        async void BattleButton_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new PickCharactersPage());
		}

		/// <summary>
		/// Jump to the Encyclopedia
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void EncyclopediaButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new EncyclopediaPage());
		}

		/// <summary>
		/// Jump to the Dungeon
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void DemoTapeButton_Clicked(object sender, EventArgs e)
		{
			// Run the Autobattle simulation from here

			// Call to the Score Page
			await Navigation.PushModalAsync(new NavigationPage(new ScorePage()));
		}
	}
}