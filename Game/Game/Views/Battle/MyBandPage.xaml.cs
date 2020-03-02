using System;
using Game.Models;
using Game.ViewModels;
using Game.Views.Battle;
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

            // Bind to battle engine instance
			BindingContext = EngineViewModel;
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
			await Navigation.PushModalAsync(new NavigationPage(new RecruitPage()));
		}

        /// <summary>
        /// Opens up a Band Member detail page, where user has the option to remove the band member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
			CharacterModel data = args.SelectedItem as CharacterModel;
			if (data == null)
			{
				return;
			}

			// Open the Band Member Page
			await Navigation.PushAsync(new BandMemberPage(new GenericViewModel<CharacterModel>(data)));

			// Manually deselect item.
			CharactersListView.SelectedItem = null;
		}
	}
}