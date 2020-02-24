using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Models;

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

        /// <summary>
        /// Adds monsters to the round.
        /// Since monsters may be duplicated, appends a number to the name of each monster.
        /// </summary>
        /// <returns></returns>
        public int AddMonstersToRound()
        {
            for (var i = 0; i < MaxNumberMonsters; i++)
            {
                var data = new MonsterModel();
                // Help identify which Monster it is
                data.Name += " " + MonsterList.Count() + 1;
                MonsterList.Add(new MonsterModel(data));
            }

            return MonsterList.Count();
        }

    }
}
