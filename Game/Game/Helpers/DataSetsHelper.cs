using System;
using Game.ViewModels;

namespace Game.Helpers
{
    /// <summary>
    /// DataSetsHelper is a static class that helps manage data dependencies in the default data sets.
    /// For example, Monster Model may hold foreign keys into Item Model, so Item Model needs to be loaded first.
    /// That way, when Monster Model data is loaded, the model is able to locate the associated Items.
    /// </summary>
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
