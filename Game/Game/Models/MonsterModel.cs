using System;
using System.Collections.Generic;
using Game.Helpers;
using Game.Services;

namespace Game.Models
{
    /// <summary>
    /// Monster for the Game
    /// 
    /// The Monsters that the characters battle in the game.
    /// The Monsters are stored in the DB, and during game time a random Monster is selected.
    /// The system supports CRUDi operations on the Monsters
    /// When in test mode, a test set of Monsters is loaded.
    /// When in run mode the Monsters are loaded from the database.
    /// 
    /// </summary>
    public class MonsterModel : EntityModel<MonsterModel>
    {

        // Amount of experience the monster will give on defeat
        public int ExperienceGiven { get; set; } = 0;

        // The range of the monster to attack. Attacks within range will be successful
        public int Range { get; set; } = 0;

        // Flag indicating whether a Monster is a boss or not
        public bool Boss { get; set; } = false;

        // The items that may be dropped by this monster on defeat. May drop none, some, or all of the items in the array
        public List<ItemModel> ItemsDropped { get; set; } = new List<ItemModel>();

        // The items that will always be dropped by this monster on defeat
        public List<ItemModel> UniqueDrops { get; set; } = new List<ItemModel>();

        /// <summary>
        /// Default MonsterModel
        /// Establish the Default Image Path
        /// </summary>
        public MonsterModel()
        {
            ImageURI = MonsterService.DefaultImageURI;
        }

        /// <summary>
        /// Constructor to create an Monster based on what is passed in
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="newData">The new data</param>
        public override void Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            Alive = newData.Alive;
            Level = newData.Level;
            ExperienceGiven = newData.ExperienceGiven;
            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;
            CurrentHealth = newData.CurrentHealth;
            Range = newData.Range;

            // determine number of items dropped before adding items
            // to prevent out of memory error 
            int itemsDroppedCount = newData.ItemsDropped.Count; 
            for (int i = 0; i < itemsDroppedCount; i++)
            {
                ItemsDropped.Add(new ItemModel(newData.ItemsDropped[i]));
            }

            // determine number of unique drops before adding items 
            // to prevent out of memory error 
            int uniqueItemsDroppedCount = newData.UniqueDrops.Count; 
            for (int i = 0; i < uniqueItemsDroppedCount; i++)
            {
                UniqueDrops.Add(new ItemModel(newData.UniqueDrops[i]));
            }
        }

        /// <summary>
        /// Method to inflict damage to Monster object
        /// </summary>
        public bool TakeDamage(int damage)
        {
            if (damage > 0)
            {
                CurrentHealth -= damage;
                if (CurrentHealth < 0)
                {
                    Alive = false;
                    // drop items
                }
                return true;
            }
            return false;
        }

        // For each character/monster turn: There is a roll of a 20-sided dice: 
        // 1 is auto-miss, 20 is auto-hit. For all other rolls, the success of the 
        // turn entity’s hit is calculated by the following formula: 
        // (dice roll + Entity Level + Attack Modifiers) > (Target Defense attribute + Target level). 
        // If true, the hit succeeds; if false, it’s a miss and the turn is over for that entity.

        // Damage is determined by the following formula: dice roll + Weapon Damage + Level Damage.
        // Level damage is equal to ¼ of the entity’s level rounded up to the nearest whole integer.
        // Weapon damage is randomly found within the damage range of the weapon held by the entity 
        // (if a weapon has a damage attribute of 10, the weapon damage will be randomly determined in the range 1-10).
        
        /// <summary>
        /// Method to calculate the damage that will be inflicted by the entity
        /// </summary>
        /// <returns></returns>
        public int GetAttackValue()
        {
            var roll = DiceHelper.RollDice(1, 20);
            var level_damage = Math.Ceiling((double)Level / 4);
            return roll + (int)level_damage;
        }


        // Helper to combine the attributes into a single line, to make it easier to display the Monster as a string
        public string FormatOutput()
        {
            var myReturn = Name + " , " +
                            "Speed : " + Speed + " , " +
                            "Defense : " + Defense + " , " +
                            "Attack : " + Attack + " , " +
                            "Range : " + Range;

            return myReturn.Trim();
        }
    }
}