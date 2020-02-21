using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;

namespace Game.Engine
{
    /// <summary>
    /// Battle Engine for the game.
    /// Container for battle rounds (inheritance from RoundEngine) and
    /// battle turns (RoundEngine inherits from TurnEngine)
    /// </summary>
    class BattleEngine : RoundEngine
    {
        // Track whether battle is running
        public bool BattleRunning = false;

        /// <summary>
        /// Adds a Character/"band member" to the battle
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddBandMember(CharacterModel member)
        {
            CharacterList.Add(new CharacterModel(member));

            return true;
        }
    }
}
