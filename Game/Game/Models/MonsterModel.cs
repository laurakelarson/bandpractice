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
        public int ExperienceGiven { get; set; } = 75;

        // The range of the monster to attack. Attacks within range will be successful
        public int Range { get; set; } = 1;

        // Flag indicating whether a Monster is a boss or not
        public bool Boss { get; set; } = false;

        // The items that may be dropped by this monster on defeat. May drop none, some, or all of the items
        // List of item IDs stored in string json format
        public string ItemsDropped { get; set; } = string.Empty;

        // The items that will always be dropped by this monster on defeat
        // List of item IDs stored in string json format
        public string UniqueDrops { get; set; } = string.Empty;

        /// <summary>
        /// Default MonsterModel
        /// Establish the Default Image Path
        /// </summary>
        public MonsterModel()
        {
            ImageURI = EntityService.DefaultMonsterImageURI;
            Level = 1;
            Speed = 1;
            Range = 1;
            Defense = 3;
            Attack = 2;
            MaxHealth = 7;
            CurrentHealth = 7;
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
            MaxHealth = newData.MaxHealth;
            Range = newData.Range;
            ItemsDropped = newData.ItemsDropped;
            UniqueDrops = newData.UniqueDrops;
        }

        /// <summary>
        /// Method to Scale Monster to given level
        /// </summary>
        /// <param name="oldLevel"></param>
        /// <param name="newLevel"></param>
        /// <returns></returns>
        public MonsterModel ScaleToLevel(int oldLevel, int newLevel)
        {
            double scale = 1.5;
            double factor = (double)newLevel - oldLevel;

            if (newLevel > oldLevel)
            {
                scale *= factor;
            } else
            {
                scale /= factor;
            }

            if (this.Alive)
            {
                this.ExperienceGiven = (int)Math.Ceiling(this.ExperienceGiven * scale);
                this.Speed = (int)Math.Ceiling(this.Speed * scale);
                this.Attack = (int)Math.Ceiling(this.Attack * scale);
                this.Defense = (int)Math.Ceiling(this.Defense * scale);
                this.Range = (int)Math.Ceiling(this.Range * scale);
                this.MaxHealth = (int)Math.Ceiling(this.MaxHealth * scale);
                this.CurrentHealth = this.MaxHealth;
                this.Level = newLevel;
            }

            return this;
        }

        // Helper to combine the attributes into a single line, to make it easier to display the Monster as a string
        public override string FormatOutput()
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
        /// Returns a list of items dropped by the monster
        /// when monster dies. 
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> DropItems()
        {
            var DropList = new List<ItemModel>();

            // get possible regular item drops 
            var ItemDropIDs = JsonHelper.GetJsonList<string>((JObject)ItemsDropped, "ItemsDropped");

            Random rand = new Random();

            // determine how many items will be dropped by monster 
            // (between 0 and number of items in list)
            var numberItemsDropped = rand.Next(0, ItemDropIDs.Count + 1); 

            // add random items to droplist 
            for (var i = 0; i < numberItemsDropped; i++)
            {
                // select random index of item to add
                var randomIndex = rand.Next(0, ItemDropIDs.Count + 1);
                
                // if item exists, add it to drop list 
                if (ItemIndexViewModel.Instance.GetItem(ItemDropIDs[randomIndex]) != null)
                {
                    DropList.Add(ItemIndexViewModel.Instance.GetItem(ItemDropIDs[randomIndex]));

                    // remove so duplicate item not added to DropList
                    ItemDropIDs.RemoveAt(randomIndex); 
                }
            }

            // get unique item drops 
            var UniqueDropIDs = JsonHelper.GetJsonList<string>((JObject)UniqueDrops, "UniqueDrops");

            // add each id in list to drop list 
            foreach (var id in UniqueDropIDs)
            {
                // do not add item to list if item does not exist 
                if (ItemIndexViewModel.Instance.GetItem(id) != null)
                {
                    DropList.Add(ItemIndexViewModel.Instance.GetItem(id));
                }
            }

            return DropList; 
        }
    }
}