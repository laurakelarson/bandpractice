using Game.Engine;
using Game.Models;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Engine
{
    /// <summary>
    /// Unit tests for the RoundEngine class
    /// </summary>
    [TestFixture]
    public class RoundEngineTests
    {
        // BattleEngine for testing
        BattleEngine Engine;

        // Create a new BattleEngine and StartBattle
        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.StartBattle(false); // trigger new round
        }

        [TearDown]
        public void TearDown()
        {
        }

        // Test constructor
        [Test]
        public void RoundEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // test that EntityList order is correct
        [Test]
        public void RoundEngine_OrderEntityListByTurnOrder_Speed_Higher_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceGiven = 1000,
                Name = "Z",
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "C",
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("me", result[0].Id);
        }

        // test sort order by level in case where Speed is equal
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Level_Higher_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceGiven = 1000,
                Name = "Z",
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "C",
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("me", result[0].Id);
        }

    }
}
