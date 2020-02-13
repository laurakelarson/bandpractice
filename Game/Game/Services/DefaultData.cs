using Game.Helpers;
using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    /// <summary>
    /// DefaultData is a static class that contains helper for loading data of various types.
    /// </summary>
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default ItemModel data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel
                {
                    Name = "Earplugs",
                    Description = "Squishy foam earplugs that help block noise",
                    ImageURI = "item_earplugs.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Earmuffs",
                    Description = "Cute, fluffy earmuffs that block a little noise",
                    ImageURI = "item_earmuffs.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Noise-Canceling Headphones",
                    Description = "Powerful noise-canceling headphones that block noise",
                    ImageURI = "item_headphones.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Microphone",
                    Description = "A battery-powered microphone that amplifies the band’s music",
                    ImageURI = "item_microphone.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },

                new ItemModel
                {
                    Name = "Coffee",
                    Description = "A slightly bitter caffeinated beverage",
                    ImageURI = "item_coffee.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Speed
                },

                new ItemModel
                {
                    Name = "Energy Drink",
                    Description = "A carbonated caffeinated beverage with a weird aftertaste",
                    ImageURI = "item_energy_drink.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Speed
                },

                new ItemModel
                {
                    Name = "Metronome",
                    Description = "A handheld metronome that keeps the band’s beat",
                    ImageURI = "item_metronome.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Tuning Fork",
                    Description = "A tuning fork that helps the band keep its pitch",
                    ImageURI = "item_tuning_fork.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Band T-shirt",
                    Description = "A soft t-shirt featuring the band’s logo",
                    ImageURI = "item_band_shirt.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Band Hoodie",
                    Description = "A comfy hoodie featuring the band’s logo",
                    ImageURI = "item_band_hoodie.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Cool Outfit",
                    Description = "A cool outfit that looks effortlessly hip (like a rock star would wear)",
                    ImageURI = "item_cool_outfit.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense
                },

                new ItemModel
                {
                    Name = "Ring",
                    Description = "A simple, nondescript ring",
                    ImageURI = "item_ring.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Attack
                },

                new ItemModel
                {
                    Name = "Mood Ring",
                    Description = "A ring with a stone that changes color depending on the wearer’s mood",
                    ImageURI = "item_mood_ring.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Attack
                },

                new ItemModel
                {
                    Name = "Temporary Tattoo",
                    Description = "A temporary tattoo of the band’s lyrics written around the wearer’s finger like a ring",
                    ImageURI = "item_temporary_tattoo.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Attack
                },

                new ItemModel
                {
                    Name = "Athletic Socks",
                    Description = "Simple athletic socks",
                    ImageURI = "item_athletic_socks.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },

                new ItemModel
                {
                    Name = "Lucky Socks",
                    Description = "Socks that feature a funky pattern",
                    ImageURI = "item_lucky_socks.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },

                new ItemModel
                {
                    Name = "Comfy Sneakers",
                    Description = "Sneakers that are comfortable to walk and stand in",
                    ImageURI = "item_comfy_sneakers.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed
                },

                new ItemModel
                {
                    Name = "Bunny Slippers",
                    Description = "Fluffy slippers that look like bunnies",
                    ImageURI = "item_bunny_slippers.png",
                    Range = 0,
                    Damage = 0,
                    Value = 2,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed
                }

            };



            return datalist;
        }

        /// <summary>
        /// Loads the default ScoreModel data
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load the default Character data
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var datalist = new List<CharacterModel>()
            {
                DataHelper.DefaultTambourine(),
                DataHelper.DefaultBassist(),
                DataHelper.DefaultKeyboardist(),
                DataHelper.DefaultDrummer(),
                DataHelper.DefaultGuitarist(),
                DataHelper.DefaultLeadVocalist()
            };

            return datalist;

        }
    }
}