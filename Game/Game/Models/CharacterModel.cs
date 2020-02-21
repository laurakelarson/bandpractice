using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;
using Game.Services;
using Game.ViewModels;
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

            // if current experience below new level threshold, 
            // update experience level to that threshold 
            if (TotalExperience < LevelAttributes.Experience)
            {
                TotalExperience = LevelAttributes.Experience; 
            }

            // calculate new max health 
            var maxHealth = DiceHelper.RollDice(10, 10);

            // if new max health less than current, 
            // set to current
            if (maxHealth < MaxHealth)
            {
                maxHealth = MaxHealth; 
            }

            CurrentHealth += (maxHealth - MaxHealth);
            MaxHealth = maxHealth; 

            // attributes successfully set 
            return true;
        }

        /// <summary>
        /// Add experience to character. Levels up character 
        /// if experience crosses threshold for next level. 
        /// </summary>
        /// <param name="experience"></param>
        /// <returns></returns>
        public bool AddExperience(int experience)
        {
            // add to total experience 
            TotalExperience += experience;

            // can't level up beyond 20 so exit method 
            if (Level > 20)
            {
                return true;
            }

            // obtain experience threshold for next level 
            var NextLevelDetails = LevelAttributesHelper.Instance.LevelAttributesList[Level + 1];
            var nextLevelExperience = NextLevelDetails.Experience;

            // level up character if experience meets threshold
            if (TotalExperience >= nextLevelExperience)
            {
                LevelUp();
            }

            return true;
        }

        /// <summary>
        /// Determines how much damage the character will 
        /// inflict. 
        /// </summary>
        /// <returns></returns>
        public int RollDamageDice()
        {
            // dice roll of weapon damage value + 1/4 level damange rounded up 
            var weaponDamage = ItemIndexViewModel.Instance.GetItem(PrimaryHandItem).Damage;
            return (int)Math.Ceiling(0.25 * Level) + DiceHelper.RollDice(1, weaponDamage);
        }

        #region Equipped Items

        /// <summary>
        /// Removes all the character's equipped items and returns them in a List.
        /// If an item has been deleted from the database, it is not included in the returned List.
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> DropAllItems()
        {
            List<ItemModel> itemDrop = new List<ItemModel>();

            ItemModel item = RemoveItem(ItemLocationEnum.Head);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            item = RemoveItem(ItemLocationEnum.Necklass);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            item = RemoveItem(ItemLocationEnum.Feet);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            item = RemoveItem(ItemLocationEnum.PrimaryHand);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            item = RemoveItem(ItemLocationEnum.OffHand);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            item = RemoveItem(ItemLocationEnum.RightFinger);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            item = RemoveItem(ItemLocationEnum.LeftFinger);
            if (item != null)
            {
                itemDrop.Add(item);
            }

            return itemDrop;
        }

        /// <summary>
        /// Removes and returns the item from the specified location.
        /// Returns null if there is no item in that location, or if the item has been deleted
        /// from the database.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public ItemModel RemoveItem(ItemLocationEnum location)
        {
            ItemModel item = GetItemByLocation(location);
            switch (location)
            {
                case ItemLocationEnum.Head:
                    HeadItem = null;
                    return item;
                case ItemLocationEnum.Necklass:
                    BodyItem = null;
                    return item;
                case ItemLocationEnum.Feet:
                    FeetItem = null;
                    return item;
                case ItemLocationEnum.PrimaryHand:
                    PrimaryHandItem = null;
                    return item;
                case ItemLocationEnum.OffHand:
                    OffHandItem = null;
                    return item;
                case ItemLocationEnum.RightFinger:
                    RightFingerItem = null;
                    return item;
                case ItemLocationEnum.LeftFinger:
                    LeftFingerItem = null;
                    return item;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the item from the specified location.
        /// Returns null if there is no item in that location, or if the item has been deleted
        /// from the database.
        /// </summary>
        public ItemModel GetItemByLocation(ItemLocationEnum location)
        {
            switch (location)
            {
                case ItemLocationEnum.Head:
                    return ItemIndexViewModel.Instance.GetItem(HeadItem);
                case ItemLocationEnum.Necklass:
                    return ItemIndexViewModel.Instance.GetItem(BodyItem);
                case ItemLocationEnum.Feet:
                    return ItemIndexViewModel.Instance.GetItem(FeetItem);
                case ItemLocationEnum.PrimaryHand:
                    return ItemIndexViewModel.Instance.GetItem(PrimaryHandItem);
                case ItemLocationEnum.OffHand:
                    return ItemIndexViewModel.Instance.GetItem(OffHandItem);
                case ItemLocationEnum.RightFinger:
                    return ItemIndexViewModel.Instance.GetItem(RightFingerItem);
                case ItemLocationEnum.LeftFinger:
                    return ItemIndexViewModel.Instance.GetItem(LeftFingerItem);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Adds an item to the specified location (item ID saved as foreign key).
        /// If there is already an item in that location, overwrites the old one.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="item"></param>
        public ItemModel AddItem(ItemLocationEnum location, ItemModel item)
        {
            ItemModel swap = RemoveItem(location);
            switch (location)
            {
                case ItemLocationEnum.Head:
                    HeadItem = item.Id;
                    return swap;
                case ItemLocationEnum.Necklass:
                    BodyItem = item.Id;
                    return swap;
                case ItemLocationEnum.Feet:
                    FeetItem = item.Id;
                    return swap;
                case ItemLocationEnum.PrimaryHand:
                    PrimaryHandItem = item.Id;
                    return swap;
                case ItemLocationEnum.OffHand:
                    OffHandItem = item.Id;
                    return swap;
                case ItemLocationEnum.RightFinger:
                    RightFingerItem = item.Id;
                    return swap;
                case ItemLocationEnum.LeftFinger:
                    LeftFingerItem = item.Id;
                    return swap;
                default:
                    return swap;
            }
        }


        /// <summary>
        /// Returns the bonus value of the specified attribute based on the held items.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public int GetItemBonus(AttributeEnum attribute)
        {
            int bonus = 0;
            ItemModel item;

            item = GetItemByLocation(ItemLocationEnum.Head);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }

            item = GetItemByLocation(ItemLocationEnum.Necklass);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }


            item = GetItemByLocation(ItemLocationEnum.Feet);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }

            item = GetItemByLocation(ItemLocationEnum.PrimaryHand);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }

            item = GetItemByLocation(ItemLocationEnum.OffHand);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }

            item = GetItemByLocation(ItemLocationEnum.RightFinger);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }

            item = GetItemByLocation(ItemLocationEnum.LeftFinger);
            if (item != null)
            {
                if (item.Attribute == attribute)
                {
                    bonus += item.Value;
                }
            }

            return bonus;
        }

        #endregion Equipped Items
    }
}
