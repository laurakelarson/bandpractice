using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;
using Game.Services;
using SQLite;

namespace Game.Models
{
    /// <summary>
    /// Character for the Game
    /// </summary>
    public class CharacterModel : EntityModel<CharacterModel>
    {
        // The type of the character
        public CharacterTypeEnum Type { get; set; } 

        // Indicates whether the character is unlocked for the player to use or not
        public bool Unlocked { get; set; } = false;

        // Amount of total experience the character has accumulated
        public int TotalExperience { get; set; } = 0;

        // The item the character is currently wearing on their head
        // stored as the item guid/id foreign key
        public string HeadItem { get; set; } = null;

        // The item the character is currently wearing on their body
        // stored as the item guid/id foreign key
        public string BodyItem { get; set; } = null;

        // The item the character is currently wearing on their feet
        // stored as the item guid/id foreign key
        public string FeetItem { get; set; } = null;

        // The item the character is currently holding in their primary hand
        // stored as the item guid/id foreign key
        public string PrimaryHandItem { get; set; } = null;

        // The item the character is currently holding in their off hand
        // stored as the item guid/id foreign key
        public string OffHandItem { get; set; } = null;

        // The item the character is currently wearing on their right finger
        // (only one finger on the right hand may equip an item)
        // stored as the item guid/id foreign key
        public string RightFingerItem { get; set; } = null;

        // The item the character is currently wearing on their left finger
        // (only one finger on the left hand may equip an item)
        // stored as the item guid/id foreign key
        public string LeftFingerItem { get; set; } = null;

        // The character's icon image
        public string IconURI { get; set; } = "default_icon.png";

        /// <summary>
        ///  Default constructor for the character
        /// </summary>
        public CharacterModel()
        {
            ImageURI = EntityService.DefaultCharacterImageURI;

        }

        /// <summary>
        /// Copy constructor - creates a new character model based on the input
        /// </summary>
        /// <param name="data">character to copy</param>
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="newData">The new data</param>
        public override void Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            IconURI = newData.IconURI;
            Type = newData.Type;
            Unlocked = newData.Unlocked;
            Alive = newData.Alive;
            Level = newData.Level;
            TotalExperience = newData.TotalExperience;
            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;
            HeadItem = newData.HeadItem;
            BodyItem = newData.BodyItem;
            FeetItem = newData.FeetItem;
            PrimaryHandItem = newData.PrimaryHandItem;
            OffHandItem = newData.OffHandItem;
            RightFingerItem = newData.RightFingerItem;
            LeftFingerItem = newData.LeftFingerItem;
        }

        /* TODO: Add DropAllItems() */
        /* TODO: Add ItemModel RemoveItem(ItemLocationEnum location) */
        /* TODO: Add ItemModel GetItemByLocation(ItemLocationEnum location) */
        /* TODO: Add void AddItem(ItemLocationEnum location, ItemModel item) */
        /* TODO: Add Attribute GetItemBonus(ItemLocationEnum location) */

        /// <summary>
        /// Helper to combine the attributes into a single line, to make it easier to display the character as a string
        /// </summary>
        /// <returns>string representing the character</returns>
        public override string FormatOutput()
        {
            var myReturn = Name + " , " +
                            Description + ", " +
                            "Type: " + Type + ", " +
                            "Unlocked: " + Unlocked + ", " +
                            "Alive: " + Alive + ", " +
                            "Level: " + Level + ", " +
                            "Experience: " + TotalExperience + ", " +
                            "Speed: " + Speed + ", " +
                            "Defense: " + Defense + ", " +
                            "Attack: " + Attack + ", " +
                            "Current Health: " + CurrentHealth + ", " +
                            "Max Health: " + MaxHealth + ", ";

            return myReturn.Trim();
        }

        /// <summary>
        /// Attempts to level up the character. If the 
        /// character is level 20, returns false. Returns
        /// true of character is level 1-19. 
        /// </summary>
        /// <returns></returns>
        public bool LevelUp()
        {
            return LevelUpToValue(Level + 1); 
        }

        /// <summary>
        /// Attempts to level the character up to the value 
        /// indicated. Fails if value is over 20. 
        /// </summary>
        /// <param name="levelValue"></param>
        /// <returns></returns>
        public bool LevelUpToValue(int levelValue)
        {
            // Can't level up beyond level 20 
            if (levelValue > 20)
            {
                return false;
            }

            // Obtain attributes of level == value
            var LevelAttributes = LevelAttributesHelper.Instance.LevelAttributesList[levelValue];

            // set Level and attributes
            Level = LevelAttributes.Level;
            Attack = LevelAttributes.Attack;
            Defense = LevelAttributes.Defense;
            Speed = LevelAttributes.Speed;

            // attributes successfully set 
            return true;
        }
    }
}
