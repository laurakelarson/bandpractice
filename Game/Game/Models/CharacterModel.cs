using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// Character for the Game
    /// </summary>
    class CharacterModel : BaseModel<ItemModel>
    {
        // The type of the character
        public CharacterTypeEnum Type { get; set; }

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


    }
}
