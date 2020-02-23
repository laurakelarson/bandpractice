using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    /// <summary>
    /// Round Engine for the game.
    /// Manages rounds in the battle.
    /// </summary>
    public class RoundEngine : TurnEngine
    {
        /// <summary>
        /// Clear the monster and item lists between Rounds
        /// </summary>
        /// <returns></returns>
        private bool ClearLists()
        {
            ItemPool.Clear();
            MonsterList.Clear();
            return true;
        }


        /// <summary>
        /// Start a new round in the battle
        /// </summary>
        /// <returns></returns>
        public bool NewRound()
        {
            //TODO implement
            return true;
        }

    }
}
