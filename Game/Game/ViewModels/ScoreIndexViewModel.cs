using Game.Models;
using Game.Views;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Game.Services;
using Game.Views.Battle;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class ScoreIndexViewModel : BaseViewModel<ScoreModel>
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile ScoreIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static ScoreIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ScoreIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        #region Constructor

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public ScoreIndexViewModel()
        {
            Title = "Scores";

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<ScoreCreatePage, ScoreModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as ScoreModel);
            });

            // Register the Create Message from AutoBattle page
            MessagingCenter.Subscribe<AutoBattlePage, ScoreModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as ScoreModel);
            });

            // Register the Update Message
            MessagingCenter.Subscribe<ScoreUpdatePage, ScoreModel>(this, "Update", async (obj, data) =>
            {
                // Have the Score update itself
                data.Update(data);

                await UpdateAsync(data as ScoreModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<ScoreDeletePage, ScoreModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as ScoreModel);
            });

            #endregion Messages
        }

        #endregion Constructor
        
        #region DataOperations_CRUDi

        /// <summary>
        /// Returns the Score passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override ScoreModel CheckIfExists(ScoreModel data)
        {
            // This will walk the Scores and find if there is one that is the same.
            // If so, it returns the Score...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name &&
                                        a.BattleNumber == data.BattleNumber &&
                                        a.GameDate == data.GameDate &&
                                        a.AutoBattle == data.AutoBattle &&
                                        a.TurnCount == data.TurnCount &&
                                        a.RoundCount == data.RoundCount &&
                                        a.MonsterSlainNumber == data.MonsterSlainNumber &&
                                        a.ExperienceGainedTotal == data.ExperienceGainedTotal
                                        )
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<ScoreModel> GetDefaultData() 
        {
            return DefaultData.LoadData(new ScoreModel());
        }

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the ScoreModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<ScoreModel> SortDataset(List<ScoreModel> dataset)
        {
            return dataset
                    .OrderByDescending(a => a.ScoreTotal)
                    .ThenByDescending(a => a.MonsterSlainNumber)
                    .ThenByDescending(a => a.RoundCount)
                    .ThenByDescending(a => a.TurnCount)
                    .ToList();
        }

        #endregion SortDataSet
    }
}