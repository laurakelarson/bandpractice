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

        /// <summary>
        /// Starts the battle
        /// </summary>
        /// <param name="isAutoBattle"></param>
        /// <returns></returns>
        public bool StartBattle(bool isAutoBattle)
        {
            Score = new ScoreModel  // refresh score
            {
                AutoBattle = isAutoBattle
            };

            BattleRunning = true;

            //TODO NewRound();

            return true;
        }

        /// <summary>
        /// Ends the battle
        /// </summary>
        /// <returns></returns>
        public bool EndBattle()
        {
            BattleRunning = false;

            return true;
        }

    }
}
