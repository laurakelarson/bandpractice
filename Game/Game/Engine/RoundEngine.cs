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
            // End the existing round
            EndRound();

            // Populate New Monsters...
            AddMonstersToRound();

            // Make the EntityList: monsters and characters who are alive
            MakeEntityList();

            // Update Score for the RoundCount
            Score.RoundCount++;

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
            OrderEntityListByTurnOrder();

            // Get Next Player
            //var PlayerCurrent = GetNextPlayerInList();

            return CurrentEntity;
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public List<BattleEntityModel> OrderEntityListByTurnOrder()
        {
            // Order is based by... 
            // Order by Speed (Desending)
            // Then by Highest level (Descending)
            // Then by Highest Experience Points (Descending)
            // Then by Character before MonsterModel (enum assending)
            // Then by Alphabetic on Name (Assending)
            // Then by First in list order (Assending

            // Work with the Class variable EntityList
            EntityList = MakeEntityList();

            EntityList = EntityList.OrderByDescending(a => a.Speed)
                .ThenByDescending(a => a.Level)
                .ThenByDescending(a => a.ExperiencePoints)
                .ThenByDescending(a => a.EntityType)
                .ThenBy(a => a.Name)
                //.ThenBy(a => a.ListOrder) //TODO ListOrder
                .ToList();

            return EntityList;
        }

        /// <summary>
        /// Populates the EntityList with the characters and monsters who are alive
        /// </summary>
        /// <returns></returns>
        public List<BattleEntityModel> MakeEntityList()
        {
            // Start from a clean list of players
            EntityList.Clear();

            // Remeber the Insert order, used for Sorting
            var ListOrder = 0;

            foreach (var data in CharacterList)
            {
                if (data.Alive)
                {
                    EntityList.Add(
                        new BattleEntityModel(data)
                        {
                            // Remember the order
                            //ListOrder = ListOrder //TODO ListOrder
                        });

                    ListOrder++;
                }
            }

            foreach (var data in MonsterList)
            {
                if (data.Alive)
                {
                    EntityList.Add(
                        new BattleEntityModel(data)
                        {
                            // Remember the order
                            //ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            return EntityList;
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel GetNextPlayerInList()
        {
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null
            if (EntityList.Count == 0)
            {
                return null;
            }

            // No current player, so set the first one
            if (CurrentEntity == null)
            {
                return EntityList.FirstOrDefault();
            }

            // Find current player in the list
            var index = EntityList.FindIndex(m => m.Id.Equals(CurrentEntity.Id));

            // If at the end of the list, return the first element
            if (index == EntityList.Count() - 1)
            {
                return EntityList.FirstOrDefault();
            }

            // Return the next element
            return EntityList[index + 1];
        }

        /// <summary>
        /// Character picks up dropped items
        /// </summary>
        /// <param name="character"></param>
        public bool PickupItemsFromPool(CharacterModel character)
        {
            // Go through each location to potentially swap out item from item pool
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Necklass);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.PrimaryHand);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.OffHand);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.RightFinger);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.LeftFinger);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Feet);

            return true;
        }

        /// <summary>
        /// Checks what a character has equipped at a certain location.
        /// If there is no item equipped there or if there is an item with a higher Value in the pool,
        /// swaps the item.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="setLocation"></param>
        /// <returns></returns>
        public bool GetItemFromPoolIfBetter(CharacterModel character, ItemLocationEnum setLocation)
        {
            var myList = ItemPool.Where(a => a.Location == setLocation)
                .OrderByDescending(a => a.Value)
                .ToList();

            // If no items in the list, return...
            if (!myList.Any())
            {
                return false;
            }

            var CharacterItem = character.GetItemByLocation(setLocation);
            if (CharacterItem == null)
            {
                // If no ItemModel in the slot then put on the first in the list
                character.AddItem(setLocation, myList.FirstOrDefault());
                return true;
            }

            foreach (var PoolItem in myList)
            {
                if (PoolItem.Value > CharacterItem.Value)
                {
                    // Put on the new ItemModel, which drops the one back to the pool
                    var droppedItem = character.AddItem(setLocation, PoolItem);

                    // Remove the ItemModel just put on from the pool
                    ItemPool.Remove(PoolItem);

                    if (droppedItem != null)
                    {
                        // Add the dropped ItemModel to the pool
                        ItemPool.Add(droppedItem);
                    }
                }
            }

            return true;
        }

    }
}
