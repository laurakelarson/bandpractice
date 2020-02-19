using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
    class MonsterLevelHelper
    {
        /// <summary>
        ///  Gets the list of locations a character can use
        ///  Removes Finger for example, and allows for left and right finger
        /// </summary>
        public static List<string> GetLevelList
        {
            get
            {
                List<int> levels = Enumerable.Range(1, 20).ToList();
                var myReturn = levels.Select(i => i.ToString()).ToList();

                return myReturn;
            }
        }

    }
}
