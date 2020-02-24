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
    /// Turn Engine for the game.
    /// Manages an entity (character or monster) taking a turn.
    /// </summary>
    public class TurnEngine : BaseEngine
    {


        /// <summary>
        /// The current attacker takes their turn.
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool TakeTurn(BattleEntityModel attacker)
        {
            var result = Attack(attacker);

            Score.TurnCount++;

            return result;
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
        /// <param name="attacker"></param>
        /// <returns></returns>
        public bool Attack(BattleEntityModel attacker)
        {
            //// For Attack, Choose Who
            var target = AttackChoice(attacker);

            if (target == null)
            {
                return false;
            }

            // Do Attack
            TurnAsAttack(attacker, target);

            CurrentAttacker = new BattleEntityModel(attacker);
            CurrentDefender = new BattleEntityModel(target);

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

            // Select first in the list
            var defender = CharacterList
                .Where(m => m.Alive).FirstOrDefault();

            return new BattleEntityModel(defender);
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

            // Select first one to hit in the list for now...
            // Attack the Weakness (lowest HP) MonsterModel first 
            var defender = MonsterList
                .Where(m => m.Alive)
                .OrderBy(m => m.CurrentHealth).FirstOrDefault();

            return new BattleEntityModel(defender);
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

            BattleMessages.TurnMessage = string.Empty;
            BattleMessages.TurnMessageSpecial = string.Empty;
            BattleMessages.AttackStatus = string.Empty;

            BattleMessages.PlayerType = EntityTypeEnum.Monster;

            //var AttackScore = attacker.Level + attacker.GetAttack();
            //var DefenseScore = target.GetDefense() + target.Level;
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
                return true;
            }

            // It's a Hit
            if (BattleMessages.HitStatus == HitStatusEnum.Hit)
            {
                //Calculate Damage
                BattleMessages.DamageAmount = GetDamage(attacker);
                //BattleMessages.DamageAmount = attacker.GetDamageRollValue();

                target.TakeDamage(BattleMessages.DamageAmount);
            }

            BattleMessages.CurrentHealth = target.CurrentHealth;
            BattleMessages.TurnMessageSpecial = BattleMessages.GetCurrentHealthMessage();

            RemoveIfDead(target);

            BattleMessages.TurnMessage = attacker.Name + BattleMessages.AttackStatus + target.Name + BattleMessages.TurnMessageSpecial;
            Debug.WriteLine(BattleMessages.TurnMessage);

            return true;
        }

        /// <summary>
        /// Gets the attack value (including any stat boosts) of the character or monster
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int GetAttack(BattleEntityModel attacker)
        {
            switch(attacker.EntityType)
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
            return 0;
        }

        /// <summary>
        /// Gets the roll of the damage value (including any stat boosts) of the character or monster
        /// </summary>
        /// <param name="attacker"></param>
        /// <returns></returns>
        public int GetDamage(BattleEntityModel attacker)
        {
            return 0;
        }


        /// <summary>
        /// If Dead process Targed Died
        /// </summary>
        /// <param name="Target"></param>
        public bool RemoveIfDead(BattleEntityModel Target)
        {
            // Check for alive
            if (Target.Alive == false)
            {
                //TargedDied(Target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Process an entity's death.
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public bool TargedDied(BattleEntityModel target)
        {
            // Mark Status in output
            //BattleMessagesModel.TurnMessageSpecial = " and causes death";

            //// Remove target from list...

            //// Using a switch so in the future additional PlayerTypes can be added (Boss...)
            //switch (Target.PlayerType)
            //{
            //    case PlayerTypeEnum.Character:
            //        CharacterList.Remove(Target);

            //        // Add the MonsterModel to the killed list
            //        BattleScore.CharacterAtDeathList += Target.FormatOutput() + "\n";

            //        DropItems(Target);

            //        return true;

            //    case PlayerTypeEnum.Monster:
            //    default:
            //        MonsterList.Remove(Target);

            //        // Add one to the monsters killed count...
            //        BattleScore.MonsterSlainNumber++;

            //        // Add the MonsterModel to the killed list
            //        BattleScore.MonstersKilledList += Target.FormatOutput() + "\n";

            //        DropItems(Target);

            return true;
        }

        /// <summary>
        /// Have the target drop all their items
        /// </summary>
        /// <param name="Target"></param>
        /// <returns></returns>
        public int DropItems(BattleEntityModel Target)
        {
            // Drop Items to ItemModel Pool
            //var myItemList = Target.DropAllItems();

            //// I feel generous, even when characters die, random drops happen :-)
            //// If Random drops are enabled, then add some....
            //myItemList.AddRange(GetRandomMonsterItemDrops(BattleScore.RoundCount));

            //// Add to ScoreModel
            //foreach (var ItemModel in myItemList)
            //{
            //    BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
            //    BattleMessagesModel.TurnMessageSpecial += " ItemModel " + ItemModel.Name + " dropped";
            //}

            //ItemPool.AddRange(myItemList);

            //return myItemList.Count();

            return 0;
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
                // Force Miss
                //BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                //return BattleMessagesModel.HitStatus;
            }

            if (d20 == 20)
            {
                // Force Hit
                //BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
                //return BattleMessagesModel.HitStatus;
            }

            var ToHitScore = d20 + AttackScore;
            if (ToHitScore < DefenseScore)
            {
                //BattleMessagesModel.AttackStatus = " misses ";
                //// Miss
                //BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                //BattleMessagesModel.DamageAmount = 0;
                //return BattleMessagesModel.HitStatus;
            }

            // Hit
            //BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
            //return BattleMessagesModel.HitStatus;

            return HitStatusEnum.Hit;
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            //TODO You decide how to drop monster items, level, etc.

            var NumberToDrop = DiceHelper.RollDice(1, round);

            var myList = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                myList.Add(new ItemModel());
            }
            return myList;
        }

    }
}
