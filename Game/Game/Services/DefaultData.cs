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
                DefaultItemHelper.DefaultEarplugs(), 
                DefaultItemHelper.DefaultEarmuffs(), 
                DefaultItemHelper.DefaultNoiseCancelingHeadphones(), 
                DefaultItemHelper.DefaultMicrophone(), 
                DefaultItemHelper.DefaultCoffee(), 
                DefaultItemHelper.DefaultEnergyDrink(), 
                DefaultItemHelper.DefaultMetronome(),
                DefaultItemHelper.DefaultTuningFork(),
                DefaultItemHelper.DefaultBandTShirt(),
                DefaultItemHelper.DefaultBandHoodie(),
                DefaultItemHelper.DefaultCoolOutfit(),
                DefaultItemHelper.DefaultRing(),
                DefaultItemHelper.DefaultMoodRing(),
                DefaultItemHelper.DefaultTemporaryTattoo(),
                DefaultItemHelper.DefaultAthleticSocks(),
                DefaultItemHelper.DefaultLuckySocks(),
                DefaultItemHelper.DefaultComfySneakers(),
                DefaultItemHelper.DefaultBunnySlippers(),
                DefaultItemHelper.DefaultTriangle(),
                DefaultItemHelper.DefaultPrankDoorbell(),
                DefaultItemHelper.DefaultWhoopeeCushion(), 
                DefaultItemHelper.DefaultVuvuzela(),
                DefaultItemHelper.DefaultOcarina(),
                DefaultItemHelper.DefaultBagpipe(),
                DefaultItemHelper.DefaultBanjo(),
                DefaultItemHelper.DefaultKeytar(),
                DefaultItemHelper.DefaultGoldenRecorder(),
                DefaultItemHelper.DefaultRockOck(),
                DefaultItemHelper.DefaultGlockenspiel(),
                DefaultItemHelper.DefaultTheremin(),
                DefaultItemHelper.DefaultDidgeridooOfDestruction()
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

        /// <summary>
        /// Load the default Monster data
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var datalist = new List<MonsterModel>()
            {
                DefaultMonsterHelper.DefaultChomper(),
                DefaultMonsterHelper.DefaultMassiveStatic(),  
                DefaultMonsterHelper.DefaultMotobeast(),
                DefaultMonsterHelper.DefaultKazoom(),
                DefaultMonsterHelper.DefaultPanpot(),
                DefaultMonsterHelper.DefaultJackhammer(),
                DefaultMonsterHelper.DefaultBrakez(),
                DefaultMonsterHelper.DefaultDriller(),
                DefaultMonsterHelper.DefaultAlarmer(),
                DefaultMonsterHelper.DefaultShrillBabe(),
                DefaultMonsterHelper.DefaultBuzzRowdy(),
                DefaultMonsterHelper.DefaultPiercingFeedback(),
                DefaultMonsterHelper.DefaultFranDrescher(),
                DefaultMonsterHelper.DefaultYowlingFeline(),
                DefaultMonsterHelper.DefaultNickelback(),
                DefaultMonsterHelper.DefaultLloydChristmas(),
                DefaultMonsterHelper.DefaultRecorderApprentice(),
                DefaultMonsterHelper.DefaultAirhornLeviathan(),
                DefaultMonsterHelper.DefaultEarsplittingChalkboard(),
                DefaultMonsterHelper.DefaultRubberChickenBlob(),
                DefaultMonsterHelper.DefaultAgonizingSilence(),
                DefaultMonsterHelper.DefaultGilbertGottfried()

            };

            return datalist;

        }

    }
}