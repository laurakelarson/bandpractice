using Game.Models;
using Game.Views;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Game.Services;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class MonsterIndexViewModel : BaseViewModel<MonsterModel>
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile MonsterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static MonsterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MonsterIndexViewModel();
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
        public MonsterIndexViewModel()
        {
            Title = "Monsters";

            #region Messages

            //// Register the Create Message
            //MessagingCenter.Subscribe<MonsterCreatePage, MonsterModel>(this, "Create", async (obj, data) =>
            //{
            //    await CreateAsync(data as MonsterModel);
            //});

            //// Register the Update Message
            //MessagingCenter.Subscribe<MonsterUpdatePage, MonsterModel>(this, "Update", async (obj, data) =>
            //{
            //    // Have the Monster update itself
            //    data.Update(data);

            //    await UpdateAsync(data as MonsterModel);
            //});

            //// Register the Delete Message
            //MessagingCenter.Subscribe<MonsterDeletePage, MonsterModel>(this, "Delete", async (obj, data) =>
            //{
            //    await DeleteAsync(data as MonsterModel);
            //});

            // Register the Set Data Source Message
            MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            {
                await SetDataSource(data);
            });

            // Register the Wipe Data List Message
            MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
            {
                await WipeDataListAsync();
            });

            #endregion Messages
        }

        #endregion Constructor
        
        #region DataOperations_CRUDi

        /// <summary>
        /// Returns the Monster passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public MonsterModel CheckIfMonsterExists(MonsterModel data)
        {
            // This will walk the Monsters and find if there is one that is the same.
            // If so, it returns the Monster...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name)
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        ///// <summary>
        ///// Load the Default Data
        ///// </summary>
        ///// <returns></returns>
        //public override List<MonsterModel> GetDefaultData() 
        //{
        //    return DefaultData.LoadData(new MonsterModel());
        //}

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the MonsterModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<MonsterModel> SortDataset(List<MonsterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet
    }
}