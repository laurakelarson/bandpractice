using Game.Models;
using Game.Views;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using Game.Services;
using Game.Views.Characters;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class CharacterIndexViewModel : BaseViewModel<CharacterModel>
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile CharacterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static CharacterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CharacterIndexViewModel();
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
        public CharacterIndexViewModel()
        {
            Title = "Characters";

            #region Messages

            //    // Register the Create Message
            //    MessagingCenter.Subscribe<CharacterCreatePage, CharacterModel>(this, "Create", async (obj, data) =>
            //    {
            //        await CreateAsync(data as CharacterModel);
            //    });

                // Register the Update Message
                MessagingCenter.Subscribe<CharacterUpdatePage, CharacterModel>(this, "Update", async (obj, data) =>
                {
                    // Have the item update itself
                    data.Update(data);

                    await UpdateAsync(data as CharacterModel);
                });

                // Register the Delete Message
                MessagingCenter.Subscribe<CharacterDeletePage, CharacterModel>(this, "Delete", async (obj, data) =>
                {
                    await DeleteAsync(data as CharacterModel);
                });

            //    // Register the Set Data Source Message
            //    MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            //    {
            //        await SetDataSource(data);
            //    });

            //    // Register the Wipe Data List Message
            //    MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
            //    {
            //        await WipeDataListAsync();
            //    });

            #endregion Messages
        }

        #endregion Constructor

        #region DataOperations_CRUDi

        /// <summary>
        /// Returns the character passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CharacterModel CheckIfItemExists(CharacterModel data)
        {
            // This will walk the characters and find if there is one that is the same.
            // If so, it returns the character...

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

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<CharacterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new CharacterModel());
        }

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the CharacterModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<CharacterModel> SortDataset(List<CharacterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Level)
                    .ThenBy(a => a.Type)
                    .ThenBy(a => a.Name)
                    .ToList();
        }

        #endregion SortDataSet
    }
}