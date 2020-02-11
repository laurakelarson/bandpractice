using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
    class CharacterTypeEnumHelper
    {
        /// <summary>
        ///  Gets the list of locations a character can use
        ///  Removes Finger for example, and allows for left and right finger
        /// </summary>
        public static List<string> GetListCharacterType
        {
            get
            {
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
        public static CharacterTypeEnum ConvertStringToEnum(string value)
        {
            return (CharacterTypeEnum)Enum.Parse(typeof(CharacterTypeEnum), value);
        }
    }
}
