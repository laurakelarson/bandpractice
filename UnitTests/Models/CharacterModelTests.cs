using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;
using Game.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class CharacterModelTests
    {
        [Test]
        public void CharacterModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterModel_Constructor_New_Character_Should_Copy()
        {
            // Arrange
            var dataNew = new CharacterModel();
            dataNew.TotalExperience = 200;
            dataNew.Id = "oldID";

            // Act
            var result = new CharacterModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
            Assert.AreEqual(200, result.TotalExperience);
        }

        [Test]
        public void CharacterModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.TotalExperience);
            Assert.IsNotNull(result.Unlocked);
            Assert.IsNotNull(result.Type);
            Assert.IsNotNull(result.Level);
        }
    }
}
