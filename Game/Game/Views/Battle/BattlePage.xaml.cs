using Game.Models;
using Game.Models.Enum;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

		// Wait time before proceeding
		public int WaitTime = 1500;

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
			NextAttackExample();
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

			foreach (var data in EngineViewModel.Engine.MonsterList)
			{
				BattleGrid.Children.Add(DrawMonster(data), data.ColPos, data.RowPos);
			}

			foreach (var data in EngineViewModel.Engine.CharacterList)
			{
				BattleGrid.Children.Add(DrawCharacter(data), data.ColPos, data.RowPos);
			}
		}

		public ImageButton DrawMonster(MonsterModel data)
		{
			var MonsterButton = new ImageButton
			{
				Source = data.ImageURI,
				Style = (Style)Application.Current.Resources["ImageBattleSmallIconStyle"]
			};

			return MonsterButton;
		}

		public ImageButton DrawCharacter(CharacterModel data)
		{
			var CharacterButton = new ImageButton
			{
				Source = data.ImageURI,
				Style = (Style)Application.Current.Resources["ImageBattleSmallSpriteStyle"]
				// Clicked = ???????
			};

			return CharacterButton;
		}



		/// <summary>
		/// Next Attack Example
		/// 
		/// This code example follows the rule of
		/// 
		/// Auto Select Attacker
		/// Auto Select Defender
		/// 
		/// Do the Attack and show the result
		/// 
		/// So the pattern is Click Next, Next, Next until game is over
		/// 
		/// </summary>
		public void NextAttackExample()
		{
			// Get the turn, set the current player and attacker to match
			SetAttackerAndDefender();

			// Hold the current state
			var RoundCondition = EngineViewModel.Engine.RoundNextTurn();

			// Output the Message of what happened.
			GameMessage();

			// Show the outcome on the Board
			//DrawGameAttackerDefenderBoard();

			if (RoundCondition == RoundEnum.NewRound)
			{
				// Pause
				Task.Delay(WaitTime);

				Debug.WriteLine("New Round");

                // Show the Round Over, after that is cleared, it will show the New Round Dialog
                ShowModalRoundOverPage();
                return;
			}

			// Check for Game Over
			if (RoundCondition == RoundEnum.GameOver)
			{
				// Pause
				Task.Delay(WaitTime);

				Debug.WriteLine("Game Over");

				GameOver();
				return;
			}
		}

		/// <summary>
		/// Decide The Turn and who to Attack
		/// </summary>
		public void SetAttackerAndDefender()
		{
			EngineViewModel.Engine.CurrentAttacker = EngineViewModel.Engine.GetNextPlayerTurn();

			switch (EngineViewModel.Engine.CurrentAttacker.EntityType)
			{
				case EntityTypeEnum.Character:
					// User would select who to attack

					// for now just auto selecting
					EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);
					break;

				case EntityTypeEnum.Monster:
				default:

					// Monsters turn, so auto pick a Character to Attack
					EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);
					break;
			}
		}

		/// <summary>
		/// Game Over: end battle, save score, and pop score/game over page.
		/// </summary>
		public async void GameOver()
		{
			// Wrap up
			EngineViewModel.Engine.EndBattle();

			// Save the Score to the Score View Model, by sending a message to it.
			var Score = EngineViewModel.Engine.Score;
			MessagingCenter.Send(this, "AddData", Score);

			// Display the Game Over/Score page
			await Navigation.PushModalAsync(new NavigationPage(new ScorePage(new GenericViewModel<ScoreModel>(),
				EngineViewModel.Engine.Score)));
		}

		#region MessageHandlers

		/// <summary>
		/// Builds up the output message
		/// </summary>
		/// <param name="message"></param>
		public void GameMessage()
		{
			// Output The Message that happened.
			string message = EngineViewModel.Engine.BattleMessages.TurnMessage;

			if (!string.IsNullOrEmpty(EngineViewModel.Engine.BattleMessages.TurnMessageSpecial))
			{
				message += "\n" + EngineViewModel.Engine.BattleMessages.TurnMessageSpecial;
			}

			if (!string.IsNullOrEmpty(EngineViewModel.Engine.BattleMessages.LevelUpMessage))
			{
				message += "\n" + EngineViewModel.Engine.BattleMessages.LevelUpMessage;
			}

			Debug.WriteLine(message);

			BattleMessages.Text = message;
		}

		/// <summary>
		///  Clears the messages on the UX
		/// </summary>
		public void ClearMessages()
		{
			BattleMessages.Text = string.Empty;
        }

		#endregion MessageHandlers


		/// <summary>
		/// Show the Round Over page
		/// 
		/// Round Over is where characters get items
		/// 
		/// </summary>
		public async void ShowModalRoundOverPage()
		{
			//HideUIElements();

			// Show the Round Over page
			// Then show the Next Round Button
			//NextRoundButton.IsVisible = true;

			await Navigation.PushModalAsync(new RoundOverPage());
		}

	}
}