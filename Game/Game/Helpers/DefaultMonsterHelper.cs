using System;
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Earmuffs" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Coffee" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Coffee" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Earmuffs" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Earmuffs", "Earplugs" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Prank Doorbell" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Energy Drink", "Prank Doorbell" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Coffee", "Metronome" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Whoopee Cushion" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Band T-shirt", "Whoopee Cushion", "Earmuffs" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Energy Drink", "Tuning Fork" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Vuvuzela" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Coffee", "Ring", "Earplugs" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Earmuffs", "Band Hoodie" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Cool Outfit", "Ocarina" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Lucky Socks", "Ocarina", "Tuning Fork" });
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
           // result.ItemsDropped = ConvertItemsList(new List<string>() { "Energy Drink", "Band T-shirt" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Metronome", "Bagpipe" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Lucky Socks", "Metronome" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Mood Ring" });
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
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Noise-Canceling Headphones", "Banjo" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Earplugs", "Band Hoodie" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Cool Outfit", "Temporary Tattoo" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Ring", "Athletic Socks" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Bunny Slippers", "Keytar" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Mood Ring", "Comfy Sneakers" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Golden Recorder", "Temporary Tattoo" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Lucky Socks" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Noise-Canceling Headphones", "Rock Ock" });
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Earmuffs", "Athletic Socks" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Bunny Slippers" });
            result.ItemPocket1 = ConvertItemsList("Earmuffs");
            result.ItemPocket2 = ConvertItemsList("Athletic Socks");
            result.ItemPocket3 = ConvertItemsList("Bunny Slippers");
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Bunny Slippers", "Mood Ring" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Glockenspiel" });
            result.ItemPocket1 = ConvertItemsList("Bunny Slippers");
            result.ItemPocket2 = ConvertItemsList("Mood Ring");
            result.ItemPocket3 = ConvertItemsList("Glockenspiel");
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Temporary Tattoo", "Comfy Sneakers" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Theremin" });
            result.ItemPocket1 = ConvertItemsList("Theremin");
            result.ItemPocket2 = ConvertItemsList("Temporary Tattoo");
            result.ItemPocket3 = ConvertItemsList("Comfy Sneakers");
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
            //result.ItemsDropped = ConvertItemsList(new List<string>() { "Rock Ock", "Keytar", "Glockenspiel" });
            //result.UniqueDrops = ConvertItemsList(new List<string>() { "Didgeridoo of Destruction" });
            result.ItemPocket1 = ConvertItemsList("Rock Ock");
            result.ItemPocket2 = ConvertItemsList("Glockenspiel");
            result.ItemPocket3 = ConvertItemsList("Didgeridoo of Destruction");
            return result;
        }

        /// <summary>
        /// Helper method to take a string of item names and return a json formatted string of the id list
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string ConvertItemsList(string itemName)
        {
            if (itemName.Equals(string.Empty))
            {
                return string.Empty;
            }
            var item = ItemIndexViewModel.Instance.GetItemByName(itemName);

            string output = item.Id;
            return output;
        }

    }
}
