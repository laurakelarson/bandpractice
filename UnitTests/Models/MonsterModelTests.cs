using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class MonsterModelTests
    {
        [Test]
        public void MonsterModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MonsterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterModel_Constructor_New_Monster_Should_Copy()
        {
            // Arrange
            var dataNew = new MonsterModel();
            dataNew.Range = 2;
            dataNew.Id = "oldID";

            // Act
            var result = new MonsterModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        public void MonsterModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MonsterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.Range);
            Assert.IsNotNull(result.Speed);
            Assert.IsNotNull(result.Defense);
            Assert.IsNotNull(result.Level);
        }

        [Test]
        public void MonsterModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new MonsterModel();
            result.ExperienceGiven = 600;
            result.Range = 7;
            result.Boss = false;
            result.ItemsDropped = "items";
            result.UniqueDrops = "unique";

            // Reset

            // Assert 
            Assert.AreEqual(600, result.ExperienceGiven);
            Assert.AreEqual(7, result.Range);
            Assert.AreEqual(false, result.Boss);
            Assert.AreEqual("items", result.ItemsDropped);
            Assert.AreEqual("unique", result.UniqueDrops);
        }

        [Test]
        public void MonsterModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new MonsterModel();
            dataOriginal.Range = 1;

            var dataNew = new MonsterModel();
            dataNew.Range = 2;

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Range);
        }

        [Test]
        public void MonsterModel_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var dataOriginal = new MonsterModel();
            dataOriginal.Range = 2;

            // Act
            var result = dataOriginal.Update(null);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Range);
        }

        [Test]
        public void MonsterModel_FormatOuput_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert 
            Assert.AreEqual("Name , Speed : 1 , Defense : 1 , Attack : 1 , Range : 1", result);
        }

        [Test]
        public void MonsterModel_ChangeLevel_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.ChangeLevel(10);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
            Assert.AreEqual(10, data.Level);
        }

        [Test]
        public void MonsterModel_ChangeLevel_LevelZero_Should_Fail()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.ChangeLevel(0);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MonsterModel_ChangeLevel_LevelTwentyOne_Should_Fail()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.ChangeLevel(21);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MonsterModel_Default_RollDamageDice_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = data.RollDamageDice();

            // Reset

            // Assert 
            Assert.AreEqual(1, result);
        }
    }
}
