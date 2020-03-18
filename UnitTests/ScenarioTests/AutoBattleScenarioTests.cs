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


    class AutoBattleScenarioTests
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
            /**
             * Test running auto battle 1 character vs. 1 monster
             */

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

            Engine.CharacterList.Clear();

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

            // set dice to always hit
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            DiceHelper.DisableRandomValues();
            Engine.MonsterList.Clear();
            Engine.CharacterList.Clear();
            Engine.EntityList.Clear();

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

            // Turn count can be infinite
            Engine.MaxTurnCount = int.MaxValue;

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            Engine.CharacterList.Clear();
            Engine.MonsterList.Clear();
            Engine.EntityList.Clear();

            //Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, Engine.Score.RoundCount > Engine.MaxRoundCount);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_Trun_Loop_Should_Fail()
        {
            /* 
             * Test infinate turn.  
             * 
             * Monsters overpower Characters game never ends
             * 
             * 1 Character
             *      Speed low
             *      Hit weak
             *      Health low
             * 
             * 6 Monsters
             *      Speed High
             *      Hit strong
             *      Health High
             * 
             * Rolls for always Miss
             * 
             * Should never end
             * 
             * Inifinite Loop Check should stop the game
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            var CharacterPlayer = new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                MaxHealth = 1,
                                CurrentHealth = 1,
                            };

            Engine.CharacterList.Add(CharacterPlayer);


            // Add Monsters

            Engine.MaxNumberMonsters = 6;

            // Controll Rolls,  Always Miss
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(1);

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            DiceHelper.EnableRandomValues();
            Engine.CharacterList.Clear();
            Engine.MonsterList.Clear();
            Engine.EntityList.Clear();

            //Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, Engine.Score.TurnCount > Engine.MaxTurnCount);
            Assert.AreEqual(true, Engine.Score.RoundCount < Engine.MaxRoundCount);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Monster_Dies_Item_Drop_Should_Pass()
        {
            /*
             * 2 Characters: highest speed
             * 
             * 1 Monster
             * 
             * Characters should defeat at least one Monster.
             * Monster should drop at least one item.
             */
            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 2;

            var CharacterPlayer = new CharacterModel
            {
                Speed = 1000, // Will go first....
                Level = 10,
                CurrentHealth = 100,
                TotalExperience = 1,
            };

            Engine.CharacterList.Add(CharacterPlayer);
            Engine.CharacterList.Add(new CharacterModel(CharacterPlayer));


            // Add Monsters

            Engine.MaxNumberMonsters = 1;

            //Act
            await Engine.RunAutoBattle();
            bool result = Engine.Score.ItemsDroppedList.Count() > 0;

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Character_Dies_Item_Drop_Should_Pass()
        {
            /*
             * 1 Characters:
             *      lowest speed
             *      1 HP
             *      holding an item
             * 
             * 1 Monster
             * 
             * Character should die,
             * Bogus item should be in item drop.
             */
            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 3;

            var CharacterPlayer = new CharacterModel
            {
                Speed = -1, // Will go last....
                Level = 10,
                CurrentHealth = 1,
                TotalExperience = 1,
            };

            // Add Item
            var Item = ItemIndexViewModel.Instance.GetRandomItem();
            CharacterPlayer.AddItem(Item.Location, Item);

            Engine.CharacterList.Add(CharacterPlayer);


            // Add Monsters

            Engine.MaxNumberMonsters = 1;

            //Act
            await Engine.RunAutoBattle();
            bool result = Engine.Score.ItemsDroppedList.Contains(Item.Name);

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}
