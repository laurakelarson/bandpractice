﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Helpers;
using Game.Models;
using Game.Models.Enum;
using Game.Services;
using Game.ViewModels;

namespace Game.Engine
{
    /// <summary>
    /// Turn Engine for the game.
    /// Manages an entity (character or monster) taking a turn.
    /// </summary>
    public class TurnEngine : BaseEngine
    {
        #region Algorithm
        // Turn consists of a Move or Attack
        //
        // Move:
        //      Move to an empty space on the Map
        //      Turn Over
        //
        // Attack:
        //      Allowed only if in range of target
        //      Roll To Hit
        //      Decide Hit or Miss
        //      Decide Damage
        //      Death
        //      Drop Items
        //      Turn Over
        #endregion Algorithm


        /// <summary>
        /// The current attacker takes their turn.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool TakeTurn(BattleEntityModel Attacker)
        {
            CurrentAttacker = Attacker;

            Score.TurnCount++;

            // Assume Move if nothing else happens
            CurrentAction = ActionEnum.Move;

            // See if Desired Target is within Range, and if so attack away
            if (MapModel.IsTargetInRange(Attacker, AttackChoice(Attacker)))
            {
                CurrentAction = ActionEnum.Attack;
            }

            // Perform the action
            switch (CurrentAction)
            {
                case ActionEnum.Attack:
                    return Attack(Attacker);
                case ActionEnum.Move:
                case ActionEnum.Unknown:
                default:
                    return MoveAsTurn(Attacker);
            }
        }

        /// <summary>
        /// Character takes a turn by performing an action on the specified MapModelLocation.
        /// Possible actions are:
        ///     Attack: if location has a monster in range
        ///     Move: if location has a monster out of range, or location is empty
        ///     Swap: if location has a character, the characters swap places
        ///     Wait: if character's own square was clicked, do nothing
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CharacterManualTurn(BattleEntityModel Attacker, MapModelLocation Location)
        {
            Score.TurnCount++;
            CurrentAttacker = Attacker;

            // only characters are allowed to do manual attacks
            if (Attacker.EntityType == EntityTypeEnum.Monster)
            {
                return false;
            }

            // is there a monster at the location?
            if (Location.Player.EntityType == EntityTypeEnum.Monster)
            {
                CurrentDefender = Location.Player;

                // is it in range? attack...
                if (MapModel.IsTargetInRange(Attacker, Location.Player))
                {
                    return TurnAsAttack(Attacker, Location.Player);
                }

                // otherwise move to the closest found space
                var openSquare = MapModel.ReturnClosestEmptyLocation(Location);
                var current = MapModel.GetLocationForPlayer(Attacker);

                Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", Attacker.Name,
                    current.Column, current.Row, openSquare.Column, openSquare.Row));

                BattleMessages.TurnMessage = Attacker.Name + " moves closer to " + CurrentDefender.Name;

                return MapModel.MovePlayerOnMap(current, openSquare);
            }

            // is the location empty?
            if (Location.Player.EntityType == EntityTypeEnum.Unknown)
            {
                CurrentDefender = null;

                // move to empty space
                var current = MapModel.GetLocationForPlayer(Attacker);

                Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", Attacker.Name,
                    current.Column, current.Row, Location.Column, Location.Row));

                BattleMessages.TurnMessage = Attacker.Name + " moves to an empty space";

                return MapModel.MovePlayerOnMap(current, Location);
            }

            // is there a character at the location?
            if (Location.Player.EntityType == EntityTypeEnum.Character)
            {
                CurrentDefender = null;

                // is this my own space?
                if (Location.Player.Id.Equals(Attacker.Id))
                {
                    Debug.WriteLine(string.Format("{0} hums a song and does nothing", Attacker.Name));

                    BattleMessages.TurnMessage = Attacker.Name + " hums a song and does nothing";

                    return true;
                }

                // characters swap locations
                var current = MapModel.GetLocationForPlayer(Attacker);

                Debug.WriteLine(string.Format("{0} moves and swaps places with {1} ", Attacker.Name,
                    Location.Player.Name));

                BattleMessages.TurnMessage = Attacker.Name + " moves and swaps places with " + Location.Player.Name;

                return MapModel.SwapPlayersOnMap(current, Location);
            }

            // did not perform action
            return false;
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool MoveAsTurn(BattleEntityModel Attacker)
        {

            /*
             * Move Logic
             *      Find the desired target based on MoveChoice:
             *          Character goes for lowest current health, then highest level
             *          Monster goes for highest current health, then highest level
             *      Find an empty square near the target that is reachable based on Attacker's range
             *      Jump/teleport to the empty square
             *
             * If no open spaces, return false
             * 
             */
            // For Attack, Choose Who
            CurrentDefender = MoveChoice(Attacker);

            if (CurrentDefender == null)
            {
                return false;
            }

            // Get X, Y for Defender
            var locationDefender = MapModel.GetLocationForPlayer(CurrentDefender);
            if (locationDefender == null)
            {
                return false;
            }

            var locationAttacker = MapModel.GetLocationForPlayer(Attacker);
            if (locationAttacker == null)
            {
                return false;
            }

            // Find Location Nearest to Defender that is Open.

            // Get the Open Locations - preference to first found spot that is in Range distance
            var openSquare = MapModel.ReturnClosestEmptyLocation(locationDefender, Attacker.Range);

            // No empty square found
            if (openSquare == null)
            {
                Debug.WriteLine(string.Format("{0} waits", locationAttacker.Player.Name));

                BattleMessages.TurnMessage = Attacker.Name + " waits";

                return false;
            }

            Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", locationAttacker.Player.Name,
                locationAttacker.Column, locationAttacker.Row, openSquare.Column, openSquare.Row));

            BattleMessages.TurnMessage = Attacker.Name + " moves closer to " + CurrentDefender.Name;

            return MapModel.MovePlayerOnMap(locationAttacker, openSquare);
        }

        /// <summary>
        /// Decide who to move toward
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BattleEntityModel MoveChoice(BattleEntityModel data)
        {
            switch (data.EntityType)
            {
                case EntityTypeEnum.Monster:
                    return SelectCharacterToMoveToward();

                case EntityTypeEnum.Character:
                default:
                    return SelectMonsterToMoveToward();
            }
        }

        /// <summary>
        /// Pick the Character to Move toward
        /// Decide by highest current health, then highest level
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel SelectCharacterToMoveToward()
        {
            if (CharacterList == null)
            {
                return null;
            }

            if (CharacterList.Count < 1)
            {
                return null;
            }

            // Select character to move to based on highest current health, then highest level
            var Defender = EntityList
                   .Where(m => m.Alive && m.EntityType == EntityTypeEnum.Character)
                   .OrderByDescending(m => m.CurrentHealth)
                   .ThenByDescending(m => m.Level)
                   .FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Move toward
        /// Decide by lowest current health, then highest level
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel SelectMonsterToMoveToward()
        {
            if (MonsterList == null)
            {
                return null;
            }

            if (MonsterList.Count < 1)
            {
                return null;
            }

            // Select closest monster to attack
            // Break ties on lowest current health, then highest level
            var Defender = EntityList
                   .Where(m => m.Alive && m.EntityType == EntityTypeEnum.Monster)
                   .OrderBy(m => m.CurrentHealth)
                   .ThenByDescending(m => m.Level)
                   .FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Attack as a turn.
        ///
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool Attack(BattleEntityModel Attacker)
        {
            // If no defender, should return null regardless of autobattle or regular battle
            
            // For Attack, Choose Who
            CurrentDefender = AttackChoice(Attacker);
            if (CurrentDefender == null)
            {
                return false;
            }


            // Do Attack
            TurnAsAttack(Attacker, CurrentDefender);

            return true;
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BattleEntityModel AttackChoice(BattleEntityModel data)
        {
            switch (data.EntityType)
            {
                case EntityTypeEnum.Monster:
                    return SelectCharacterToAttack();

                case EntityTypeEnum.Character:
                default:
                    return SelectMonsterToAttack();
            }
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel SelectCharacterToAttack()
        {
            if (CharacterList == null)
            {
                return null;
            }

            if (CharacterList.Count < 1)
            {
                return null;
            }

            // Select closest character to attack
            // Break ties on highest current health, then highest level
            var Defender = EntityList
                   .Where(m => m.Alive && m.EntityType == EntityTypeEnum.Character)
                   .OrderBy(m => MapModel.CalculateDistance(MapModel.GetLocationForPlayer(CurrentAttacker), MapModel.GetLocationForPlayer(m)))
                   .ThenByDescending(m => m.CurrentHealth)
                   .ThenByDescending(m => m.Level)
                   .FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        /// <returns></returns>
        public BattleEntityModel SelectMonsterToAttack()
        {
            if (MonsterList == null)
            {
                return null;
            }

            if (MonsterList.Count < 1)
            {
                return null;
            }

            // Select closest monster to attack
            // Break ties on lowest current health, then highest level
            var Defender = EntityList
                   .Where(m => m.Alive && m.EntityType == EntityTypeEnum.Monster)
                   .OrderBy(m => MapModel.CalculateDistance(MapModel.GetLocationForPlayer(CurrentAttacker), MapModel.GetLocationForPlayer(m)))
                   .ThenBy(m => m.CurrentHealth)
                   .ThenByDescending(m => m.Level)
                   .FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Process the attack. Use BattleMessagesModel to communicate actions.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool TurnAsAttack(BattleEntityModel attacker, BattleEntityModel target)
        {
            if (attacker == null)
            {
                return false;
            }

            if (target == null)
            {
                return false;
            }

            // refresh battle messages for turn
            BattleMessages.ClearMessages();

            // Hackathon
            // Hackathon Scenario 2, Bob alwasys misses
            if (attacker.Name.Equals("Bob"))
            {
                BattleMessages.HitStatus = HitStatusEnum.Miss;
                BattleMessages.TurnMessage = "Bob always Misses";
                Debug.WriteLine(BattleMessages.TurnMessage);
                return true;
            }

            BattleMessages.PlayerType = EntityTypeEnum.Monster;

            var AttackScore = GetAttack(attacker);
            var DefenseScore = GetDefense(target);

            // Choose who to attack

            BattleMessages.TargetName = target.Name;
            BattleMessages.AttackerName = attacker.Name;

            BattleMessages.HitStatus = RollToHitTarget(AttackScore, DefenseScore);

            Debug.WriteLine(BattleMessages.GetTurnMessage());

            // It's a Miss
            if (BattleMessages.HitStatus == HitStatusEnum.Miss)
            {
                BattleMessages.TurnMessage = attacker.Name + " blunders and misses " + target.Name;
                // Check if Critical Miss is enabled (hackathon rule)
                if (CriticalMissEnabled)
                {
                    if (BattleMessages.CriticalMiss)
                    {
                        CriticalMiss(attacker);

                        BattleMessages.TurnMessage += BattleMessages.CriticalMissMessage;

                        // toggle flag
                        BattleMessages.CriticalMiss = false;
                    }
                }

                Debug.WriteLine(BattleMessages.TurnMessage);

                return true;
            }

            // It's a Hit
            if (BattleMessages.HitStatus == HitStatusEnum.Hit) { 

                //Calculate Damage
                BattleMessages.DamageAmount = GetDamage(attacker);

                // Calculate Critical Hit if enabled
                if (CriticalHitsEnabled)
                {
                    if (BattleMessages.CriticalHit)
                    {
                        BattleMessages.DamageAmount *= 2;
                    }
                }

                if (target.EntityType == EntityTypeEnum.Monster)
                {
                    double FractionalExperience = (double)BattleMessages.DamageAmount / (double)target.MaxHealth;
                    int ExperienceGained = (int)Math.Ceiling(FractionalExperience * (double)target.ExperiencePoints);
                    TakeDamage(target, BattleMessages.DamageAmount);
                    // If monster takes damage he loses proportional amount of remaining experience points to attacker
                    AddExperience(attacker, ExperienceGained);
                    target.ExperiencePoints -= ExperienceGained;
                }
               else
                {
                    TakeDamage(target, BattleMessages.DamageAmount);
                }

            }

            // update battle messages
            BattleMessages.CurrentHealth = target.CurrentHealth;
            BattleMessages.AttackStatus = " strikes ";
            BattleMessages.TurnMessage = attacker.Name + BattleMessages.AttackStatus + target.Name + BattleMessages.GetCurrentHealthMessage();

            if (CriticalHitsEnabled)
            {
                if (BattleMessages.CriticalHit)
                {
                    BattleMessages.TurnMessage += "\nCritical Hit!!!";
                    BattleMessages.CriticalHit = false; // toggle flag
                }
            }

            Debug.WriteLine(BattleMessages.TurnMessage);

            RemoveIfDead(target);

            return true;
        }

        /// <summary>
        /// Process Experience Points gained from killing a monster.
        /// Add to battle score and to the attacking character's experience.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool AddExperience(BattleEntityModel entity, int experience)
        {
            if (entity == null)
            {
                return false;
            }

            if (entity.EntityType == EntityTypeEnum.Monster)
            {
                return false;
            }

            // character should gain experience
            var character = CharacterList.Where(a => a.Id == entity.Id).FirstOrDefault();
            int level = character.Level;
            character.AddExperience(experience);
            EntityList.Where(a => a.Id == character.Id).FirstOrDefault().Update(character);

            // update battle messages
            BattleMessages.ExperienceEarned = "Won " + experience + " beats!";
            Debug.WriteLine(BattleMessages.ExperienceEarned);

            // did character level up?
            if (level != character.Level)
            {
                BattleMessages.LevelUpMessage = entity.Name + " is now Level " + entity.Level + " with max health of " + entity.MaxHealth;
                Debug.WriteLine(BattleMessages.LevelUpMessage);
            }

            // update score - both Experience and Total Score
            Score.ScoreTotal += experience;
            Score.ExperienceGainedTotal += experience;

            return true;
        }


        /// <summary>
        /// Have the damage taken be reflected in the Character or Monster List
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool TakeDamage(BattleEntityModel Target, int damage)
        {
            if (Target == null)
                return false;

            Target.TakeDamage(damage);

            switch (Target.EntityType)
            {
                case (EntityTypeEnum.Character):
                    var character = CharacterList.First(a => a.Id == Target.Id);
                    character.TakeDamage(damage);
                    // Hackathon scenario 9 - Miracle Max
                    if(!character.Alive && character.MiracleMax)
                    {
                        EntityList.First(a => a.Id == Target.Id).CurrentHealth = character.MaxHealth; // it's a miracle!
                        character.CurrentHealth = character.MaxHealth;
                        character.MiracleMax = false;
                        EntityList.First(a => a.Id == Target.Id).Alive = true;
                        EntityList.First(a => a.Id == Target.Id).CurrentHealth = character.MaxHealth;
                        character.Alive = true;
                        BattleMessages.TurnMessageSpecial = character.Name + " has been miraculously revived by Miracle Max!\nSee Miracle Max for all of your miraculous needs~";
                        Debug.WriteLine(BattleMessages.TurnMessageSpecial);
                    }
                    return true;
                case (EntityTypeEnum.Monster):
                default:
                    MonsterList.First(a => a.Id == Target.Id).TakeDamage(damage);
                    return true;
            }

        }

        /// <summary>
        /// Gets the attack value (including any stat boosts) of the character or monster
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int GetAttack(BattleEntityModel attacker)
        {
            switch (attacker.EntityType)
            {
                case (EntityTypeEnum.Character):
                    return CharacterList.Where(a => a.Id == attacker.Id).FirstOrDefault().GetAttackValue();
                case (EntityTypeEnum.Monster):
                default:
                    return MonsterList.Where(a => a.Id == attacker.Id).FirstOrDefault().GetAttackValue();
            }
        }

        /// <summary>
        /// Gets the defense value (including any stat boosts) of the character of monster
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int GetDefense(BattleEntityModel target)
        {
            switch (target.EntityType)
            {
                case (EntityTypeEnum.Character):
                    var character = CharacterList.Where(a => a.Id == target.Id).FirstOrDefault();
                    return character.Defense + character.Level + character.GetItemBonus(AttributeEnum.Defense);
                case (EntityTypeEnum.Monster):
                default:
                    return target.Defense + target.Level;
            }
        }

        /// <summary>
        /// Gets the roll of the damage value (including any stat boosts) of the character or monster
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int GetDamage(BattleEntityModel attacker)
        {
            switch (attacker.EntityType)
            {
                case (EntityTypeEnum.Character):
                    return CharacterList.Where(a => a.Id == attacker.Id).FirstOrDefault().RollDamageDice();
                case (EntityTypeEnum.Monster):
                default:
                    return MonsterList.Where(a => a.Id == attacker.Id).FirstOrDefault().RollDamageDice();
            }
        }


        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        /// <param name="Target"></param>
        public bool RemoveIfDead(BattleEntityModel Target)
        {
            // Check for alive
            if (Target.Alive == false)
            {
                return TargetDied(Target);
            }

            return false;
        }

        /// <summary>
        /// Process an entity's death.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool TargetDied(BattleEntityModel target)
        {
            // Mark Status in output
            BattleMessages.TurnMessageSpecial = target.Name + " has perished.";

            // Remove target from Map
            MapModel.RemovePlayerFromMap(target);

            // Using a switch so in the future additional PlayerTypes can be added (Boss...)
            switch (target.EntityType)
            {
                case EntityTypeEnum.Character:
                    DropItems(target);

                    var character = CharacterList.Where(a => a.Id == target.Id).FirstOrDefault();

                    CharacterList.Remove(character);
                    EntityList.Remove(EntityList.Find(m => m.Id.Equals(target.Id)));

                    // Add the MonsterModel to the killed list
                    Score.CharacterAtDeathList += character.FormatOutput() + "\n";

                    Debug.WriteLine(BattleMessages.TurnMessageSpecial);

                    return true;

                case EntityTypeEnum.Monster:
                default:
                    DropItems(target);

                    var monster = MonsterList.Where(a => a.Id == target.Id).FirstOrDefault();

                    MonsterList.Remove(monster);
                    EntityList.Remove(EntityList.Find(m => m.Id.Equals(target.Id)));

                    // Add one to the monsters killed count...
                    Score.MonsterSlainNumber++;

                    // Add the MonsterModel to the killed list
                    Score.MonstersKilledList += monster.FormatOutput() + "\n";

                    Debug.WriteLine(BattleMessages.TurnMessageSpecial);

                    return true;
            }
        }

        /// <summary>
        /// Have the target drop all their items
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int DropItems(BattleEntityModel target)
        {
            // Reset item drop message
            BattleMessages.ItemDropMessage = string.Empty;

            // Drop Items to ItemModel Pool
            var myItemList = RemoveItems(target);

            // Add monster drop items
            if (target.EntityType == EntityTypeEnum.Monster)
            {
                myItemList.AddRange(GetRandomMonsterItemDrops(myItemList));

                if (CloudItemDropEnabled)
                {
                    var cloudItem = Task.Run(async () => await GetExternalItem(target.Level)).Result;

                    if (cloudItem != null)
                    {
                        myItemList.Add(cloudItem);
                    }
                }

                //// Hackathon Scenario 10
                //if (myItemList.Count == 1)
                //{
                //    var diceroll = DiceHelper.RollDice(1, 10);
                //    if (diceroll == 1)
                //    {
                //        var damageroll = DiceHelper.RollDice(1, 4);
                //        var damage = Score.RoundCount * damageroll;
                //        BattleMessages.ItemDropMessage += "GRENADE dropped!";
                //        Debug.WriteLine(BattleMessages.TurnMessageSpecial);

                //        foreach (var monster in MonsterList)
                //        {
                //            // monsters take damage
                //            TakeDamage(EntityList.First(a => a.Id == monster.Id), damage);
                //            // remove monsters if dead
                //            var dead = RemoveIfDead(EntityList.First(a => a.Id == monster.Id));
                //            // add dead monsters' items to myItemList
                //            if (dead)
                //            {
                //                var monsterItemList = RemoveItems(EntityList.First(a => a.Id == monster.Id));
                //                myItemList.AddRange(GetRandomMonsterItemDrops(monsterItemList));
                //            }
                //        }
                //    }
                //}
            }
            var itemsForPool = new List<ItemModel>();

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                if (ItemModel != null)
                {
                    Score.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                    BattleMessages.ItemDropMessage += "\n" + ItemModel.Name + " dropped";

                    itemsForPool.Add(ItemModel);
                }
            }

            Debug.WriteLine(BattleMessages.ItemDropMessage);

            ItemPool.AddRange(itemsForPool);

            return myItemList.Count();
        }

        /// <summary>
        /// Have the character or monster drop all their items and returns the list of item models
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<ItemModel> RemoveItems(BattleEntityModel target)
        {
            switch (target.EntityType)
            {
                case (EntityTypeEnum.Character):
                    return CharacterList.Where(a => a.Id == target.Id).FirstOrDefault().DropAllItems();
                case (EntityTypeEnum.Monster):
                default:
                    return MonsterList.Where(a => a.Id == target.Id).FirstOrDefault().DropItems();
            }
        }

        /// <summary>
        /// Sends a post request to the item cloud server for use in monster item drop.
        /// Request value based on the level of the monster.
        /// </summary>
        /// <param name="MonsterLevel"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<ItemModel> GetExternalItem(int MonsterLevel)
        {
            var number = 1;
            var level = Math.Min(6, MonsterLevel);  // Max Value of 6
            var attribute = AttributeEnum.Unknown;  // Any Attribute
            var location = ItemLocationEnum.Unknown;    // Any Location
            var random = true;  // Random between 1 and Level
            var updateDataBase = true;  // Add them to the DB
            var category = 0;   // What category to filter down to, 0 is all

            // send post request to server
            var dataList = await ItemService.GetItemsFromServerPostAsync(number, level, attribute, location,
                category, random, updateDataBase);

            return dataList.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Roll to hit. Use BattleMessagesModel to convey what is happening.
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        /// <returns></returns>
        public HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            var d20 = DiceHelper.RollDice(1, 20);

            if (d20 == 1)
            {
                // flag Critical Miss if enabled (hackathon rule)
                if (CriticalMissEnabled)
                {
                    BattleMessages.CriticalMiss = true;
                }

                // Force Miss
                BattleMessages.HitStatus = HitStatusEnum.Miss;
                return BattleMessages.HitStatus;
            }

            if (d20 == 20)
            {
                // Force Hit
                BattleMessages.HitStatus = HitStatusEnum.Hit;

                if (CriticalHitsEnabled)
                {
                    BattleMessages.CriticalHit = true;
                }

                return BattleMessages.HitStatus;
            }

            var ToHitScore = d20 + AttackScore;
            if (ToHitScore < DefenseScore)
            {
                BattleMessages.AttackStatus = " blunders and misses ";
                // Miss
                BattleMessages.HitStatus = HitStatusEnum.Miss;
                BattleMessages.DamageAmount = 0;
               
                return BattleMessages.HitStatus;
            }

            // Hit
            BattleMessages.HitStatus = HitStatusEnum.Hit;
            return BattleMessages.HitStatus;
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public List<ItemModel> GetRandomMonsterItemDrops(List<ItemModel> list)
        {
            // number of random drops is a dice roll based on the monster's item pockets
            var NumberToDrop = DiceHelper.RollDice(1, 3);

            // check if forced dice rolls are being used
            // if they are, set roll to 3 to avoid index out of range error in loop below
            if (DiceHelper.ForceConstantRoll == true)
            {
                NumberToDrop = 3;
            }

            var myList = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                // add items from monster's pockets
                myList.Add(list[i]);
            }

            return myList;
        }

        /// <summary>
        /// Handle the Critical Miss event (if enabled)
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool CriticalMiss(BattleEntityModel attacker)
        {
            switch (attacker.EntityType)
            {
                case EntityTypeEnum.Monster:
                    return MonsterCriticalMiss(MonsterList.First(a => a.Id == attacker.Id));

                case EntityTypeEnum.Character:
                    return CharacterCriticalMiss(CharacterList.First(a => a.Id == attacker.Id));
                default:
                    return false;
            }
        }

        /// <summary>
        /// Character experience a critical miss.
        /// After rolling a critical miss. Roll a 10 sided dice. The following things can happen.
        /// Roll Value 
        ///     1, Primary Hand Item breaks, and is lost forever
        ///     2-4, Character Drops the Primary Hand Item back into the item pool
        ///     5-6, Character drops a random equipped item back into the item pool
        ///     7-10, Nothing bad happens, luck was with the attacker
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool CharacterCriticalMiss(CharacterModel character)
        {
            // roll dice to determine event
            var d10 = DiceHelper.RollDice(1, 10);

            // Primary Hand Item breaks
            if (d10 == 1)
            {
                character.RemoveItem(ItemLocationEnum.PrimaryHand);
                BattleMessages.CriticalMissMessage = "Critical miss! Item in primary hand broke!";
                return true;
            }

            // Character Drops the Primary Hand Item back into the item pool
            if (d10 >= 2 && d10 <= 4)
            {
                var item = character.RemoveItem(ItemLocationEnum.PrimaryHand);
                if (item != null)
                {
                    BattleMessages.CriticalMissMessage = "Critical miss! " + character.Name
                        + " dropped " + item.Name + " in item pool!";
                    ItemPool.Add(item);
                    return true;
                }
            }

            // Character drops a random equipped item back into the item pool
            if (d10 >= 5 && d10 <= 6)
            {
                // check where character has items equipped
                var equipped = new List<ItemLocationEnum>();

                var item = character.GetItemByLocation(ItemLocationEnum.Head);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.Head);
                }

                item = character.GetItemByLocation(ItemLocationEnum.Necklass);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.Necklass);
                }

                item = character.GetItemByLocation(ItemLocationEnum.Feet);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.Feet);
                }

                item = character.GetItemByLocation(ItemLocationEnum.PrimaryHand);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.PrimaryHand);
                }

                item = character.GetItemByLocation(ItemLocationEnum.OffHand);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.OffHand);
                }

                item = character.GetItemByLocation(ItemLocationEnum.RightFinger);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.RightFinger);
                }

                item = character.GetItemByLocation(ItemLocationEnum.LeftFinger);
                if (item != null)
                {
                    equipped.Add(ItemLocationEnum.LeftFinger);
                }

                // no items equipped
                if (equipped.Count() <= 0)
                {
                    return true;
                }

                var unequip = DiceHelper.RollDice(1, equipped.Count()) - 1;

                // check that dice roll was valid (in case forced rolls are being used)
                if (unequip < 0 || unequip >= equipped.Count())
                {
                    return false;   // did not remove an item
                }

                item = character.RemoveItem(equipped.ElementAt(unequip));
                ItemPool.Add(item);
                BattleMessages.CriticalMissMessage = "Critical miss! " + character.Name
                    + " dropped " + item.Name + " in item pool!";
            }

            return true;
        }

        /// <summary>
        /// Monster experience a critical miss.
        /// Since monsters don't equip items, critical miss is slightly different than characters.
        /// After rolling a critical miss. Roll a 10 sided dice. The following things can happen.
        /// Roll Value 
        ///     1-6, Monster drops an item from one of its pockets.
        ///          If it has no items in any pockets, it drops a random item.
        ///          The dropped item is added to the item pool.
        ///     7-10, Nothing bad happens, luck was with the attacker
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        public bool MonsterCriticalMiss(MonsterModel monster)
        {
            // roll dice to determine event
            var d10 = DiceHelper.RollDice(1, 10);

            // Drop an item
            if (d10 <= 6)
            {
                // randomly check a monster's item pocket
                var d3 = DiceHelper.RollDice(1, 3);

                if (d3 == 1)
                {
                    var item = ItemIndexViewModel.Instance.GetItem(monster.ItemPocket1);
                    monster.ItemPocket1 = string.Empty;
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetRandomItem();
                    }
                    ItemPool.Add(item);
                    BattleMessages.CriticalMissMessage = "Critical miss! " + monster.Name
                        + " dropped " + item.Name + " in item pool!";
                }

                if (d3 == 2)
                {
                    var item = ItemIndexViewModel.Instance.GetItem(monster.ItemPocket2);
                    monster.ItemPocket2 = string.Empty;
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetRandomItem();
                    }
                    ItemPool.Add(item);
                    BattleMessages.CriticalMissMessage = "Critical miss! " + monster.Name
                        + " dropped " + item.Name + " in item pool!";
                }

                if (d3 == 3)
                {
                    var item = ItemIndexViewModel.Instance.GetItem(monster.ItemPocket3);
                    monster.ItemPocket3 = string.Empty;
                    if (item == null)
                    {
                        item = ItemIndexViewModel.Instance.GetRandomItem();
                    }
                    ItemPool.Add(item);
                    BattleMessages.CriticalMissMessage = "Critical miss! " + monster.Name
                        + " dropped " + item.Name + " in item pool!";
                }
            }

            return true;
        }

    }
}
