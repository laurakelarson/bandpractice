using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    class DiceHelper
    {
        Random r = new Random();

        public int diceRoller(int sides)
        {
            var roll = r.Next(1, sides);
            return roll;
        }
    }
}
