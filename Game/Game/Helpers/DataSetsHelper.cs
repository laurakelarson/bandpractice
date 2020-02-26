using System;
using System.Threading.Tasks;
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

        /// <summary>
        /// Sends the WipeData command to index view models in the correct order to account for data dependencies.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> WipeData()
        {
            // wipe and re-load items before monster and character 
            await ItemIndexViewModel.Instance.WipeDataListAsync();

            await ScoreIndexViewModel.Instance.WipeDataListAsync();

            await CharacterIndexViewModel.Instance.WipeDataListAsync();
            await MonsterIndexViewModel.Instance.WipeDataListAsync();

            return true;
        }

        /// <summary>
        /// Sends the SetDataSource command to index view models in the correct order to account for data dependencies.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<bool> SetDataSource(int source)
        {
            // load items from new source before monster and character 
            await ItemIndexViewModel.Instance.SetDataSource(source);

            await ScoreIndexViewModel.Instance.SetDataSource(source);

            await CharacterIndexViewModel.Instance.SetDataSource(source);
            await MonsterIndexViewModel.Instance.SetDataSource(source);

            return true;
        }
    }
}
