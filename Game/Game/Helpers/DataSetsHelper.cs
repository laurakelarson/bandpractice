using System;
using Game.ViewModels;

namespace Game.Helpers
{
    public static class DataSetsHelper
    {
        /// <summary>
        /// Warms up and loads the data sets in the correct order to account for data dependencies
        /// </summary>
        public static void WarmUp()
        {
            // load items before monster and character
            ItemIndexViewModel.Instance.GetCurrentDataSource();

            ScoreIndexViewModel.Instance.GetCurrentDataSource();

            CharacterIndexViewModel.Instance.GetCurrentDataSource();
            MonsterIndexViewModel.Instance.GetCurrentDataSource();
        }
    }
}
