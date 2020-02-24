using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Models;
using Game.Models.Enum;

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

        /// <summary>
        /// Ends the round by having characters pick up items and clearing the monster and item lists.
        /// </summary>
        /// <returns></returns>
        public bool EndRound()
        {
            // Have each character pickup items...
            foreach (var character in CharacterList)
            {
                PickupItemsFromPool(character);
            }

            // Reset Monster and Item Lists
            ClearLists();

            return true;
        }

        /// <summary>
        /// Manage the next turn in this round.
        /// If no more players, game over.
        /// If no more monsters, round is over.
        /// Otherwise it's the next entity's turn.
        /// </summary>
        /// <returns></returns>
        public RoundEnum RoundNextTurn()
        {
            // No characters, game is over...
            if (CharacterList.Count < 1)
            {
                // Game Over
                RoundState = RoundEnum.GameOver;
                return RoundState;
            }

            // Check if round is over
            if (MonsterList.Count < 1)
            {
                // If over, New Round
                RoundState = RoundEnum.NewRound;
                return RoundEnum.NewRound;
            }

            // Decide Who gets next turn
            // Remember who just went...
            CurrentEntity = GetNextPlayerTurn();

            // Do the turn....
            //TakeTurn(CurrentEntity);

            RoundState = RoundEnum.NextTurn;

            return RoundState;
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel GetNextPlayerTurn()
        {
            // Recalculate Order
            OrderPlayerListByTurnOrder();

            // Get Next Player
            //var PlayerCurrent = GetNextPlayerInList();

            return CurrentEntity;
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public List<BattleEntityModel> OrderPlayerListByTurnOrder()
        {
            // Order is based by... 
            // Order by Speed (Desending)
            // Then by Highest level (Descending)
            // Then by Highest Experience Points (Descending)
            // Then by Character before MonsterModel (enum assending)
            // Then by Alphabetic on Name (Assending)
            // Then by First in list order (Assending

            // Work with the Class variable PlayerList
            //EntityList = MakePlayerList();

            //EntityList = EntityList.OrderByDescending(a => a.GetSpeed())
            //    .ThenByDescending(a => a.Level)
            //    .ThenByDescending(a => a.ExperiencePoints)
            //    .ThenByDescending(a => a.PlayerType)
            //    .ThenBy(a => a.Name)
            //    .ThenBy(a => a.ListOrder)
            //    .ToList();

            EntityList = new List<BattleEntityModel>();
            return EntityList;
        }

        /// <summary>
        /// Character picks up dropped items
        /// </summary>
        /// <param name="character"></param>
        public bool PickupItemsFromPool(BattleEntityModel character)
        {
            //TODO implement
            return true;
        }

    }
}
