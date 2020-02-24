using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    [TestFixture]
    public class ScoreModelTests
    {
        [Test]
        public void ScoreModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void ScoreModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new ScoreModel();

            dataNew.Id = "oldID";

            dataNew.BattleNumber = 100;
            dataNew.ScoreTotal = 200;
            dataNew.GameDate = System.DateTime.MinValue;
            dataNew.AutoBattle = true;
            dataNew.TurnCount = 300;
            dataNew.RoundCount = 400;
            dataNew.MonsterSlainNumber = 500;
            dataNew.ExperienceGainedTotal = 600;
            dataNew.CharacterAtDeathList = "characters";
            dataNew.MonstersKilledList = "monsters";
            dataNew.ItemsDroppedList = "items";


            // Act
            var result = new ScoreModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        public void ScoreModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.BattleNumber);
            Assert.IsNotNull(result.ScoreTotal);
            Assert.IsNotNull(result.GameDate);
            Assert.IsNotNull(result.AutoBattle);
            Assert.IsNotNull(result.TurnCount);
            Assert.IsNotNull(result.RoundCount);
            Assert.IsNotNull(result.MonsterSlainNumber);
            Assert.IsNotNull(result.ExperienceGainedTotal);

            Assert.AreEqual(string.Empty, result.CharacterAtDeathList);
            Assert.AreEqual(string.Empty, result.MonstersKilledList);
            Assert.AreEqual(string.Empty, result.ItemsDroppedList);
        }

    }
}
