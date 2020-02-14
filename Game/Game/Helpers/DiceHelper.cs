using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    
    /// <summary>
    /// Dice helper class. Can simulate dice roll for 
    /// values between "low" and "high"
    /// </summary>
    static class DiceHelper
    {
        
        // Get random dice roll 
        public static int DiceRoller(int low, int high)
        {
            Random r = new Random();
            var roll = r.Next(low, high);
            return roll;
        }
    }
}
