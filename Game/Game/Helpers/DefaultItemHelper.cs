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
        /// Helper that takes in a ItemTypeEnum to return the default base version of that type
        /// </summary>
        /// <param name="type"></param>
        public static ItemModel DefaultItem(ItemTypeEnum type)
        {
            switch (type)
            {
                case ItemTypeEnum.Earplugs:
                    return DefaultEarplugs();
                case ItemTypeEnum.Earmuffs:
                    return DefaultEarmuffs();
                case ItemTypeEnum.NoiseCancelingHeadphones:
                    return DefaultNoiseCancelingHeadphones();
                case ItemTypeEnum.Microphone:
                    return DefaultMicrophone();
                case ItemTypeEnum.Coffee:
                    return DefaultCoffee();
                case ItemTypeEnum.EnergyDrink:
                    return DefaultEnergyDrink();
                case ItemTypeEnum.Metronome:
                    return DefaultMetronome();
                case ItemTypeEnum.TuningFork:
                    return DefaultTuningFork();
                case ItemTypeEnum.BandTshirt:
                    return DefaultBandTShirt();
                case ItemTypeEnum.BandHoodie:
                    return DefaultBandHoodie();
                case ItemTypeEnum.CoolOutfit:
                    return DefaultCoolOutfit();
                case ItemTypeEnum.Ring:
                    return DefaultRing();
                case ItemTypeEnum.MoodRing:
                    return DefaultMoodRing();
                case ItemTypeEnum.TemporaryTattoo:
                    return DefaultTemporaryTattoo();
                case ItemTypeEnum.AthleticSocks:
                    return DefaultAthleticSocks();
                case ItemTypeEnum.LuckySocks:
                    return DefaultLuckySocks();
                case ItemTypeEnum.ComfySneakers:
                    return DefaultComfySneakers();
                case ItemTypeEnum.BunnySlippers:
                    return DefaultBunnySlippers();
                case ItemTypeEnum.Triangle:
                    return DefaultTriangle();
                case ItemTypeEnum.PrankDoorbell:
                    return DefaultPrankDoorbell();
                case ItemTypeEnum.WhoopeeCushion:
                    return DefaultWhoopeeCushion(); 
               case ItemTypeEnum.Vuvuzela:
                    return DefaultVuvuzela();
                case ItemTypeEnum.Ocarina:
                    return DefaultOcarina();
                case ItemTypeEnum.Bagpipe:
                    return DefaultBagpipe();
                case ItemTypeEnum.Banjo:
                    return DefaultBanjo();
                case ItemTypeEnum.Keytar:
                    return DefaultKeytar();
                case ItemTypeEnum.GoldenRecorder:
                    return DefaultGoldenRecorder();
                case ItemTypeEnum.RockOck:
                    return DefaultRockOck();
                case ItemTypeEnum.Glockenspiel:
                    return DefaultGlockenspiel();
                case ItemTypeEnum.Theremin:
                    return DefaultTheremin();
                case ItemTypeEnum.DidgeridooOfDestruction:
                    return DefaultDidgeridooOfDestruction();
                default:
                    return DefaultEarplugs();
            }
        }

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

        /// <summary>
        /// Returns default TuningFork ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultTuningFork()
        {
            return new ItemModel
            {
                Name = "Tuning Fork",
                Description = "A tuning fork that helps the band keep its pitch",
                ImageURI = "item_tuning_fork.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.OffHand,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default BandTShirt ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultBandTShirt()
        {
            return new ItemModel
            {
                Name = "Band T-shirt",
                Description = "A soft t-shirt featuring the band’s logo",
                ImageURI = "item_band_shirt.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.Necklass,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default BandHoodie ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultBandHoodie()
        {
            return new ItemModel
            {
                Name = "Band Hoodie",
                Description = "A comfy hoodie featuring the band’s logo",
                ImageURI = "item_band_hoodie.png",
                Range = 0,
                Damage = 0,
                Value = 2,
                Location = ItemLocationEnum.Necklass,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default CoolOutfit ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultCoolOutfit()
        {
            return new ItemModel
            {
                Name = "Cool Outfit",
                Description = "A cool outfit that looks effortlessly hip (like a rock star would wear)",
                ImageURI = "item_cool_outfit.png",
                Range = 0,
                Damage = 0,
                Value = 3,
                Location = ItemLocationEnum.Necklass,
                Attribute = AttributeEnum.Defense
            };
        }

        /// <summary>
        /// Returns default Ring ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultRing()
        {
            return new ItemModel
            {
                Name = "Ring",
                Description = "A simple, nondescript ring",
                ImageURI = "item_ring.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.LeftFinger,
                Attribute = AttributeEnum.Attack
            };
        }

        /// <summary>
        /// Returns default MoodRing ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultMoodRing()
        {
            return new ItemModel
            {
                Name = "Mood Ring",
                Description = "A ring with a stone that changes color depending on the wearer’s mood",
                ImageURI = "item_mood_ring.png",
                Range = 0,
                Damage = 0,
                Value = 2,
                Location = ItemLocationEnum.LeftFinger,
                Attribute = AttributeEnum.Attack
            };
        }

        /// <summary>
        /// Returns default TemporaryTattoo ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultTemporaryTattoo()
        {
            return new ItemModel
            {
                Name = "Temporary Tattoo",
                Description = "A temporary tattoo of the band’s lyrics written around the wearer’s finger like a ring",
                ImageURI = "item_temporary_tattoo.png",
                Range = 0,
                Damage = 0,
                Value = 3,
                Location = ItemLocationEnum.LeftFinger,
                Attribute = AttributeEnum.Attack
            };
        }

        /// <summary>
        /// Returns default AthleticSocks ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultAthleticSocks()
        {
            return new ItemModel
            {
                Name = "Athletic Socks",
                Description = "Simple athletic socks",
                ImageURI = "item_athletic_socks.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.Feet,
                Attribute = AttributeEnum.Attack
            };
        }

        /// <summary>
        /// Returns default LuckySocks ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultLuckySocks()
        {
            return new ItemModel
            {
                Name = "Lucky Socks",
                Description = "Socks that feature a funky pattern",
                ImageURI = "item_lucky_socks.png",
                Range = 0,
                Damage = 0,
                Value = 2,
                Location = ItemLocationEnum.Feet,
                Attribute = AttributeEnum.Attack
            };
        }

        /// <summary>
        /// Returns default ComfySneakers ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultComfySneakers()
        {
            return new ItemModel
            {
                Name = "Comfy Sneakers",
                Description = "Sneakers that are comfortable to walk and stand in",
                ImageURI = "item_comfy_sneakers.png",
                Range = 0,
                Damage = 0,
                Value = 1,
                Location = ItemLocationEnum.Feet,
                Attribute = AttributeEnum.Speed
            };
        }

        /// <summary>
        /// Returns default BunnySlippers ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultBunnySlippers()
        {
            return new ItemModel
            {
                Name = "Bunny Slippers",
                Description = "Fluffy slippers that look like bunnies",
                ImageURI = "item_bunny_slippers.png",
                Range = 0,
                Damage = 0,
                Value = 2,
                Location = ItemLocationEnum.Feet,
                Attribute = AttributeEnum.Speed
            };
        }

        /// <summary>
        /// Returns default BunnySlippers ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultTriangle()
        {
            return new ItemModel
            {
                Name = "Triangle",
                Description = "A simple percussive instrument for dealing damage",
                ImageURI = "item_triangle.png",
                Range = 1,
                Damage = 2,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default PrankDoorbell ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultPrankDoorbell()
        {
            return new ItemModel
            {
                Name = "Prank Doorbell",
                Description = "A novelty gadget that convincingly sounds like a doorbell",
                ImageURI = "item_doorbell.png",
                Range = 1,
                Damage = 2,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default WhoopeeCushion ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultWhoopeeCushion()
        {
            return new ItemModel
            {
                Name = "Whoopee Cushion",
                Description = "A balloon-like device that creates a distracting noise",
                ImageURI = "item_whoopee_cushion.png",
                Range = 1,
                Damage = 3,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Vuvuzela ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultVuvuzela()
        {
            return new ItemModel
            {
                Name = "Vuvuzela",
                Description = "A plastic horn that produces a high-pitched sound",
                ImageURI = "item_vuvuzela.png",
                Range = 2,
                Damage = 4,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Ocarina ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultOcarina()
        {
            return new ItemModel
            {
                Name = "Ocarina",
                Description = "An ancient wind instrument",
                ImageURI = "item_ocarina.png",
                Range = 2,
                Damage = 5,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Bagpipe ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultBagpipe()
        {
            return new ItemModel
            {
                Name = "Bagpipe",
                Description = "A traditional reed instrument capable of destruction",
                ImageURI = "item_bagpipes.png",
                Range = 4,
                Damage = 8,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Banjo ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultBanjo()
        {
            return new ItemModel
            {
                Name = "Banjo",
                Description = "An old-fashioned folk instrument",
                ImageURI = "item_banjo.png",
                Range = 5,
                Damage = 12,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Keytar ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultKeytar()
        {
            return new ItemModel
            {
                Name = "Keytar",
                Description = "A stimulating hybrid synthesizer",
                ImageURI = "item_keytar.png",
                Range = 5,
                Damage = 15,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default GoldenRecorder ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultGoldenRecorder()
        {
            return new ItemModel
            {
                Name = "Golden Recorder",
                Description = "A beautifully crafted recorder made of pure gold",
                ImageURI = "item_recorder.png",
                Range = 6,
                Damage = 20,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default GoldenRecorder ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultRockOck()
        {
            return new ItemModel
            {
                Name = "Rock Ock",
                Description = "The ultimate 8-necked stringed instrument for defeating the most hardcore baddies",
                ImageURI = "item_rock_ock.png",
                Range = 6,
                Damage = 25,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Glockenspiel ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultGlockenspiel()
        {
            return new ItemModel
            {
                Name = "Glockenspiel",
                Description = "A lovely set of tuned keys arranged like a piano",
                ImageURI = "item_glockenspiel.png",
                Range = 7,
                Damage = 30,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default Theremin ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultTheremin()
        {
            return new ItemModel
            {
                Name = "Theremin",
                Description = "Contact-less electronic instrument for communicating with aliens",
                ImageURI = "item_theremin.png",
                Range = 8,
                Damage = 45,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }

        /// <summary>
        /// Returns default DidgeridooOfDestruction ItemModel
        /// </summary>
        /// <returns></returns>
        public static ItemModel DefaultDidgeridooOfDestruction()
        {
            return new ItemModel
            {
                Name = "Didgeridoo of Destruction",
                Description = "The ultimate weapon – the oldest wind instrument known to man.",
                ImageURI = "item_didgeridoo.png",
                Range = 10,
                Damage = 70,
                Value = 0,
                Location = ItemLocationEnum.PrimaryHand,
                Attribute = AttributeEnum.Unknown
            };
        }
    }
}
