using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;

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
    }
}
