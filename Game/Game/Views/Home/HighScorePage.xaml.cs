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
                NameLabel.Text = HighScore.Name;
            }
        }

        /// <summary>
        /// Overloaded constructor
        /// Takes in a ScoreModel to compare against the saved highest score
        /// </summary>
        public HighScorePage(ScoreModel NewScore)
        {
            InitializeComponent();

            // Query view model for high score - should be first in data set based on sort order
            HighScore = ScoreIndexViewModel.Instance.Dataset.FirstOrDefault();

            // Display the highest score
            CompareScoreToDisplay(NewScore);
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

        /// <summary>
        /// Helper method to compare the oldest highest recorded score to a new one.
        /// Returns true if the new score is the new high score.
        /// </summary>
        /// <param name="NewScore"></param>
        /// <returns></returns>
        public bool CompareScoreToDisplay(ScoreModel NewScore)
        {
            if (HighScore == null)
            {
                ScoreLabel.Text = NewScore.ScoreTotal.ToString();
                NameLabel.Text = NewScore.Name;
                NewHighScoreLabel.IsVisible = true;
                return true;
            }

            if (HighScore.ScoreTotal < NewScore.ScoreTotal)
            {
                ScoreLabel.Text = NewScore.ScoreTotal.ToString();
                NameLabel.Text = NewScore.Name;
                NewHighScoreLabel.IsVisible = true;
                return true;
            }

            ScoreLabel.Text = HighScore.ScoreTotal.ToString();
            NameLabel.Text = HighScore.Name;
            return false;
        }

    }

}