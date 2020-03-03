using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage: ContentPage
	{

		// This uses the Instance so it can be shared with other Battle Pages as needed
		public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

		/// <summary>
		/// Constructor
		/// </summary>
		public BattlePage ()
		{
			InitializeComponent ();

			// Set up the UI to Defaults
			BindingContext = EngineViewModel;

			// Start the Battle Engine
			EngineViewModel.Engine.StartBattle(false);
			RoundCount.Text = EngineViewModel.Engine.Score.RoundCount.ToString();

			// Show the New Round Screen
			ShowModalNewRoundPage();

			// draw Character info box at top of Battle Page
			foreach (var data in EngineViewModel.Engine.CharacterList)
			{
				CharacterInfoBox.Children.Add(CharacterInfo(data));
			}

			// For now, draw battle entities explicitly
			DrawEntities();

			// dummy declaration
			BattleMessages.Text = string.Empty;

		}

        #region Button methods
        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AttackButton_Clicked(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// Attack Action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SkipButton_Clicked(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Battle Over
		/// Battle Over button shows when all characters are dead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void RoundOverButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new RoundOverPage());
		}


		/// <summary>
		/// Battle Over
		/// Battle Over button shows when all characters are dead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void NewRoundButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewRoundPage());
		}
		

		/// <summary>
		/// Battle Over
		/// Battle Over button shows when all characters are dead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void BattleOverButton_Clicked(object sender, EventArgs e)
		{
			// Display the Engine's Score
			await Navigation.PushModalAsync(new NavigationPage(new ScorePage(new GenericViewModel<ScoreModel>(),
                EngineViewModel.Engine.Score)));
            //TODO save the Score in data source, update navigation stack (should we pop battle page?)
		}

		/// <summary>
		/// Battle Over, so Exit Button
		/// Need to show this for the user to click on.
		/// The Quit does a prompt, exit just exits
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void ExitButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		/// <summary>
		/// Quit the Battle
		/// 
		/// Quitting out
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void QuitButton_Clicked(object sender, EventArgs e)
		{
			bool answer = await DisplayAlert("Battle", "Are you sure you want to Quit?", "Yes", "No");

			if (answer)
			{
				await Navigation.PopModalAsync();
			}
		}
        #endregion


		public StackLayout CharacterInfo(CharacterModel data)
		{
			if (data == null)
			{
				data = new CharacterModel();
			}
			// Hookup the image
			var CharacterImage = new Image
			{
				Style = (Style)Application.Current.Resources["ImageBattleSmallIconStyle"],
				Source = data.IconURI
			};

			var CharacterNameLabel = new Label()
			{
				Text = data.Name,
				Style = (Style)Application.Current.Resources["ValueStyle"],
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				Padding = 0,
				LineBreakMode = LineBreakMode.TailTruncation,
				CharacterSpacing = 1,
				LineHeight = 1,
				MaxLines = 1,
			};

			// Add the HP
			var CharacterHPLabel = new Label
			{
				Text = "HP - " + data.CurrentHealth,
				Style = (Style)Application.Current.Resources["ValueStyleMicro"],
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				Padding = 0,
				LineBreakMode = LineBreakMode.TailTruncation,
				CharacterSpacing = 1,
				LineHeight = 1,
				MaxLines = 1,
			};

			var CharacterStats = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Start,
				Padding = 2,
				Spacing = 0,
				Children = {
					CharacterNameLabel,
					CharacterHPLabel,
				},
			};

			// Put the Image Button and Text stack inside a layout
			var CharacterStack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Start,
				Padding = 2,
				Spacing = 0,
				Children = {
					CharacterImage,
					CharacterStats
				},
			};

			return CharacterStack;
		}

        /// <summary>
        /// Show the Page for New Round
        /// 
        /// Upcomming Monsters
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
		{
			await Navigation.PushModalAsync(new NewRoundPage());

			//HideUIElements();

			//ClearMessages();

			// Show the Attack Button Set
			//BattlePlayerInfomationBox.IsVisible = true;
			//MessageDisplayBox.IsVisible = true;
			//AttackButton.IsVisible = true;
		}

		public void DrawEntities()
		{
			var MonsterPositions = new List<string> { "C4R0", "C5R1", "C4R2", "C5R3", "C4R4", "C5R5" };
			int idx = 0;
			foreach (var data in EngineViewModel.Engine.MonsterList)
			{
				//CharacterInfoBox.Children.Add(CharacterInfo(data));
				
			}
		}

	}
}