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

        [Test]
        public void ScoreModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();
            result.BattleNumber = 100;
            result.ScoreTotal = 200;
            result.GameDate = System.DateTime.MinValue;
            result.AutoBattle = true;
            result.TurnCount = 300;
            result.RoundCount = 400;
            result.MonsterSlainNumber = 500;
            result.ExperienceGainedTotal = 600;
            result.CharacterAtDeathList = "characters";
            result.MonstersKilledList = "monsters";
            result.ItemsDroppedList = "items";

            // Reset

            // Assert 
            Assert.AreEqual(100, result.BattleNumber);
            Assert.AreEqual(200, result.ScoreTotal);
            Assert.AreEqual(System.DateTime.MinValue, result.GameDate);
            Assert.AreEqual(true, result.AutoBattle);
            Assert.AreEqual(300, result.TurnCount);
            Assert.AreEqual(400, result.RoundCount);
            Assert.AreEqual(500, result.MonsterSlainNumber);
            Assert.AreEqual(600, result.ExperienceGainedTotal);
            Assert.AreEqual("characters", result.CharacterAtDeathList);
            Assert.AreEqual("monsters", result.MonstersKilledList);
            Assert.AreEqual("items", result.ItemsDroppedList);
        }

        [Test]
        public void ScoreModel_Update_Default_Should_Pass()
        {
            // Arrange
            ScoreModel dataOriginal = new ScoreModel();

            ScoreModel dataNew = new ScoreModel();
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
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(100, dataOriginal.BattleNumber);
            Assert.AreEqual(200, dataOriginal.ScoreTotal);
            Assert.AreEqual(System.DateTime.MinValue, dataOriginal.GameDate);
            Assert.AreEqual(true, dataOriginal.AutoBattle);
            Assert.AreEqual(300, dataOriginal.TurnCount);
            Assert.AreEqual(400, dataOriginal.RoundCount);
            Assert.AreEqual(500, dataOriginal.MonsterSlainNumber);
            Assert.AreEqual(600, dataOriginal.ExperienceGainedTotal);
            Assert.AreEqual("characters", dataOriginal.CharacterAtDeathList);
            Assert.AreEqual("monsters", dataOriginal.MonstersKilledList);
            Assert.AreEqual("items", dataOriginal.ItemsDroppedList);
        }


    }
}
