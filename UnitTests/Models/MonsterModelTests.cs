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
    }
}
