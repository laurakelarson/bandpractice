using Game.Engine;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ScenarioTests
{
    [TestFixture]
    public class BattleEngineScenarioTests
    {
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new AutoBattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }

        //  test constructor
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
        public void BattleEngine_Battle_No_Characters_Should_Fail()
        {
            /*
             * Try running a battle with no characters.
             */

            // Arrange

            // monsters will be added by engine

            // Act
            Engine.StartBattle(false);
            var Player = Engine.GetNextPlayerTurn();
            var result = Engine.TakeTurn(Player);

            // Reset
            Engine.MonsterList.Clear();
            Engine.EntityList.Clear();

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
