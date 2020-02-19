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
                int[] levels = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                var myList = Enum.GetNames(typeof(CharacterTypeEnum)).ToList();
                var myReturn = myList.OrderBy(a => a).ToList();

                return myReturn;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ConvertStringToInt(string value)
        {
            return int.Parse(value);
        }
    }
}
