using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoBattlePage : ContentPage
    {
        /// <summary>
		/// Constructor
		/// </summary>
        public AutoBattlePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for auto-battle button.
        /// Runs auto-battle, then saves the score in the data source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			// Call into Auto Battle from here to do the Battle...

			var Engine = new Game.Engine.AutoBattleEngine();

            // Check whether user has enabled Critical Hits (hackathon rule)
            Engine.CriticalHitsEnabled = BattleEngineViewModel.Instance.Engine.CriticalHitsEnabled;

            // Check whether user has enabled Critical Miss (hackathon rule)
            Engine.CriticalMissEnabled = BattleEngineViewModel.Instance.Engine.CriticalMissEnabled;

            await Engine.RunAutoBattle();

			var Score = Engine.GetScoreObject();

			string BattleMessage = string.Format("Done {0} Rounds", Score.RoundCount);

			BattleMessageValue.Text = BattleMessage;

            // save new score to data source
			MessagingCenter.Send(this, "Create", Score);
            await Navigation.PushModalAsync(new NavigationPage(new ScorePage(new GenericViewModel<ScoreModel>(), Score)));
        }
	}
}
