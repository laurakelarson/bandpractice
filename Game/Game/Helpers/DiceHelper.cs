using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    
    /// <summary>
    /// Dice helper class. Can simulate dice roll for 
    /// values between "low" and "high"
    /// </summary>
    public static class DiceHelper
    {

        // Random object for dice roll generation
        private static Random rnd = new Random();

        // Indicates whether rolls are random or not
        public static bool ForceRollsToNotRandom = false;

        // Holds the exact value of a dice roll if
        // not using random rolls
        private static int ForcedDiceRollValue = 1;

        // Sets the dice roll to the value passed in 
        public static void SetForcedDiceRollValue(int value)
        {
            ForcedDiceRollValue = value; 
        }

        // Get random dice roll 
        public static int DiceRoller(int low, int high)
        {
            Random r = new Random();
            var roll = r.Next(low, high);
            return roll;
        }
    }
}
