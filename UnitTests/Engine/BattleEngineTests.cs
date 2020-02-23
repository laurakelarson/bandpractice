using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Models;
using Game.Engine;

namespace UnitTests.Engine
{
    [TestFixture]
    public class BattleEngineTests
    {
        BattleEngine Engine;

        [SetUp]
        public void SetUp()
        {
            Engine = new BattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void BattleEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattleEngine_StartBattle_AutoMode_True_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.StartBattle(true);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, Engine.Score.AutoBattle);
        }

        [Test]
        public void BattleEngine_EndBattle_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.EndBattle();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
