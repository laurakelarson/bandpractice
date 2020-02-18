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

    }
}
