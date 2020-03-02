using System;
using System.Collections.Generic;
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
    }
}
