using Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    /// <summary>
    /// Helper class that keeps a list of levels and attributes
    /// to simplify leveling up characters. 
    /// </summary>
    public class LevelAttributesHelper
    {

        #region Singleton
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static LevelAttributesHelper instance;

        public static LevelAttributesHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelAttributesHelper();
                }
                return instance;
            }
        }

        #endregion Singleton

        // List of all levels and attributes 
        public List<LevelAttributesModel> LevelAttributesList { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LevelAttributesHelper()
        {
            ClearAndLoadDataTable(); 
        }
        
        /// <summary>
        /// Clear the data from list and reload it
        /// </summary>
        public void ClearAndLoadDataTable()
        {
            LevelAttributesList = new List<LevelAttributesModel>();
            LoadLevelAttributesData();
        }

        /// <summary>
        /// Fill the LevelAttributesList with the levels
        /// </summary>
        public void LoadLevelAttributesData()
        {
            // Use level zero for zero index of array, so 
            // array index is same as level 
            LevelAttributesList.Add(new LevelAttributesModel(0, 0, 0, 0, 0));

            // Character level table 
            LevelAttributesList.Add(new LevelAttributesModel(1, 0, 1, 1, 1));
            LevelAttributesList.Add(new LevelAttributesModel(2, 300, 1, 2, 1));
            LevelAttributesList.Add(new LevelAttributesModel(3, 900, 2, 3, 1));
            LevelAttributesList.Add(new LevelAttributesModel(4, 2700, 2, 3, 1));
            LevelAttributesList.Add(new LevelAttributesModel(5, 6500, 2, 4, 2));
            LevelAttributesList.Add(new LevelAttributesModel(6, 14000, 3, 4, 2));
            LevelAttributesList.Add(new LevelAttributesModel(7, 23000, 3, 5, 2));
            LevelAttributesList.Add(new LevelAttributesModel(8, 34000, 3, 5, 2));
            LevelAttributesList.Add(new LevelAttributesModel(9, 48000, 3, 5, 2));
            LevelAttributesList.Add(new LevelAttributesModel(10, 64000, 4, 6, 3));
            LevelAttributesList.Add(new LevelAttributesModel(11, 85000, 4, 6, 3));
            LevelAttributesList.Add(new LevelAttributesModel(12, 100000, 4, 6, 3));
            LevelAttributesList.Add(new LevelAttributesModel(13, 120000, 4, 7, 3));
            LevelAttributesList.Add(new LevelAttributesModel(14, 140000, 5, 7, 3));
            LevelAttributesList.Add(new LevelAttributesModel(15, 165000, 5, 7, 4));
            LevelAttributesList.Add(new LevelAttributesModel(16, 195000, 5, 8, 4));
            LevelAttributesList.Add(new LevelAttributesModel(17, 225000, 5, 8, 4));
            LevelAttributesList.Add(new LevelAttributesModel(18, 265000, 6, 8, 4));
            LevelAttributesList.Add(new LevelAttributesModel(19, 305000, 7, 9, 4));
            LevelAttributesList.Add(new LevelAttributesModel(20, 355000, 8, 10, 5));

        }
    }
}
