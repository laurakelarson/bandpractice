﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Character for the Game
    /// </summary>
    public class CharacterModel : BaseModel<CharacterModel>
    {
        // The type of the character
        public CharacterTypeEnum Type { get; set; } = CharacterTypeEnum.Default;

        // Indicates whether the character is unlocked for the player to use or not
        public bool Unlocked { get; set; } = false;

        // Status indicating whether the character is currently alive or not
        public bool Alive { get; set; } = true;

        // The level of the character
        public int Level { get; set; }

        // Amount of total experience the character has accumulated
        public int TotalExperience { get; set; }

        // The speed of the character
        public int Speed { get; set; }

        // The character's defense level
        public int Defense { get; set; }

        // The character's attack level
        public int Attack { get; set; }

        // The current health level of the character
        public int CurrentHealth { get; set; }

        // The max health level of the character
        public int MaxHealth { get; set; }

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

        /// <summary>
        ///  Default constructor for the character
        /// </summary>
        public CharacterModel()
        {
            //TODO add default image

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
        /// Constructor that takes in a CharacterTypeEnum to create the default base version of that type
        /// </summary>
        /// <param name="type"></param>
        public CharacterModel(CharacterTypeEnum type)
        {
            switch (type)
            {
                case CharacterTypeEnum.Bassist:
                    DefaultBassist();
                    break;
                default:
                    DefaultTambourine();
                    break;
            }
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
        public string FormatOutput()
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

        /// <summary>
        /// Default base stats for Tambourine Player
        /// </summary>
        private void DefaultTambourine()
        {
            Name = "Tambourine Player";
            Type = CharacterTypeEnum.TambourinePlayer;
            ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png";
            Alive = true;
            Level = 1;
            TotalExperience = 0;
            Attack = 1;
            Defense = 1;
            Speed = 1;
            MaxHealth = CurrentHealth = 20;
        }

        /// <summary>
        /// Default base stats for Bassist
        /// </summary>
        private void DefaultBassist()
        {
            Name = "Bassist";
            Type = CharacterTypeEnum.Bassist;
            ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png";
            Level = 2;
            Alive = true;
            TotalExperience = 300;
            Attack = 1;
            Defense = 1;
            Speed = 1;
            MaxHealth = CurrentHealth = 30;
        }
    }
}
