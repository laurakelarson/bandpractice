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

		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			// Call into Auto Battle from here to do the Battle...

			var Engine = new Game.Engine.AutoBattleEngine();

			string BattleMessage = "";

			var result = await Engine.RunAutoBattle();

			var Score = Engine.GetScoreObject();

			BattleMessage = string.Format("Done {0} Rounds", Score.RoundCount);

			BattleMessageValue.Text = BattleMessage;
		}
	}
}