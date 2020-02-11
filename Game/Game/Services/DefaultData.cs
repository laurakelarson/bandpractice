using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Gold Sword",
                    Description = "Sword made of Gold, really expensive looking",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    Range = 0,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Strong Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},
            };

            return datalist;
        }

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
                new CharacterModel(CharacterTypeEnum.TambourinePlayer),
                //{
                //    Name = "Tambourine Player",
                //    Type = CharacterTypeEnum.TambourinePlayer,
                //    ImageURI="http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                //    Level = 1,
                //    TotalExperience = 0,
                //    Attack = 1,
                //    Defense = 1,
                //    Speed = 1
                //},
                new CharacterModel
                {
                    Name = "Bassist",
                    Type = CharacterTypeEnum.Bassist,
                    ImageURI="http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Level = 2,
                    TotalExperience = 300,
                    Attack = 1,
                    Defense = 1,
                    Speed = 1
                },
                new CharacterModel
                {
                    Name = "Keyboardist",
                    Type = CharacterTypeEnum.Keyboardist,
                    ImageURI="http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Level = 5,
                    TotalExperience = 6500,
                    Attack = 2,
                    Defense = 4,
                    Speed = 2
                },
                new CharacterModel
                {
                    Name = "Drummer",
                    Type = CharacterTypeEnum.Drummer,
                    ImageURI="http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Level = 8,
                    TotalExperience = 34000,
                    Attack = 3,
                    Defense = 5,
                    Speed = 2
                },
                new CharacterModel
                {
                    Name = "Guitarist",
                    Type = CharacterTypeEnum.Guitarist,
                    ImageURI="http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Level = 12,
                    TotalExperience = 100000,
                    Attack = 4,
                    Defense = 6,
                    Speed = 3
                },
                new CharacterModel
                {
                    Name = "Lead Vocalist",
                    Type = CharacterTypeEnum.LeadVocalist,
                    ImageURI="http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Level = 16,
                    TotalExperience = 195000,
                    Attack = 5,
                    Defense = 8,
                    Speed = 4
                }
            };

            return datalist;

        }
    }
}