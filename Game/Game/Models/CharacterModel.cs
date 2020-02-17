using System;
using System.Collections.Generic;
using System.Text;
using Game.Services;

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

        // The max health level of the character
        public int MaxHealth { get; set; } = 1;

        // The item the character is currently wearing on their head
        public ItemModel HeadItem { get; set; }

        // The item the character is currently wearing on their body
        public ItemModel BodyItem { get; set; }

        // The item the character is currently wearing on their feet
        public ItemModel FeetItem { get; set; }

        // The item the character is currently holding in their primary hand
        public ItemModel PrimaryHandItem { get; set; }

        // The item the character is currently holding in their off hand
        public ItemModel OffHandItem { get; set; }

        // The item the character is currently wearing on their right finger
        // (only one finger on the right hand may equip an item)
        public ItemModel RightFingerItem { get; set; }

        // The item the character is currently wearing on their left finger
        // (only one finger on the left hand may equip an item)
        public ItemModel LeftFingerItem { get; set; }

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
                            "Max Health: " + MaxHealth + ", " +

                            // equipped items
                            "Head: " + HeadItem + ", " +
                            "Body: " + BodyItem + ", " +
                            "Feet: " + FeetItem + ", " +
                            "Primary Hand: " + PrimaryHandItem + ", " +
                            "Off Hand: " + OffHandItem + ", " +
                            "Right Finger: " + RightFingerItem + ", " +
                            "Left Finger: " + LeftFingerItem;

            return myReturn.Trim();
        }

    }
}
