using Game.Models;
using Game.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{

    /// <summary>
    /// DefaultItemHelper is a static class that helps create Items with the game's default base stats.
    /// </summary>
    public static class DefaultItemHelper
    {

        /// <summary>
        /// Returns default Earplugs ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultEarplugs()
        {
            return new ItemModel
            {
                Name = "Earplugs",
                Description = "Squishy foam earplugs that help block noise",
                ImageURI = "item_earplugs.png",
                Range = 0,
                Damage = 0,
                Value = 2,
                Location = ItemLocationEnum.Head,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default Earmuffs ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultEarmuffs()
        {
            return new ItemModel
            {
                Name = "Earmuffs",
                Description = "Cute, fluffy earmuffs that block a little noise",
                ImageURI = "item_earmuffs.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.Head,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default Noise Cancelling Headphones ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultNoiseCancelingHeadphones()
        {
            return new ItemModel
            {
                Name = "Noise-Canceling Headphones",
                Description = "Powerful noise-canceling headphones that block noise",
                ImageURI = "item_headphones.png",
                Range = 0,
                Damage = 0,
                Value = 3,
                Location = ItemLocationEnum.Head,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default Microphone ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultMicrophone()
        {
            return new ItemModel
            {
                Name = "Microphone",
                Description = "A battery-powered microphone that amplifies the band’s music",
                ImageURI = "item_microphone.png",
                Range = 0,
                Damage = 0,
                Value = 2,
                Location = ItemLocationEnum.OffHand,
                Attribute = AttributeEnum.Attack
            };
        }

        /// <summary>
        /// Returns default Coffee ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultCoffee()
        {
            return new ItemModel
            {
                Name = "Coffee",
                Description = "A slightly bitter caffeinated beverage",
                ImageURI = "item_coffee.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.OffHand,
                Attribute = AttributeEnum.Speed
            };
        }

        /// <summary>
        /// Returns default EnergyDrink ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultEnergyDrink()
        {
            return new ItemModel
            {
                Name = "Energy Drink",
                Description = "A carbonated caffeinated beverage with a weird aftertaste",
                ImageURI = "item_energy_drink.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.OffHand,
                Attribute = AttributeEnum.Speed
            };
        }

        /// <summary>
        /// Returns default Metronome ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultMetronome()
        {
            return new ItemModel
            {
                Name = "Metronome",
                Description = "A handheld metronome that keeps the band’s beat",
                ImageURI = "item_metronome.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.OffHand,
                Attribute = AttributeEnum.Defense
            };
        }
    } 
}
