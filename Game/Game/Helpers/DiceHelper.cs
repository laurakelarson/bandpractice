using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    
    /// <summary>
    /// Dice helper class. Can simulate dice roll for 
    /// values between "low" and "high"
    /// </summary>
    class DiceHelper
    {
        Random r = new Random();

        // Get random dice roll 
        public int DiceRoller(int low, int high)
        {
            var roll = r.Next(low, high);
            return roll;
        }
    }
}
