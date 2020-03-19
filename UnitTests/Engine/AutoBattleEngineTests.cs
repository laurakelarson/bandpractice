using Game.Engine;
using Game.Helpers;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Engine
{
    [TestFixture]
    public class AutoBattleEngineTests
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
        public void AutoBattleEngine_GetScoreObject_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.GetScoreObject();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_CreateBand_Characters_Should_Assign_6()
        {
            //Arrange

            //Act
            var result = Engine.CreateBand();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(6, Engine.CharacterList.Count());
        }

        [Test]
        public async Task AutoBattleEngine_DetectInfiniteLoop_Turn_Should_PassAsync()
        {
            //Arrange
            var count = Engine.MaxTurnCount;
            Engine.MaxTurnCount = 1;

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            Engine.MaxTurnCount = count;

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
