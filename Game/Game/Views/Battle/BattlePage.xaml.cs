﻿using Game.Helpers;
using Game.Models;
using Game.Models.Enum;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattlePage : ContentPage
    {
        // This uses the Instance so it can be shared with other Battle Pages as needed
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        // Wait time before proceeding
        public int WaitTime = 1500;

        // Hold the Map Objects, for easy access to update them
        public Dictionary<string, object> MapLocationObject = new Dictionary<string, object>();

        // Flag to track whether page is waiting for user input for a character manual turn
        public bool IsCharacterTurn = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePage()
        {
            InitializeComponent();

            // Set initial State to Starting
            EngineViewModel.Engine.BattleStateEnum = BattleStateEnum.Starting;

            // Set up the UI to Defaults
            BindingContext = EngineViewModel;

            // Create and Draw the Map
            InitializeMapGrid();

            // Start the Battle Engine
            EngineViewModel.Engine.StartBattle(false);

            // Populate the UI Map
            DrawMapGridInitialState();

            // Ask the Game engine to select who goes first
            EngineViewModel.Engine.CurrentAttacker = null;

            // Add Players to Display
            DrawGameAttackerDefenderBoard();

            // draw Character info box at top of Battle Page
            foreach (var data in EngineViewModel.Engine.CharacterList)
            {
                CharacterInfoBox.Children.Add(CharacterInfo(data));
            }

            ShowModalNewRoundPage();
            // Set the Battle Mode
            ShowBattleMode();
        }

        /// <summary>
        /// Dray the Player Boxes
        /// </summary>
        public void DrawPlayerBoxes()
        {
            var CharacterBoxList = CharacterBox.Children.ToList();
            foreach (var data in CharacterBoxList)
            {
                CharacterBox.Children.Remove(data);
            }

            // Draw the Characters
            foreach (var data in EngineViewModel.Engine.EntityList.Where(m => m.EntityType == EntityTypeEnum.Character).ToList())
            {
                CharacterBox.Children.Add(PlayerInfoDisplayBox(data));
            }

            var MonsterBoxList = MonsterBox.Children.ToList();
            foreach (var data in MonsterBoxList)
            {
                MonsterBox.Children.Remove(data);
            }

            // Draw the Monsters
            foreach (var data in EngineViewModel.Engine.EntityList.Where(m => m.EntityType == EntityTypeEnum.Monster).ToList())
            {
                MonsterBox.Children.Add(PlayerInfoDisplayBox(data));
            }

            // Add one black PlayerInfoDisplayBox to hold space incase the list is empty
            CharacterBox.Children.Add(PlayerInfoDisplayBox(null));

            // Add one black PlayerInfoDisplayBox to hold space incase the list is empty
            MonsterBox.Children.Add(PlayerInfoDisplayBox(null));

        }

        /// <summary>
        /// Put the Player into a Display Box
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout PlayerInfoDisplayBox(BattleEntityModel data)
        {
            if (data == null)
            {
                data = new BattleEntityModel
                {
                    ImageURI = ""
                };
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["PlayerBattleMediumStyle"],
                Source = data.ImageURI
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerBattleDisplayBox"],
                Children = {
                    PlayerImage,
                },
            };

            return PlayerStack;
        }

        #region BattleMapMode

        /// <summary>
        /// Create the Initial Map Grid
        /// 
        /// All lcoations are empty
        /// </summary>
        /// <returns></returns>
        public bool InitializeMapGrid()
        {
            EngineViewModel.Engine.MapModel.ClearMapGrid();

            return true;
        }

        /// <summary>
        /// Draw the Map Grid
        /// Add the Players to the Map
        /// 
        /// Need to have Players in the Engine first, to then put on the Map
        /// 
        /// The Map Objects are all created with the map background image first
        /// 
        /// Then the actual characters are added to the map
        /// </summary>
        public void DrawMapGridInitialState()
        {
            // Create the Map in the Game Engine
            EngineViewModel.Engine.MapModel.PopulateMapModel(EngineViewModel.Engine.EntityList);

            CreateMapGridObjects();

            UpdateMapGrid();
        }

        /// <summary>
        /// Walk the current grid
        /// check each cell to see if it matches the engine map
        /// Update only those that need change
        /// </summary>
        /// <returns></returns>
        public bool UpdateMapGrid()
        {
            foreach (var data in EngineViewModel.Engine.MapModel.MapGridLocation)
            {
                // Use the ImageButton from the dictionary because that represents the player object
                object MapObject = GetMapGridObject(GetDictionaryImageButtonName(data));
                if (MapObject == null)
                {
                    return false;
                }

                var imageObject = (ImageButton)MapObject;

                // Check automation ID on the Image, That should match the Player, if not a match,
                // the cell is now different and needs to be updated
                if (!imageObject.AutomationId.Equals(data.Player.Guid))
                {
                    // The Image is different, so need to re-create the Image Object and add it to the Stack
                    // That way the correct monster is in the box.

                    MapObject = GetMapGridObject(GetDictionaryStackName(data));
                    if (MapObject == null)
                    {
                        return false;
                    }

                    var stackObject = (StackLayout)MapObject;

                    // Remove the ImageButton
                    stackObject.Children.RemoveAt(0);

                    var PlayerImageButton = DetermineMapImageButton(data);

                    stackObject.Children.Add(PlayerImageButton);

                    // Update the Image in the Datastructure
                    MapGridObjectAddImage(PlayerImageButton, data);

                    stackObject.BackgroundColor = DetermineMapBackgroundColor(data);
                }
            }

            return true;
        }

        /// <summary>
        /// Traverse the battle grid and update the background color of each square.
        /// Used to highlight current entity, attacker, and defender on the grid.
        /// </summary>
        /// <returns></returns>
        public bool UpdateMapGridBackgroundColors()
        {
            foreach (var data in EngineViewModel.Engine.MapModel.MapGridLocation)
            {
                // Use the ImageButton from the dictionary because that represents the player object
                object MapObject = GetMapGridObject(GetDictionaryImageButtonName(data));
                if (MapObject == null)
                {
                    return false;
                }

                var imageObject = (ImageButton)MapObject;

                MapObject = GetMapGridObject(GetDictionaryStackName(data));
                if (MapObject == null)
                {
                    return false;
                }

                var stackObject = (StackLayout)MapObject;

                // Remove the ImageButton
                stackObject.Children.RemoveAt(0);

                var PlayerImageButton = DetermineMapImageButton(data);

                stackObject.Children.Add(PlayerImageButton);

                // Update the Image in the Datastructure
                MapGridObjectAddImage(PlayerImageButton, data);

                stackObject.BackgroundColor = DetermineMapBackgroundColor(data);
            }

            return true;
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryFrameName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Frame", data.Row, data.Column);
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryStackName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Stack", data.Row, data.Column);
        }

        /// <summary>
        /// Covert the player map location to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryImageButtonName(MapModelLocation data)
        {
            // Look up the Frame in the Dictionary
            return string.Format("MapR{0}C{1}ImageButton", data.Row, data.Column);
        }

        /// <summary>
        /// Populate the Map
        /// 
        /// For each map position in the Engine
        /// Create a grid object to hold the Stack for that grid cell.
        /// </summary>
        /// <returns></returns>
        public bool CreateMapGridObjects()
        {
            // Make a frame for each location on the map
            // Populate it with a new Frame Object that is unique
            // Then updating will be easier

            foreach (var location in EngineViewModel.Engine.MapModel.MapGridLocation)
            {
                var data = MakeMapGridBox(location);

                // Add the Box to the UI
                MapGrid.Children.Add(data, location.Column, location.Row);
            }

            // Set the Height for the MapGrid based on the number of rows * the height of the BattleMapFrame
            var height = EngineViewModel.Engine.MapModel.MapXAxesCount * 60;

            BattleMapDisplay.MinimumHeightRequest = height;
            BattleMapDisplay.HeightRequest = height;

            return true;
        }

        /// <summary>
        /// Get the Frame from the Dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetMapGridObject(string name)
        {
            MapLocationObject.TryGetValue(name, out object data);
            return data;
        }

        /// <summary>
        /// Make the Game Map Frame 
        /// Place the Character or Monster on the frame
        /// If empty, place Empty
        /// </summary>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public Frame MakeMapGridBox(MapModelLocation mapLocationModel)
        {
            if (mapLocationModel.Player == null)
            {
                mapLocationModel.Player = EngineViewModel.Engine.MapModel.EmptySquare;
            }

            var PlayerImageButton = DetermineMapImageButton(mapLocationModel);

            var PlayerStack = new StackLayout
            {
                Padding = 0,
                Style = (Style)Application.Current.Resources["BattleMapImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = DetermineMapBackgroundColor(mapLocationModel),
                Children = {
                    PlayerImageButton
                },
            };

            MapGridObjectAddImage(PlayerImageButton, mapLocationModel);
            MapGridObjectAddStack(PlayerStack, mapLocationModel);

            var MapFrame = new Frame
            {
                Style = (Style)Application.Current.Resources["BattleMapFrame"],
                Content = PlayerStack,
                AutomationId = GetDictionaryFrameName(mapLocationModel)
            };

            return MapFrame;
        }

        /// <summary>
        /// This add the ImageButton to the stack to keep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddImage(ImageButton data, MapModelLocation MapModel)
        {
            var name = GetDictionaryImageButtonName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);

            return true;
        }

        /// <summary>
        /// This adds the Stack into the Dictionary to keep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddStack(StackLayout data, MapModelLocation MapModel)
        {
            var name = GetDictionaryStackName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);
            return true;
        }

        /// <summary>
        /// Set the Image onto the map
        /// The Image represents the player
        /// 
        /// So a character is the character Image for that character
        /// 
        /// The Automation ID equals the guid for the player
        /// This makes it easier to identify when checking the map to update thigns
        /// 
        /// The button action is set per the type, so Characters events are differnt than monster events
        /// </summary>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public ImageButton DetermineMapImageButton(MapModelLocation MapLocationModel)
        {
            ImageButton data;
            if (MapLocationModel.Player.EntityType == EntityTypeEnum.Character)
            {
                data = new ImageButton
                {
                    Style = (Style)Application.Current.Resources["ImageBattleSmallSpriteStyle"],
                    Source = MapLocationModel.Player.ImageURI,

                    // Store the guid to identify this button
                    AutomationId = MapLocationModel.Player.Guid
                };
            } else
            {
                data = new ImageButton
                {
                    Style = (Style)Application.Current.Resources["ImageBattleSmallIconStyle"],
                    Source = MapLocationModel.Player.ImageURI,

                    // Store the guid to identify this button
                    AutomationId = MapLocationModel.Player.Guid
                };
            }

            // add a click event to handle character manual turn
            data.Clicked += (sender, args) => CharacterManualTurn(MapLocationModel);

            return data;
        }

        /// <summary>
        /// Set the Background color for the tile.
        /// Monsters and Characters have different colors
        /// Empty cells are transparent
        /// </summary>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public Color DetermineMapBackgroundColor(MapModelLocation MapModel)
        {
            if (EngineViewModel.Engine.CurrentAttacker == MapModel.Player)
            {
                return (Color)Application.Current.Resources["BattleMapCurrentAttacker"];
            }

            if (EngineViewModel.Engine.CurrentEntity == MapModel.Player)
            {
                return (Color)Application.Current.Resources["BattleMapCurrentEntity"];
            }

            if (EngineViewModel.Engine.CurrentDefender == MapModel.Player)
            {
                return (Color)Application.Current.Resources["BattleMapCurrentDefender"];
            }

            return Color.Transparent;
        }

        #endregion BattleMapMode

        #region BasicBattleMode

        #region BattleEngineManagement

        /// <summary>
        /// Get the next turn from the battle engine.
        /// 
        /// If the turn is an action, perform the action automatically for monsters,
        /// for characters wait for the user to click a battle grid square.
        ///
        /// If the round is over, show the appropriate page.
        ///
        /// If the game is over, show the game over screen.
        /// </summary>
        public void EngineNextTurn()
        {
            EngineViewModel.Engine.BattleStateEnum = BattleStateEnum.Battling;

            // Hold the current state
            var RoundCondition = EngineViewModel.Engine.RoundNextTurn();

            // It's a Character or Monster's turn
            if (RoundCondition == RoundEnum.NextTurn)
            {
                UpdateMapGridBackgroundColors();

                var Player = EngineViewModel.Engine.CurrentEntity;
                if (Player.EntityType == EntityTypeEnum.Monster)
                {
                    MonsterAutoTurn();
                }
                else if (Player.EntityType == EntityTypeEnum.Character)
                {
                    CharacterTurnLabel.Text = Player.Name;
                    CharacterTurnMessage.IsVisible = true;
                    AttackButton.IsVisible = false;
                    IsCharacterTurn = true;
                }

                return;
            }

            if (RoundCondition == RoundEnum.NewRound)
            {
                EngineViewModel.Engine.BattleStateEnum = BattleStateEnum.NewRound;

                // Pause
                Task.Delay(WaitTime);

                RoundOver();

                return;
            }

            // Check for Game Over
            if (RoundCondition == RoundEnum.GameOver)
            {
                EngineViewModel.Engine.BattleStateEnum = BattleStateEnum.GameOver;

                // Wrap up
                EngineViewModel.Engine.EndBattle();

                // Pause
                Task.Delay(WaitTime);

                Debug.WriteLine("Game Over");

                GameOver();
                return;
            }
        }

        /// <summary>
        /// If the user clicks a battle square when it's a Character's turn, call the battle engine to
        /// perform an action on that square
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CharacterManualTurn(MapModelLocation data)
        {
            if (!IsCharacterTurn)
            {
                return false;
            }

            // no one is taking a turn - do nothing
            if (EngineViewModel.Engine.CurrentEntity == null)
            {
                return false;
            }

            // only take a turn if we're waiting on a character
            if (EngineViewModel.Engine.CurrentEntity.EntityType != EntityTypeEnum.Character)
            {
                return false;
            }

            // toggle flag to prevent this character from performing multiple actions if user keeps clicking
            IsCharacterTurn = false;

            var result = EngineViewModel.Engine.CharacterManualTurn(EngineViewModel.Engine.CurrentEntity, data);

            DisplayTurnResult();

            AttackButton.IsVisible = true;
            CharacterTurnMessage.IsVisible = false;

            return result;
        }

        /// <summary>
        /// When it's a monster's turn, take the turn automatically
        /// </summary>
        /// <returns></returns>
        public bool MonsterAutoTurn()
        {
            // no one is taking a turn - do nothing
            if (EngineViewModel.Engine.CurrentEntity == null)
            {
                return false;
            }

            // only take an auto-turn if current turn is a monster
            if (EngineViewModel.Engine.CurrentEntity.EntityType != EntityTypeEnum.Monster)
            {
                return false;
            }

            // engine manages the turn
            var result = EngineViewModel.Engine.TakeTurn(EngineViewModel.Engine.CurrentEntity);

            DisplayTurnResult();

            return result;
        }

        #endregion BattleEngineManagement

        /// <summary>
        /// Draw the UI for
        ///
        /// Attacker vs Defender Mode
        /// 
        /// </summary>
        public void DrawGameAttackerDefenderBoard()
        {
            // Clear the current UI
            DrawGameBoardClear();

            // Show Characters across the Top
            DrawPlayerBoxes();

            // Draw the Map
            UpdateMapGrid();

            // Show the Attacker and Defender
            DrawGameBoardAttackerDefenderSection();
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender
        /// </summary>
        public void DrawGameBoardAttackerDefenderSection()
        {
            BattlePlayerBoxVersus.Text = "";

            if (EngineViewModel.Engine.CurrentAttacker == null)
            {
                return;
            }

            if (EngineViewModel.Engine.CurrentDefender == null)
            {
                return;
            }

            if (EngineViewModel.Engine.CurrentAttacker.EntityType == EntityTypeEnum.Character)
            {
                AttackerImage.Source = EngineViewModel.Engine.CurrentAttacker.IconURI;
                AttackerName.Text = EngineViewModel.Engine.CurrentAttacker.Name;
                AttackerHealth.Text = EngineViewModel.Engine.CurrentAttacker.CurrentHealth.ToString() + " / "
                    + EngineViewModel.Engine.CurrentAttacker.MaxHealth.ToString();

                DefenderImage.Source = EngineViewModel.Engine.CurrentDefender.ImageURI;
                DefenderName.Text = EngineViewModel.Engine.CurrentDefender.Name;
                DefenderHealth.Text = EngineViewModel.Engine.CurrentDefender.CurrentHealth.ToString() + " / "
                    + EngineViewModel.Engine.CurrentDefender.MaxHealth.ToString();
            } else
            {
                AttackerImage.Source = EngineViewModel.Engine.CurrentAttacker.ImageURI;
                AttackerName.Text = EngineViewModel.Engine.CurrentAttacker.Name;
                AttackerHealth.Text = EngineViewModel.Engine.CurrentAttacker.CurrentHealth.ToString() + " / "
                    + EngineViewModel.Engine.CurrentAttacker.MaxHealth.ToString();

                DefenderImage.Source = EngineViewModel.Engine.CurrentDefender.IconURI;
                DefenderName.Text = EngineViewModel.Engine.CurrentDefender.Name;
                DefenderHealth.Text = EngineViewModel.Engine.CurrentDefender.CurrentHealth.ToString() + " / "
                    + EngineViewModel.Engine.CurrentDefender.MaxHealth.ToString();
            }
            

            if (EngineViewModel.Engine.CurrentDefender.Alive == false)
            {
                UpdateMapGrid();
                DefenderImage.BackgroundColor = Color.Red;
            }

            BattlePlayerBoxVersus.Text = "vs";
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender areas to be null
        /// </summary>
        public void DrawGameBoardClear()
        {
            AttackerImage.Source = string.Empty;
            AttackerName.Text = string.Empty;
            AttackerHealth.Text = string.Empty;

            DefenderImage.Source = string.Empty;
            DefenderName.Text = string.Empty;
            DefenderHealth.Text = string.Empty;
            DefenderImage.BackgroundColor = Color.Transparent;

            BattlePlayerBoxVersus.Text = string.Empty;
        }

        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackButton_Clicked(object sender, EventArgs e)
        {
            EngineNextTurn();
        }

        /// <summary>
        /// Display the result of the Turn by updating UX messages, board, and character profiles
        /// </summary>
        public void DisplayTurnResult()
        {
            // Output the Message of what happened.
            GameMessage();

            // Show the outcome on the Board
            DrawGameAttackerDefenderBoard();

            // Update current HP for entities, update battle grid with only alive entities
            CharacterInfoBox.Children.Clear();
            foreach (var data in EngineViewModel.Engine.CharacterList)
            {
                CharacterInfoBox.Children.Add(CharacterInfo(data));
            }
        }

        /// <summary>
        /// Display character details
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// Game is over
        /// 
        /// Show Buttons
        /// 
        /// Clean up the Engine
        /// 
        /// Show the Score
        /// 
        /// Clear the Board
        /// 
        /// </summary>
        public void GameOver()
        {
            // Save the Score to the Score View Model, use first band member's name as Score Name
            var Score = EngineViewModel.Engine.Score;
            Score.Name = EngineViewModel.PartyCharacterList.FirstOrDefault().Name + " "
                   + Score.GameDate.ToShortDateString();
            MessagingCenter.Send(this, "Create", Score);

            ShowBattleMode();
        }


        /// <summary>
        /// Round is over - show the round over screen that includes items equipped
        /// </summary>
        public void RoundOver()
        {
            Debug.WriteLine("Round Over");

            // end the round - characters distribute item pool
            BattleEngineViewModel.Instance.Engine.EndRound();

            // Display round #
            RoundNumberLabel.Text = EngineViewModel.Engine.Score.RoundCount.ToString();

            // Display the items equipped during the round
            ItemsLabel.Text = EngineViewModel.Engine.BattleMessages.GetItemsEquippedMessage();

            ShowBattleMode();
        }

        #endregion BasicBattleMode

        #region MessageHandlers

        /// <summary>
        /// Builds up the output message
        /// </summary>
        /// <param name="message"></param>
        public void GameMessage()
        {
            // Output The Message that happened.
            string message = EngineViewModel.Engine.BattleMessages.TurnMessage;

            // Special message
            if (!string.IsNullOrEmpty(EngineViewModel.Engine.BattleMessages.TurnMessageSpecial))
            {
                message += "\n" + EngineViewModel.Engine.BattleMessages.TurnMessageSpecial;
            }

            // Level up message
            if (!string.IsNullOrEmpty(EngineViewModel.Engine.BattleMessages.LevelUpMessage))
            {
                message += "\n" + EngineViewModel.Engine.BattleMessages.LevelUpMessage;
            }

            // Item Drop message
            if (!string.IsNullOrEmpty(EngineViewModel.Engine.BattleMessages.ItemDropMessage))
            {
                message += EngineViewModel.Engine.BattleMessages.ItemDropMessage;
            }

            // Output the complete message
            Debug.WriteLine(message);
            BattleMessages.Text = string.Format("{0} \n{1}", message, BattleMessages.Text);
        }

        /// <summary>
        ///  Clears the messages on the UX
        /// </summary>
        public void ClearMessages()
        {
            BattleMessages.Text = "";
        }

        #endregion MessageHandelers

        #region PageHandlers

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// The Next Round Button
        /// Start a new round in the engine, then pop the NewRoundPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NextRoundButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("New Round");

            EngineViewModel.Engine.NewRound();
            EngineViewModel.Engine.BattleStateEnum = BattleStateEnum.Battling;

            // Clear and Re-draw the Map
            InitializeMapGrid();
            DrawMapGridInitialState();

            // Ask the Game engine to select who goes first
            EngineViewModel.Engine.CurrentAttacker = null;

            // Add Players to Display
            DrawGameAttackerDefenderBoard();

            RoundOverDisplay.IsVisible = false;
            ShowModalNewRoundPage();            
        }

        /// <summary>
        /// The Start Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartButton_Clicked(object sender, EventArgs e)
        {
            EngineViewModel.Engine.BattleStateEnum = BattleStateEnum.Battling;

            ShowBattleMode();
        }

        /// <summary>
        /// Show the Game Over Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void ShowScoreButton_Clicked(object sender, EventArgs args)
        {
            ShowBattleMode();

            // Display the Game Over/Score page
            await Navigation.PushModalAsync(new NavigationPage(new ScorePage(new GenericViewModel<ScoreModel>(),
                EngineViewModel.Engine.Score)));
        }

        /// <summary>
        /// Show the New Round page
        /// 
        /// Round Over is where characters get items
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
        {
            await Navigation.PushModalAsync(new NewRoundPage());
            ShowBattleMode();
        }
        #endregion PageHandlers

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ShowBattleMode();
        }

        /// <summary>
        /// 
        /// Hide the different button states
        /// 
        /// Hide the message display box
        /// 
        /// </summary>
        public void HideUIElements()
        {
            StartBattleButton.IsVisible = false;
            AttackButton.IsVisible = false;
            MessageDisplayBox.IsVisible = false;
            BattlePlayerInfomationBox.IsVisible = false;
        }

        /// <summary>
        /// Show the proper Battle Mode
        /// </summary>
        public void ShowBattleMode()
        {
            HideUIElements();

            ClearMessages();

            DrawPlayerBoxes();

            switch (EngineViewModel.Engine.BattleSettingsModel.BattleModeEnum)
            {
                case BattleModeEnum.MapFull:
                case BattleModeEnum.MapNext:
                    GamePlayersTopDisplay.IsVisible = false;
                    BattleMapDisplay.IsVisible = true;
                    break;

                case BattleModeEnum.SimpleNext:
                case BattleModeEnum.Unknown:
                default:
                    GamePlayersTopDisplay.IsVisible = true;
                    BattleMapDisplay.IsVisible = false;
                    break;
            }

            switch (EngineViewModel.Engine.BattleStateEnum)
            {
                case BattleStateEnum.Starting:
                    StartBattleButton.IsVisible = true;
                    break;

                case BattleStateEnum.NewRound:
                    // Hide the Game Board
                    GameUIDisplay.IsVisible = false;

                    // Show the Game Over Display
                    RoundOverDisplay.IsVisible = true;

                    break;

                case BattleStateEnum.GameOver:
                    // Hide the Game Board
                    GameUIDisplay.IsVisible = false;

                    // Show the Game Over Display
                    GameOverDisplay.IsVisible = true;
                    break;

                case BattleStateEnum.RoundOver:
                case BattleStateEnum.Battling:
                    GameUIDisplay.IsVisible = true;
                    BattlePlayerInfomationBox.IsVisible = true;
                    MessageDisplayBox.IsVisible = true;
                    AttackButton.IsVisible = true;
                    break;

                // Based on the State disable buttons
                case BattleStateEnum.Unknown:
                default:
                    break;
            }
        }
    }
}