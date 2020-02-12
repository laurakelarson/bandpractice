using System;
using System.Collections.Generic;
using System.Text;
using Game.Services;

namespace Game.Models
{
    /// <summary>
    /// Character for the Game
    /// </summary>
    public class CharacterModel : BaseModel<CharacterModel>
    {
        // The type of the character
        public CharacterTypeEnum Type { get; set; } 

        // Indicates whether the character is unlocked for the player to use or not
        public bool Unlocked { get; set; } = false;

        // Status indicating whether the character is currently alive or not
        public bool Alive { get; set; } = true;

        // The level of the character
        public int Level { get; set; } = 1;

        // Amount of total experience the character has accumulated
        public int TotalExperience { get; set; } = 0;

        // The speed of the character
        public int Speed { get; set; } = 0;

        // The character's defense level
        public int Defense { get; set; } = 0;

        // The character's attack level
        public int Attack { get; set; } = 0;

        // The current health level of the character
        public int CurrentHealth { get; set; } = 1;

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
            ImageURI = CharacterService.DefaultImageURI;

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
                case CharacterTypeEnum.Keyboardist:
                    DefaultKeyboardist();
                    break;
                case CharacterTypeEnum.Drummer:
                    DefaultDrummer();
                    break;
                case CharacterTypeEnum.Guitarist:
                    DefaultGuitarist();
                    break;
                case CharacterTypeEnum.LeadVocalist:
                    DefaultLeadVocalist();
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
            ImageURI = "tambourine.png";
            IconURI = "tambourine_icon.png";
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
            ImageURI = "bassist.png";
            IconURI = "bassist_icon.png";
            Level = 2;
            Alive = true;
            TotalExperience = 300;
            Attack = 1;
            Defense = 1;
            Speed = 1;
            MaxHealth = CurrentHealth = 30;
        }

        /// <summary>
        /// Default base stats for Keyboardist
        /// </summary>
        private void DefaultKeyboardist()
        {
            Name = "Keyboardist";
            Type = CharacterTypeEnum.Keyboardist;
            ImageURI = "keyboardist.png";
            IconURI = "keyboardist_icon.png";
            Level = 5;
            Alive = true;
            TotalExperience = 6500;
            Attack = 2;
            Defense = 4;
            Speed = 2;
            MaxHealth = CurrentHealth = 50;
        }

        /// <summary>
        /// Default base stats for Drummer
        /// </summary>
        private void DefaultDrummer()
        {
            Name = "Drummer";
            Type = CharacterTypeEnum.Drummer;
            ImageURI = "drummer.png";
            IconURI = "drummer_icon.png";
            Level = 8;
            Alive = true;
            TotalExperience = 34000;
            Attack = 3;
            Defense = 5;
            Speed = 2;
            MaxHealth = CurrentHealth = 80;
        }

        /// <summary>
        /// Default base stats for Guitarist
        /// </summary>
        private void DefaultGuitarist()
        {
            Name = "Guitarist";
            Type = CharacterTypeEnum.Guitarist;
            ImageURI = "guitarist.png";
            IconURI = "guitarist_icon.png";
            Level = 12;
            Alive = true;
            TotalExperience = 100000;
            Attack = 4;
            Defense = 6;
            Speed = 3;
            MaxHealth = CurrentHealth = 120;
        }

        /// <summary>
        /// Default base stats for Lead Vocalist
        /// </summary>
        private void DefaultLeadVocalist()
        {
            Name = "Lead Vocalist";
            Type = CharacterTypeEnum.LeadVocalist;
            ImageURI = "vocalist.png";
            IconURI = "vocalist_icon.png";
            Level = 16;
            Alive = true;
            TotalExperience = 195000;
            Attack = 5;
            Defense = 8;
            Speed = 4;
            MaxHealth = CurrentHealth = 120;
        }
    }
}
