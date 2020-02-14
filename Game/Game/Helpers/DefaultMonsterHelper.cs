using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;

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
        /// Returns default Chomper MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultChomper()
        {
            return new MonsterModel
            {
                Name = "Chomper",
                ImageURI = "monster_chomper.png",
                Alive = true,
                Level = 1,
                ExperienceGiven = 50,
                Attack = 2,
                Defense = 0,
                Speed = 1,
                Range = 1,
                CurrentHealth = 5,
                ItemsDropped = new List<ItemModel>() {
                    new ItemModel(DefaultItemHelper.DefaultEarmuffs()) },
                UniqueDrops = new List<ItemModel>()
            };
        }

        /// <summary>
        /// Returns default Massive Static MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultMassiveStatic()
        {
            return new MonsterModel
            {
                Name = "Massive Static",
                ImageURI = "monster_static.png",
                Alive = true,
                Level = 2,
                ExperienceGiven = 100,
                Attack = 2,
                Defense = 1,
                Speed = 0,
                Range = 1,
                CurrentHealth = 7,
                ItemsDropped = new List<ItemModel>() 
                {
                    new ItemModel(DefaultItemHelper.DefaultCoffee()) 
                },
                UniqueDrops = new List<ItemModel>()
                {
                    new ItemModel(DefaultItemHelper.DefaultCoffee())
                }
            };
        }

        /// <summary>
        /// Returns default Motobeast MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultMotobeast()
        {
            return new MonsterModel
            {
                Name = "Motobeast",
                ImageURI = "monster_motobeast.png",
                Alive = true,
                Level = 3,
                ExperienceGiven = 200,
                Attack = 3,
                Defense = 1,
                Speed = 0,
                Range = 1,
                CurrentHealth = 10,
                ItemsDropped = new List<ItemModel>()
                {
                    new ItemModel(DefaultItemHelper.DefaultEarplugs())
                },
                UniqueDrops = new List<ItemModel>()
            };
        }

        /// <summary>
        /// Returns default Kazoom MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultKazoom()
        {
            return new MonsterModel
            {
                Name = "Kazoom",
                ImageURI = "monster_kazoom.png",
                Alive = true,
                Level = 4,
                ExperienceGiven = 450,
                Attack = 3,
                Defense = 2,
                Speed = 1,
                Range = 1,
                CurrentHealth = 15
                // TODO add list for items dropped and unique drops after helper created
            };
        }

        /// <summary>
        /// Returns default Panpot MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultPanpot()
        {
            return new MonsterModel
            {
                Name = "Panpot",
                ImageURI = "monster_panpot.png",
                Alive = true,
                Level = 5,
                ExperienceGiven = 700,
                Attack = 4,
                Defense = 2,
                Speed = 1,
                Range = 1,
                CurrentHealth = 25
                // TODO add list for items dropped and unique drops after helper created
            };
        }

        /// <summary>
        /// Returns default Jackhammer MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultJackhammer()
        {
            return new MonsterModel
            {
                Name = "Jackhammer",
                ImageURI = "monster_jackhammer.png",
                Alive = true,
                Level = 6,
                ExperienceGiven = 1000,
                Attack = 4,
                Defense = 2,
                Speed = 1,
                Range = 2,
                CurrentHealth = 30
                // TODO add list for items dropped and unique drops after helper created
            };
        }

        /// <summary>
        /// Returns default Brakez MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultBrakez()
        {
            return new MonsterModel
            {
                Name = "Brakez",
                ImageURI = "monster_brakez.png",
                Alive = true,
                Level = 7,
                ExperienceGiven = 1200,
                Attack = 5,
                Defense = 3,
                Speed = 2,
                Range = 2,
                CurrentHealth = 45
                // TODO add list for items dropped and unique drops after helper created
            };
        }

        /// <summary>
        /// Returns default Driller MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultDriller()
        {
            return new MonsterModel
            {
                Name = "Driller",
                ImageURI = "monster_driller.png",
                Alive = true,
                Level = 8,
                ExperienceGiven = 1750,
                Attack = 7,
                Defense = 4,
                Speed = 2,
                Range = 2,
                CurrentHealth = 60
                // TODO add list for items dropped and unique drops after helper created
            };
        }

        /// <summary>
        /// Returns default Alarmer MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultAlarmer()
        {
            return new MonsterModel
            {
                Name = "Alarmer",
                ImageURI = "monster_alarm.png",
                Alive = true,
                Level = 9,
                ExperienceGiven = 2000,
                Attack = 7,
                Defense = 4,
                Speed = 2,
                Range = 2,
                CurrentHealth = 75
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Shrill Babe MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultShrillBabe()

        {
            return new MonsterModel
            {
                Name = "Shrill Babe",
                ImageURI = "monster_screaming_babe.png",
                Alive = true,
                Level = 10,
                ExperienceGiven = 5500,
                Attack = 8,
                Defense = 4,
                Speed = 3,
                Range = 2,
                CurrentHealth = 100,
                Boss = true
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Buzz Rowdy MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultBuzzRowdy()
        {
            return new MonsterModel
            {
                Name = "Buzz Rowdy",
                ImageURI = "monster_buzz.png",
                Alive = true,
                Level = 11,
                ExperienceGiven = 3750,
                Attack = 8,
                Defense = 5,
                Speed = 3,
                Range = 3,
                CurrentHealth = 145
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Piercing Feedback MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultPiercingFeedback()
        {
            return new MonsterModel
            {
                Name = "PiercingFeedback",
                ImageURI = "monster_feedback.png",
                Alive = true,
                Level = 12,
                ExperienceGiven = 4300,
                Attack = 8,
                Defense = 5,
                Speed = 3,
                Range = 3,
                CurrentHealth = 180
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Fran Drescher MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultFranDrescher()
        {
            return new MonsterModel
            {
                Name = "Fran Drescher",
                ImageURI = "monster_fran.png",
                Alive = true,
                Level = 13,
                ExperienceGiven = 5000,
                Attack = 12,
                Defense = 5,
                Speed = 4,
                Range = 3,
                CurrentHealth = 250
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Yowling Feline MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultYowlingFeline()
        {
            return new MonsterModel
            {
                Name = "Yowling Feline Monster",
                ImageURI = "monster_cat.png",
                Alive = true,
                Level = 14,
                ExperienceGiven = 9500,
                Attack = 10,
                Defense = 6,
                Speed = 4,
                Range = 3,
                CurrentHealth = 375,
                Boss = true
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Nickelback MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultNickelback()
        {
            return new MonsterModel
            {
                Name = "Nickelback",
                ImageURI = "monster_nickelback.png",
                Alive = true,
                Level = 15,
                ExperienceGiven = 8000,
                Attack = 15,
                Defense = 6,
                Speed = 5,
                Range = 4,
                CurrentHealth = 500
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Lloyd Christmas MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultLloydChristmas()
        {
            return new MonsterModel
            {
                Name = "Lloyd Christmas",
                ImageURI = "monster_lloyd_christmas.png",
                Alive = true,
                Level = 15,
                ExperienceGiven = 9000,
                Attack = 12,
                Defense = 7,
                Speed = 6,
                Range = 4,
                CurrentHealth = 550
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Recorder Apprentice MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultRecorderApprentice()
        {
            return new MonsterModel
            {
                Name = "RecorderApprentice",
                ImageURI = "monster_recorder_student.png",
                Alive = true,
                Level = 16,
                ExperienceGiven = 12000,
                Attack = 15,
                Defense = 7,
                Speed = 6,
                Range = 4,
                CurrentHealth = 600,
                Boss = true
                // TODO add list for items dropped and unique drops after helper created
            };


        }
      
        /// <summary>
        /// Returns default AirhornLeviathan MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultAirhornLeviathan()
        {
            return new MonsterModel
            {
                Name = "Airhorn Leviathan",
                ImageURI = "monster_airhorn.png",
                Alive = true,
                Level = 17,
                ExperienceGiven = 11000,
                Attack = 17,
                Defense = 8,
                Speed = 7,
                Range = 4,
                CurrentHealth = 700
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Earsplitting Chalkboard MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultEarsplittingChalkboard()
        {
            return new MonsterModel
            {
                Name = "Earsplitting Nails on Chalkboard",
                ImageURI = "monster_chalkboard.png",
                Alive = true,
                Level = 18,
                ExperienceGiven = 12000,
                Attack = 18,
                Defense = 8,
                Speed = 7,
                Range = 5,
                CurrentHealth = 800
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default RubberChickenBlob MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultRubberChickenBlob()
        {
            return new MonsterModel
            {
                Name = "RubberChickenBlob",
                ImageURI = "monster_rubber_chicken.png",
                Alive = true,
                Level = 19,
                ExperienceGiven = 25000,
                Attack = 19,
                Defense = 9,
                Speed = 8,
                Range = 5,
                CurrentHealth = 900,
                Boss = true
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default AgonizingSilence MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultAgonizingSilence()
        {
            return new MonsterModel
            {
                Name = "Agonizing Silence",
                ImageURI = "monster_silence.png",
                Alive = true,
                Level = 19,
                ExperienceGiven = 13000,
                Attack = 19,
                Defense = 9,
                Speed = 9,
                Range = 5,
                CurrentHealth = 950
                // TODO add list for items dropped and unique drops after helper created
            };


        }

        /// <summary>
        /// Returns default Gilbert Gottfried MonsterModel
        /// </summary>
        /// <returns></returns>
        public static MonsterModel DefaultGilbertGottfried()
        {
            return new MonsterModel
            {
                Name = "Gilbert Gottfried",
                ImageURI = "monster_gilbert.png",
                Alive = true,
                Level = 20,
                ExperienceGiven = 30000,
                Attack = 20,
                Defense = 10,
                Speed = 10,
                Range = 8,
                CurrentHealth = 1000
                // TODO add list for items dropped and unique drops after helper created
            };


        }



    }
}
