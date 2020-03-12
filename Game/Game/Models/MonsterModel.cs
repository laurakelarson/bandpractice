using System;
using System.Collections.Generic;
using Game.Helpers;
using Game.Services;
using Game.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;

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
        public int ExperienceGiven { get; set; }

        // Flag indicating whether a Monster is a boss or not
        public bool Boss { get; set; } = false;

        // Item slot for one item that Monster is holding
        public string ItemPocket1 { get; set; } = string.Empty;

        // Item slot for one item that Monster is holding
        public string ItemPocket2 { get; set; } = string.Empty;

        // Item slot for one item that Monster is holding
        public string ItemPocket3 { get; set; } = string.Empty;

        /// <summary>
        /// Default MonsterModel
        /// Establish the Default Image Path
        /// </summary>
        public MonsterModel()
        {
            ImageURI = EntityService.DefaultMonsterImageURI;
            this.ChangeLevel(1);
        }

        /// <summary>
        /// Default MonsterModel
        /// Establish the Default Image Path
        /// </summary>
        public MonsterModel(MonsterTypeEnum type)
        {
            var data = DefaultMonsterHelper.DefaultMonster(type);
            Update(data);
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
        public override bool Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return false;
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
            MaxHealth = newData.MaxHealth;
            Range = newData.Range;
            ItemPocket1 = newData.ItemPocket1;
            ItemPocket2 = newData.ItemPocket2;
            ItemPocket3 = newData.ItemPocket3;
                
            return true;
        }

        /// <summary>
        /// Attempts to change the level of the monster to the 
        /// level provided.
        /// </summary>
        /// <param name="Level"></param>
        /// <returns></returns>
        public new bool ChangeLevel(int levelValue)
        {
            // level cannot be less than 1
            if (levelValue < 1)
            {
                return false;
            }

            // level cannot be greater than 20
            if (levelValue > 20)
            {
                return false;
            }

            // obtain attributes of level == value
            var NewLevelAttributes = LevelAttributesHelper.Instance.LevelAttributesList[levelValue];

            // set Level and attributes
            Level = NewLevelAttributes.Level;
            Attack = NewLevelAttributes.Attack;
            Defense = NewLevelAttributes.Defense;
            Speed = NewLevelAttributes.Speed;
            ExperienceGiven = NewLevelAttributes.Experience;
            Range = NewLevelAttributes.Range;

            // calculate new health based on dice roll
            // set CurrentHealth as MaxHealth, since this method is used for scaling monsters up or down (rather than leveling up only)
            MaxHealth = CurrentHealth = DiceHelper.RollDice(levelValue, 10);

            // attributes successfully set 
            return true;
        }

        // Helper to combine the attributes into a single line, to make it easier to display the Monster as a string
        public new string FormatOutput()
        {
            var myReturn = Name + " , " +
                            "Speed : " + Speed + " , " +
                            "Defense : " + Defense + " , " +
                            "Attack : " + Attack + " , " +
                            "Range : " + Range;

            return myReturn.Trim();
        }

        /// <summary>
        /// Determines how much damage the monster will 
        /// inflict. 
        /// </summary>
        /// <returns></returns>
        public int RollDamageDice()
        {
            return (int)Math.Ceiling(0.25 * Level); 
        }

        /// <summary>
        /// Returns attack value of monster for when 
        /// monster attempts to attack character. 
        /// </summary>
        /// <returns></returns>
        public int GetAttackValue()
        {
            return DiceHelper.RollDice(1, 20) + Level; 
        }

        /// <summary>
        /// Returns a list of items dropped by the monster
        /// when monster dies. 
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> DropItems()
        {
            var DropList = new List<ItemModel>();

            // gather three items from item pockets
            DropList.Add(ItemIndexViewModel.Instance.GetItem(ItemPocket1));
            DropList.Add(ItemIndexViewModel.Instance.GetItem(ItemPocket2));
            DropList.Add(ItemIndexViewModel.Instance.GetItem(ItemPocket3));
            
            return DropList; 
        }
    }
}