using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;
using System.Collections.Generic;

namespace UnitTests.ScenarioTests
{
    [TestFixture]


    class ScenarioTests
    {
        AutoBattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new AutoBattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void AutoBattleEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Monsters_1_Should_Pass()
        {
            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            var CharacterPlayerBogus = new CharacterModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                TotalExperience = 1,
                                Name = "Bogus"
                            });

            Engine.CharacterList.Add(CharacterPlayerBogus);


            // Add Monsters

            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            Engine.MaxNumberMonsters = 1;

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Character_Level_Up_Should_Pass()
        {

            /* 
             * Test to force leveling up of a character during the battle
             * 
             * 1 Character, Experience set at next level mark
             * 
             * 6 Monsters
             * 
             * Character Should Level UP 1 level
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            // To See Level UP happening, a character needs to be close to the next level
            var Character = new CharacterModel
            {
                TotalExperience = 300,    // Enough for next level
                Name = "Level Up",
                Level = 1,
                Attack = 100,
                Speed = 1000    // Go first
            };

            // Remember Start Level
            var StartLevel = Character.Level;

            Engine.CharacterList.Add(Character);

            // Add Monsters

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, Engine.Score.CharacterAtDeathList.Contains("Level Up"));
            Assert.AreEqual(true, Engine.Score.CharacterAtDeathList.Contains("Level: 2"));
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_GameOver_Round_1_Should_Pass()
        {
            /* 
             * 
             * 1 Character, Speed slowest, only 1 HP
             * 
             * 6 Monsters
             * 
             * Should end in the first round
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            var CharacterPlayer = new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 10,
                                CurrentHealth = 1,
                                TotalExperience = 1,
                            };

            Engine.CharacterList.Add(CharacterPlayer);


            // Add Monsters

            Engine.MaxNumberMonsters = 6;

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }


        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_Round_Loop_Should_Fail()
        {
            /* 
             * Test infinite rounds.  
             * 
             * Characters overpower monsters, game never ends
             * 
             * 6 Character
             *      Speed high
             *      Hit Hard
             *      High health
             * 
             * 1 Monsters
             *      Slow
             *      Weak Hit
             *      Weak health
             * 
             * Should never end
             * 
             * Inifinite Loop Check should stop the game
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 6;

            var CharacterPlayer = new CharacterModel
                            {
                                Speed = 100,
                                Level = 20,
                                MaxHealth = 200,
                                CurrentHealth = 200,
                                TotalExperience = 1,
                            };

            var CharacterPlayerMin = new CharacterModel
                {
                    Speed = 99,
                    Level = 1,
                    MaxHealth = 200,
                    CurrentHealth = 200,
                    TotalExperience = 1,
                };

            Engine.CharacterList.Add(CharacterPlayer);
            Engine.CharacterList.Add(CharacterPlayer);
            Engine.CharacterList.Add(CharacterPlayer);
            Engine.CharacterList.Add(CharacterPlayer);
            Engine.CharacterList.Add(CharacterPlayer);
            Engine.CharacterList.Add(CharacterPlayerMin);

            // Add Monsters

            Engine.MaxNumberMonsters = 1;

            // Controll Rolls,  Hit is always a 3
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(3);

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            DiceHelper.EnableRandomValues();

            //Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, Engine.Score.RoundCount > Engine.MaxRoundCount);
        }

    }
}
