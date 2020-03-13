using System;
using Game.Helpers;
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

			// Beats start at 0
			EngineViewModel.Beats = 0;

			// Bind to battle engine instance
			BindingContext = EngineViewModel;
			BeatsLabel.Text = EngineViewModel.Beats.ToString();

			// Set up default characters
			EngineViewModel.PartyCharacterList.Clear();
			EngineViewModel.PartyCharacterList.Add(DataHelper.DefaultDrummer());
			EngineViewModel.PartyCharacterList.Add(DataHelper.DefaultBassist());
			EngineViewModel.PartyCharacterList.Add(DataHelper.DefaultGuitarist());
			EngineViewModel.PartyCharacterList.Add(DataHelper.DefaultTambourine());
			EngineViewModel.PartyCharacterList.Add(DataHelper.DefaultLeadVocalist());
			EngineViewModel.PartyCharacterList.Add(DataHelper.DefaultKeyboardist());
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
			// Disable button if user has not recruited any characters
			if (EngineViewModel.PartyCharacterList.Count < 1)
            {
				ZeroMemberWarning.IsVisible = true;
				return;
            }

			// Add the characters to the battle engine
			EngineViewModel.Engine.CharacterList.Clear();
            foreach (CharacterModel member in EngineViewModel.PartyCharacterList)
            {
				EngineViewModel.Engine.AddBandMember(member);
            }

            // Open the Battle page
            await Navigation.PushModalAsync(new NavigationPage(new BattlePage()));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Open a character recruit page so user can add a character to the band.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void RecruitCharacter_Clicked(object sender, EventArgs e)
        {
			ZeroMemberWarning.IsVisible = false;

			// Disable button if user has recruited max number
			if (EngineViewModel.PartyCharacterList.Count >= EngineViewModel.Engine.MaxNumberCharacters)
            {
				MaxMemberWarning.IsVisible = true;
				return;
            }

			await Navigation.PushModalAsync(new NavigationPage(new RecruitPage()));
			BeatsLabel.Text = EngineViewModel.Beats.ToString();
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
			MaxMemberWarning.IsVisible = false;
		}
	}
}