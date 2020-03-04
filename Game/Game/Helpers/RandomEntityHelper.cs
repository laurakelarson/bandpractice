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
        /// Get Name
        /// 
        /// Return a Random Name for a Character
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterName()
        {

            List<String> FirstNameList = new List<String> { "Frankie", "DJ Thunder", "Kit", "Vic", "Spark", "Ace", "Rudy", "Bogus", "Wednesday",
                "Charlie", "Crazy Danni Chill", "Big Celeste Koopa", "Sovereign", "Avery", "Riley", "Dakota", "Reese", "Remi", "Mr. Laura", 
                "Nicki Mythic", "Harley", "Dr. Funk", "Sage", "Dallas", "River", "Eden", "Angel Skye", "Sutton", "Ali", "MC Alex Duke",
                "Lennox", "Quincy", "Ally A Trigga", "Monroe", "Devon", "Blade", "Francis", "Blair", "Memphis", "Bowie", "Lane", "Silver",
                "Rebel", "Ripley", "Indigo", "Zephyr", "Ari", "Sasha", "Jojo", "Mimi", "Maverick", "Rambo", "Jax", "Harper", "Rowan",
                "T. Riddle", "Juniper", "DJ Rumor", "Lil Dizzee", "C. Dolla", "Jade", "Shade", "Bennie", "Jude", "Marley", "Enigma",
                "MC McFly", "Lil Ice", "Eazy", "Young Spyda", "Commander Keys", "Mac Rocket", "Riri", "Aria", "Harmony", "Cadenza",
                "Chanson", "Lark", "Piper", "Rhapsody"};

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
