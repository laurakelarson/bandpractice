using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    ///  CharacterTypeEnum tests. 
    /// </summary>
    [TestFixture]
    public class CharacterTypeEnumTests
    {
        // Confirm Unknown set to correct value
        [Test]
        public void CharacterTypeEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)CharacterTypeEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }

        // Confirm TambourinePlayer set to correct value
        [Test]
        public void CharacterTypeEnumTests_Default_TambourinePlayer_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)CharacterTypeEnum.TambourinePlayer;

            // Reset 

            // Assert
            Assert.AreEqual(1, result);
        }

        // Confirm Bassist set to correct value
        [Test]
        public void CharacterTypeEnumTests_Default_Bassist_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)CharacterTypeEnum.Bassist;

            // Reset 

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
