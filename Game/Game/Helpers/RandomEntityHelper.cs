using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Helpers
{
    class RandomEntityHelper
    {

        /// <summary>
        /// Get Health
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int GetHealth(int level)
        {
            // Roll the Dice and reset the Health
            return DiceHelper.RollDice(level, 10);
        }

        // get monster type

        // get character name
        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name for a Character
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterName()
        {

            List<String> FirstNameList = new List<String> { "Frankie", "DJ Thunder", "Kit", "Vic", "Spark", "Ace", 
                "Charlie", "Crazy Danni Chill", "Big Celeste Koopa", "Sovereign", "Avery", "Riley", "Dakota", "Reese", "Remi", "Mr. Laura", 
                "Nicki Mythic", "Harley", "Dr. Funk", "Sage", "Dallas", "River", "Eden", "Angel Skye", "Sutton", "Ali", "MC Alex Duke",
                "Lennox", "Quincy", "Ally A Trigga", "Monroe", "Devon", "Blade", "Francis", "Blair", "Memphis", "Bowie", 
                "Rebel", "Ripley", "Indigo", "Zephyr", "Ari", "Sasha", "Jojo", "Mimi", "Maverick", "Rambo", "Jax", 
                "T. Riddle", "Juniper", "DJ Rumor", "Lil Dizzee", "C. Dolla"};

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Random Monster type
        /// </summary>
        /// <returns></returns>
        public static MonsterTypeEnum GetMonsterType()
        {
 
            var result = (MonsterTypeEnum)(DiceHelper.RollDice(1, 22));

            return result;
        }
    }
}
