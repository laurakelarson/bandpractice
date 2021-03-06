﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Game.Helpers;
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
            if (Score.RoundCount > 0)
                // End the existing round only if past round 0
                EndRound();

            // Populate New Monsters...
            AddMonstersToRound();

            // Unbuff any buffed characters 
            //UnbuffCharacters();

            // Hackathon Scenario 33, off by one because another scenario requires roundcount to be 
            // incremented below!
            //if (Score.RoundCount == 12)
            //    UnluckyRound();

            // Make the EntityList: monsters and characters who are alive
            MakeEntityList();

            // Update Score for the RoundCount
            Score.RoundCount++;

            // Sort the EntityList
            // (note: this needs to be done after RoundCount is incremented to implement hackathon rule)
            OrderEntityListByTurnOrder();

            // Clear CurrentEntity so the first turn will be start of entity list
            CurrentEntity = null;

            // Populate MapModel with Characters and Monsters
            MapModel.PopulateMapModel(EntityList);

            // Clear the items equipped Battle Messages to accrue for new round
            BattleMessages.ItemsEquipped.Clear();

            // double experience earned every three rounds character survives
            WisdomCheck();

            return true;
        }

        /// <summary>
        /// Hackathon Hack 39 Age comes with wisdom - double experience earned every 3 levels that characters have survived
        /// </summary
        /// <returns></returns>
        public void WisdomCheck()
        {
            if (Score.RoundCount % 3 == 0)
            {
                foreach (var character in CharacterList)
                {
                    if (character.Alive)
                    {
                        character.AddExperience(character.TotalExperience); //double experience every three levels
                    }
                }
            }
        }


        ///// <summary>
        ///// Hackathon Scenario 33 - unlucky things happen on round 13
        ///// Random character falls down dead
        ///// </summary>
        //public void UnluckyRound()
        //{
        //    // first, check whether forced dice rolls are being used
        //    // if they are, exit to avoid trying to access an invalid index or create an endless loop
        //    if (DiceHelper.ForceConstantRoll == true)
        //    {
        //        var index = DiceHelper.ForcedDiceRollValue - 1;
        //        if (index >= 0 && index < CharacterList.Count())
        //        {
        //            MakeEntityList();
        //            var character = CharacterList[index];
        //            if (character.Alive)
        //                TargetDied(EntityList.First(a => a.Id == character.Id));
        //        }
        //        return;
        //    }

        //    int count = 0;
        //    while (count == 0)
        //    {
        //        var diceroll = DiceHelper.RollDice(1, CharacterList.Count()) - 1;
        //        var character = CharacterList[diceroll];
        //        if (character.Alive)
        //        {
        //            TargetDied(EntityList.First(a => a.Id == character.Id));
        //            BattleMessages.TurnMessageSpecial = character.Name + " dies a horribly unlucky death!";
        //            Debug.WriteLine(BattleMessages.TurnMessageSpecial);
        //            count++;
        //        }
        //    }


        //}

        /// <summary>
        /// Adds monsters to the round.
        /// Since monsters may be duplicated, appends a number to the name of each monster.
        /// </summary>
        /// <returns></returns>
        public int AddMonstersToRound()
        {
            // used for scaling monsters to level of characters
            int averageLevel = GetAverageCharacterLevel();
            var level = averageLevel;
            var range = new List<int> { averageLevel };
            if (averageLevel > 2 && averageLevel < 20)
            {
                range = new List<int> { averageLevel - 1, averageLevel, averageLevel + 1, averageLevel + 2 };
            } 
            

            for (var i = 0; i < MaxNumberMonsters; i++)
            {
                var data = new MonsterModel(RandomEntityHelper.GetMonsterType());
                // slightly randomizes Monster levels
                if (range.Count > 1)
                {
                    var dice = DiceHelper.RollDice(1, range.Count()) - 1;
                    if (dice >= 0 && dice < range.Count())
                    {
                        level = range.ElementAt(dice);
                    }
                }

                data.ChangeLevel(level);
                if (level == 1)
                {
                    // MONSTERS SHOULDN'T GIVE ZERO EXPERIENCE :(
                    data.ExperienceGiven = 100;
                }

                MonsterList.Add(data);
            }

            return MonsterList.Count();
        }

        /// <summary>
        /// Adds monsters to the round.
        /// Since monsters may be duplicated, appends a number to the name of each monster.
        /// </summary>
        /// <returns></returns>
        public int AddMonstersToRound(List<MonsterModel> monsters)
        {
            for (var i = 0; i < MaxNumberMonsters; i++)
            {
                var data = monsters[i];

                MonsterList.Add(data);
            }

            return MonsterList.Count();
        }

        /// <summary>
        /// Method to gather the average character level to assist in scaling monsters for the round
        /// </summary>
        /// <returns></returns>
        public int GetAverageCharacterLevel()
        {
            if (CharacterList.Count() == 0)
            {
                return 1;
            }
            var List = new List<int>(CharacterList.Select(o => o.Level));
            return (int)List.Average();
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

            // Reset attacker and defender
            CurrentAttacker = null;
            CurrentDefender = null;

            // For auto battle, do the turn....
            if (Score.AutoBattle)
            {   
                TakeTurn(CurrentEntity);
            }
            
            RoundState = RoundEnum.NextTurn;

            return RoundState;
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel GetNextPlayerTurn()
        {
            // Remove the Dead
            RemoveDeadPlayersFromList();

            // Get Next Player
            var PlayerCurrent = GetNextPlayerInList();

            return PlayerCurrent;
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        /// <returns></returns>
        public List<BattleEntityModel> RemoveDeadPlayersFromList()
        {
            EntityList = EntityList.Where(m => m.Alive == true).ToList();
            return EntityList;
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public List<BattleEntityModel> OrderEntityListByTurnOrder()
        {
            // Standard:
            // Order is based by... 
            // Order by Speed (Descending)
            // Then by Highest level (Descending)
            // Then by Highest Experience Points (Descending)
            // Then by Character before MonsterModel (enum ascending)
            // Then by Alphabetic on Name (Ascending)
            // Then by First in list order (Ascending)

            // Hackathon: Every 5th round, the sort order for turn order changes
            // and list is sorted by Characters first, then lowest health, then lowest speed

            // Special treatment for every 5th round (hackathon rule)
            if (Score.RoundCount % 5 == 0)
            {
                EntityList = EntityList.OrderBy(a => a.EntityType)
                    .ThenBy(a => a.CurrentHealth)
                    .ThenBy(a => a.Speed)
                    .ToList();

                return EntityList;
            }

            EntityList = EntityList.OrderByDescending(a => a.Speed)
                .ThenByDescending(a => a.Level)
                .ThenByDescending(a => a.ExperiencePoints)
                .ThenBy(a => a.EntityType)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.ListOrder)
                .ToList();

            //// Hackathon scenario 30 - volunteer to be first
            //// if character position in list is 0 they get buffed, otherwise no buff
            //if (EntityList[0].EntityType == EntityTypeEnum.Character && !EntityList[0].FirstBuff)
            // {
            //    EntityList[0].BuffCharacterStats();
            //    EntityList[0].FirstBuff = true; 
            // }
            

            return EntityList;
        }

        ///// <summary>
        ///// Method to unbuff any buffed characters at beginning of round before entity list is remade
        ///// </summary>
        //public void UnbuffCharacters()
        //{
        //    foreach (var entity in EntityList)
        //    {
        //        if (entity.FirstBuff)
        //        {
        //            entity.UnbuffCharacterStats();
        //            entity.FirstBuff = false;
        //        }
        //    }
        //}

        /// <summary>
        /// Populates the EntityList with the characters and monsters who are alive
        /// </summary>
        /// <returns></returns>
        public List<BattleEntityModel> MakeEntityList()
        {

            // Start from a clean list of players
            EntityList.Clear();

            // Remember the Insert order, used for Sorting
            var ListOrder = 0;

            foreach (var data in CharacterList)
            {
                if (data.Alive)
                {
                    EntityList.Add(
                        new BattleEntityModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
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
                            ListOrder = ListOrder
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
                SwapCharacterItem(character, setLocation, myList.FirstOrDefault());

                return true;
            }

            foreach (var PoolItem in myList)
            {
                if (PoolItem.Value > CharacterItem.Value)
                {
                    SwapCharacterItem(character, setLocation, PoolItem);
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// Swap the Item the character has for one from the pool
        /// 
        /// Drop the current item back into the Pool
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="setLocation"></param>
        /// <param name="PoolItem"></param>
        /// <returns></returns>
        private ItemModel SwapCharacterItem(CharacterModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            // Put on the new ItemModel, which drops the one back to the pool
            var droppedItem = character.AddItem(setLocation, PoolItem);

            // Update BattleMessage
            BattleMessages.AddItemEquipped(character.Name, PoolItem.Name);

            // Remove the ItemModel just put on from the pool
            ItemPool.Remove(PoolItem);

            if (droppedItem != null)
            {
                // Add the dropped ItemModel to the pool
                ItemPool.Add(droppedItem);
            }

            return droppedItem;
        }

    }
}
