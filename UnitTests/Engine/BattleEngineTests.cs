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
    /// <summary>
    /// Unit tests for BattleEngine class
    /// </summary>
    [TestFixture]
    public class BattleEngineTests
    {
        // BattleEngine to use in testing
        BattleEngine Engine;

        /// <summary>
        /// Create a new BattleEngine
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Engine = new BattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }

        // Test constructor
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

        // Confirm AutoBattle argument is set
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

        // Test EndBattle
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

        // Add a character (band member)
        [Test]
        public void BattleEngine_AddBandMember_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();

            // Act
            var result = Engine.AddBandMember(character);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
