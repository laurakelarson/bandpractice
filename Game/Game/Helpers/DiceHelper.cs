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
        public static bool ForceConstantRoll = false;

        // Holds the exact value of a dice roll if
        // not using random rolls
        private static int ForcedDiceRollValue = 1;

        // Sets the dice roll to the value passed in 
        public static void SetForcedDiceRollValue(int value)
        {
            ForcedDiceRollValue = value; 
        }

        /// <summary>
        /// When invoked, ensures that the dice roller will 
        /// always roll value set in ForcedDiceRollValue.
        /// </summary>
        public static void DisableRandomValues()
        {
            ForceConstantRoll = true; 
        }

        /// <summary>
        /// When invoked, ensures that the dice roller will
        /// roll random values. 
        /// </summary>
        public static void EnableRandomValues()
        {
            ForceConstantRoll = false; 
        }

        /// <summary>
        /// Rolls dice for indicated number of rolls. 
        /// </summary>
        /// <param name="rolls"></param>
        /// <param name="dice"></param>
        /// <returns></returns>
        public static int RollDice(int rolls, int dice)
        {
            // invalid roll value
            if (rolls < 0)
            {
                return 0; 
            }

            // invalid dice value
            if (dice < 0)
            {
                return 0; 
            }

            // ForcedConstantRoll == true
            if (ForceConstantRoll)
            {
                return rolls * ForcedDiceRollValue; 
            }

            // roll dice 
            var diceRollTotal = 0; 
            for (var i = 0; i < rolls; i++)
            {
                diceRollTotal += rnd.Next(1, dice + 1);
            }

            return diceRollTotal;
        }
    }
}
