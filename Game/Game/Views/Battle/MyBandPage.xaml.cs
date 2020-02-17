using System;
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
		/// <summary>
		/// Constructor
		/// </summary>
		public MyBandPage()
		{
			InitializeComponent ();
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
	}
}