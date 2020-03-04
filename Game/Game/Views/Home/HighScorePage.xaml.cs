using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Home
{
    /// <summary>
    /// High Score Page
    /// Displays the highest recorded score in the game
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HighScorePage : ContentPage
    {
        // to hold the high score
        public ScoreModel HighScore;

        /// <summary>
        /// Constructor
        /// </summary>
        public HighScorePage()
        {
            InitializeComponent();

            // Query view model for high score - should be first in data set based on sort order
            HighScore = ScoreIndexViewModel.Instance.Dataset.FirstOrDefault();

            if (HighScore != null)
            {
                ScoreLabel.Text = HighScore.ScoreTotal.ToString();
            }
        }

        /// <summary>
        /// Close the modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cool_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }


}