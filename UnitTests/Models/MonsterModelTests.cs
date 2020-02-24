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
    }
}
