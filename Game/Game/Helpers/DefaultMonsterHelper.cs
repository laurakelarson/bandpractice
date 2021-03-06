﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Models;
using Game.ViewModels;
using Newtonsoft.Json;

namespace Game.Helpers
{
    /// <summary>
    /// DataHelper is a static class that helps create characters with the game's default base stats.
    /// </summary>
    public static class DefaultMonsterHelper
    {

        /// <summary>
        /// Helper that takes in a CharacterTypeEnum to return the default base version of that type
        /// </summary>
        /// <param name="type"></param>
        public static MonsterModel DefaultMonster(MonsterTypeEnum type)
        {
            switch (type)
            {
                case MonsterTypeEnum.MassiveStatic:
                    return DefaultMassiveStatic();
                case MonsterTypeEnum.Motobeast:
                    return DefaultMotobeast();
                case MonsterTypeEnum.Jackhammer:
                    return DefaultJackhammer();
                case MonsterTypeEnum.Kazoom:
                    return DefaultKazoom();
                case MonsterTypeEnum.Panpot:
                    return DefaultPanpot();
                case MonsterTypeEnum.Brakez:
                    return DefaultBrakez();
                case MonsterTypeEnum.Driller:
                    return DefaultDriller();
                case MonsterTypeEnum.Alarmer:
                    return DefaultAlarmer();
                case MonsterTypeEnum.ShrillBabe:
                    return DefaultShrillBabe();
                case MonsterTypeEnum.BuzzRowdy:
                    return DefaultBuzzRowdy();
                case MonsterTypeEnum.FranDrescher:
                    return DefaultFranDrescher();
                case MonsterTypeEnum.PiercingFeedback:
                    return DefaultPiercingFeedback();
                case MonsterTypeEnum.YowlingFeline:
                    return DefaultYowlingFeline();
                case MonsterTypeEnum.Nickelback:
                    return DefaultNickelback();
                case MonsterTypeEnum.RecorderApprentice:
                    return DefaultRecorderApprentice();
                case MonsterTypeEnum.LloydChristmas:
                    return DefaultLloydChristmas();
                case MonsterTypeEnum.AirhornLeviathan:
                    return DefaultAirhornLeviathan();
                case MonsterTypeEnum.EarsplittingChalkboard:
                    return DefaultEarsplittingChalkboard();
                case MonsterTypeEnum.RubberChickenBlob:
                    return DefaultRubberChickenBlob();
                case MonsterTypeEnum.AgonizingSilence:
                    return DefaultAgonizingSilence();
                case MonsterTypeEnum.GilbertGottfried:
                    return DefaultGilbertGottfried();
                default:
                    return DefaultChomper();
            }
        }

        /// <summary>
        ///  Gets the list of Monster types.
        ///  Removes "Unknown" from the list, so it's suitable for user facing pages.
        /// </summary>
        public static List<string> GetListMonsterType
        {
            get
            {
                var myList = Enum.GetNames(typeof(MonsterTypeEnum)).ToList().
                    Where(m => m.ToString().Equals(MonsterTypeEnum.Unknown.ToString()) == false).ToList();
                var myReturn = myList.OrderBy(a => a).ToList();

                return myReturn;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MonsterTypeEnum ConvertStringToEnum(string value)
        {
            return (MonsterTypeEnum)Enum.Parse(typeof(MonsterTypeEnum), value);
        }

        /// <summary>
        /// Returns default Chomper MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultChomper()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(1);
            result.Name = "Chomper";
            result.ImageURI = "monster_chomper.png";
            result.ItemPocket1 = FindItemId("Earmuffs");
            result.ItemPocket2 = FindItemId("Coffee");
            result.ItemPocket3 = FindItemId("Energy Drink");
            return result;
            
        }

        /// <summary>
        /// Returns default Massive Static MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultMassiveStatic()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(2);
            result.Name = "Massive Static";
            result.ImageURI = "monster_static.png";
            result.ItemPocket1 = FindItemId("Coffee");
            result.ItemPocket2 = FindItemId("Coffee");
            result.ItemPocket3 = FindItemId("Microphone");
            return result;
        }

        /// <summary>
        /// Returns default Motobeast MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultMotobeast()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(3);
            result.Name = "Motobeast";
            result.ImageURI = "monster_motobeast.png";
            result.ItemPocket1 = FindItemId("Earmuffs");
            result.ItemPocket2 = FindItemId("Earplugs");
            result.ItemPocket3 = FindItemId("Prank Doorbell");
            return result;
        }

        /// <summary>
        /// Returns default Kazoom MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultKazoom()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(4);
            result.Name = "Kazoom";
            result.ImageURI = "monster_kazoom.png";
            result.ItemPocket1 = FindItemId("Earmuffs");
            result.ItemPocket2 = FindItemId("Earplugs");
            result.ItemPocket3 = FindItemId("Prank Doorbell");
            return result;
        }

        /// <summary>
        /// Returns default Panpot MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultPanpot()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(5);
            result.Name = "Panpot";
            result.ImageURI = "monster_potpan.png";
            result.ItemPocket1 = FindItemId("Energy Drink");
            result.ItemPocket2 = FindItemId("Prank Doorbell");
            result.ItemPocket3 = FindItemId("Tuning Fork");
            return result;
        }

        /// <summary>
        /// Returns default Jackhammer MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultJackhammer()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(6);
            result.Name = "Jackhammer";
            result.ImageURI = "monster_jackhammer.png";
            result.ItemPocket1 = FindItemId("Coffee");
            result.ItemPocket2 = FindItemId("Metronome");
            result.ItemPocket3 = FindItemId("Whoopee Cushion");
            return result;
        }

        /// <summary>
        /// Returns default Brakez MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultBrakez()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(7);
            result.Name = "Brakez";
            result.ImageURI = "monster_brakez.png";
            result.ItemPocket1 = FindItemId("Band T-shirt");
            result.ItemPocket2 = FindItemId("Whoopee Cushion");
            result.ItemPocket3 = FindItemId("Earmuffs");
            return result;
        }

        /// <summary>
        /// Returns default Driller MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultDriller()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(8);
            result.Name = "Driller";
            result.ImageURI = "monster_driller.png";
            result.ItemPocket1 = FindItemId("Energy Drink");
            result.ItemPocket2 = FindItemId("Tuning Fork");
            result.ItemPocket3 = FindItemId("Vuvuzela");
            return result;
        }

        /// <summary>
        /// Returns default Alarmer MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultAlarmer()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(8);
            result.Name = "Alarmer";
            result.ImageURI = "monster_alarm.png";
            result.ItemPocket1 = FindItemId("Coffee");
            result.ItemPocket2 = FindItemId("Ring");
            result.ItemPocket3 = FindItemId("Earplugs");
            return result;
        }

        /// <summary>
        /// Returns default Shrill Babe MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultShrillBabe()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(10);
            result.Name = "Shrill Babe";
            result.ImageURI = "monster_screaming_babe.png";
            result.ItemPocket1 = FindItemId("Earmuffs");
            result.ItemPocket2 = FindItemId("Cool Outfit");
            result.ItemPocket3 = FindItemId("Ocarina");
            return result;
        }

        /// <summary>
        /// Returns default Buzz Rowdy MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultBuzzRowdy()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(11);
            result.Name = "Buzz Rowdy";
            result.ImageURI = "monster_buzz.png";
            result.ItemPocket1 = FindItemId("Lucky Socks");
            result.ItemPocket2 = FindItemId("Ocarina");
            result.ItemPocket3 = FindItemId("Tuning Fork");
            return result;
        }

        /// <summary>
        /// Returns default Piercing Feedback MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultPiercingFeedback()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(12);
            result.Name = "Piercing Feedback";
            result.ImageURI = "monster_feedback.png";
            result.ItemPocket1 = FindItemId("Energy Drink");
            result.ItemPocket2 = FindItemId("Band T-shirt");
            result.ItemPocket3 = FindItemId("Bagpipe");
            return result;
        }

        /// <summary>
        /// Returns default Fran Drescher MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultFranDrescher()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(13);
            result.Name = "Fran Drescher";
            result.ImageURI = "monster_fran.png";
            result.ItemPocket1 = FindItemId("Lucky Socks");
            result.ItemPocket2 = FindItemId("Metronome");
            result.ItemPocket3 = FindItemId("Mood Ring");
            return result;
        }

        /// <summary>
        /// Returns default Yowling Feline MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultYowlingFeline()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(14);
            result.Name = "Yowling Feline Monster";
            result.ImageURI = "monster_cat.png";
            result.ItemPocket1 = FindItemId("Lucky Socks");
            result.ItemPocket2 = FindItemId("Noise-Canceling Headphones");
            result.ItemPocket3 = FindItemId("Banjo");
            return result;          
        }

        /// <summary>
        /// Returns default Nickelback MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultNickelback()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(15);
            result.Name = "Nickelback";
            result.ImageURI = "monster_nickelback.png";
            result.ItemPocket1 = FindItemId("Earplugs");
            result.ItemPocket2 = FindItemId("Band Hoodie");
            result.ItemPocket3 = FindItemId("Temporary Tattoo");
            return result;
        }

        /// <summary>
        /// Returns default Lloyd Christmas MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultLloydChristmas()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(15);
            result.Name = "Lloyd Christmas";
            result.ImageURI = "monster_lloyd_christmas.png";
            result.ItemPocket1 = FindItemId("Ring");
            result.ItemPocket2 = FindItemId("Athletic Socks");
            result.ItemPocket3 = FindItemId("Keytar");
            return result;
        }

        /// <summary>
        /// Returns default Recorder Apprentice MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultRecorderApprentice()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(16);
            result.Name = "Recorder Apprentice";
            result.ImageURI = "monster_recorder_student.png";
            result.ItemPocket1 = FindItemId("Comfy Sneakers");
            result.ItemPocket2 = FindItemId("Golden Recorder");
            result.ItemPocket3 = FindItemId("Temporary Tattoo");
            return result;
        }
      
        /// <summary>
        /// Returns default AirhornLeviathan MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultAirhornLeviathan()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(17);
            result.Name = "Airhorn Leviathan";
            result.ImageURI = "monster_airhorn.png";
            result.ItemPocket1 = FindItemId("Lucky Socks");
            result.ItemPocket2 = FindItemId("Noise-Canceling Headphones");
            result.ItemPocket3 = FindItemId("Glockenspiel");
            return result;
        }

        /// <summary>
        /// Returns default Earsplitting Chalkboard MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultEarsplittingChalkboard()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(18);
            result.Name = "Earsplitting Nails on Chalkboard";
            result.ImageURI = "monster_chalkboard.png";
            result.ItemPocket1 = FindItemId("Earmuffs");
            result.ItemPocket2 = FindItemId("Athletic Socks");
            result.ItemPocket3 = FindItemId("Bunny Slippers");
            return result;
        }

        /// <summary>
        /// Returns default RubberChickenBlob MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultRubberChickenBlob()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(19);
            result.Name = "Rubber Chicken Blob";
            result.ImageURI = "monster_rubber_chicken.png";
            result.ItemPocket1 = FindItemId("Bunny Slippers");
            result.ItemPocket2 = FindItemId("Mood Ring");
            result.ItemPocket3 = FindItemId("Glockenspiel");
            return result;
        }

        /// <summary>
        /// Returns default AgonizingSilence MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultAgonizingSilence()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(19);
            result.Name = "Agonizing Silence";
            result.ImageURI = "monster_silence.png";
            result.ItemPocket1 = FindItemId("Theremin");
            result.ItemPocket2 = FindItemId("Temporary Tattoo");
            result.ItemPocket3 = FindItemId("Comfy Sneakers");
            return result;
        }

        /// <summary>
        /// Returns default Gilbert Gottfried MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultGilbertGottfried()
        {
            MonsterModel result = new MonsterModel();
            result.ChangeLevel(20);
            result.Name = "Gilbert Gottfried";
            result.ImageURI = "monster_gilbert.png";
            result.ItemPocket1 = FindItemId("Rock Ock");
            result.ItemPocket2 = FindItemId("Glockenspiel");
            result.ItemPocket3 = FindItemId("Didgeridoo of Destruction");
            return result;
        }

        /// <summary>
        /// Queries the Item Index View Model for an item of the input name.
        /// If item is found, returns the Id, otherwise returns an empty string if the item does not exist.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string FindItemId(string itemName)
        {
            // Ask Item Index View Model if it has this named item
            var item = ItemIndexViewModel.Instance.GetItemByName(itemName);

            // item was not found
            if (item == null)
            {
                return string.Empty;
            }

            string output = item.Id;
            return output;
        }

    }
}
