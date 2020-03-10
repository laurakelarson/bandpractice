using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Game.Helpers;
using Game.Models;
using Game.Models.Enum;
using Game.ViewModels;

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

            // Select first in the list

            // TODO: Teams, You need to implement your own Logic can not use mine.

            var Defender = EntityList
                   .Where(m => m.Alive && m.EntityType == EntityTypeEnum.Character)
                   .OrderBy(m => m.ListOrder).FirstOrDefault();

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

            // Select first one to hit in the list for now...
            // Attack the Weakness (lowest HP) MonsterModel first

            // TODO: Teams, You need to implement your own Logic can not use mine.

            var Defender = EntityList
                   .Where(m => m.Alive && m.EntityType == EntityTypeEnum.Monster)
                   .OrderBy(m => m.CurrentHealth).FirstOrDefault();

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
            BattleMessages.AttackStatus = " attacks ";
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
            BattleMessages.ExperienceEarned = "Earned " + experience + " points";
            Debug.WriteLine(BattleMessages.ExperienceEarned);

            // did character level up?
            if (level != character.Level)
            {
                BattleMessages.LevelUpMessage = entity.Name + " is now Level " + entity.Level + " With Health Max of " + entity.MaxHealth;
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
                    if(!character.Alive && EntityList.First(a => a.Id == Target.Id).MiracleMax)
                    {
                        character.CurrentHealth = character.MaxHealth; // it's a miracle!
                        BattleMessages.TurnMessageSpecial = character.Name + " has been miraculously revived by Miracle Max!\nSee Miracle Max for all of your miraculous needs~";
                        Debug.WriteLine(BattleMessages.TurnMessageSpecial);
                        EntityList.First(a => a.Id == Target.Id).MiracleMax = false;
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
            BattleMessages.TurnMessageSpecial = target.Name + " dies";

            // Remove target from list...

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
            // Drop Items to ItemModel Pool
            var myItemList = RemoveItems(target);

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....
            myItemList.AddRange(GetRandomMonsterItemDrops(Score.RoundCount));

            var itemsForPool = new List<ItemModel>();

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                if (ItemModel != null)
                {
                    Score.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                    BattleMessages.TurnMessageSpecial += "\n" + ItemModel.Name + " dropped";

                    itemsForPool.Add(ItemModel);
                }
            }

            Debug.WriteLine(BattleMessages.TurnMessageSpecial);

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
                BattleMessages.AttackStatus = " misses ";
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
        public List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // TODO: Teams, You need to implement your own modification to the Logic cannot use mine as is.

            // number of random drops is a dice roll based on the round #
            var NumberToDrop = DiceHelper.RollDice(1, round);

            var myList = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                // add a random item from the data source
                myList.Add(ItemIndexViewModel.Instance.GetRandomItem());
            }
            return myList;
        }

    }
}
