using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    class DiceHelper
    {
        Random r = new Random();

        public int diceRoller(int low, int high)
        {
            var roll = r.Next(low, high);
            return roll;
        }
    }
}
