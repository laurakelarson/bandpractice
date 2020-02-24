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

        // Confirm Keyboardist set to correct value
        [Test]
        public void CharacterTypeEnumTests_Default_Keyboardist_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)CharacterTypeEnum.Keyboardist;

            // Reset 

            // Assert
            Assert.AreEqual(3, result);
        }

        // Confirm Drummer set to correct value
        [Test]
        public void CharacterTypeEnumTests_Default_Drummer_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)CharacterTypeEnum.Drummer;

            // Reset 

            // Assert
            Assert.AreEqual(4, result);
        }

        // Confirm Guitarist set to correct value
        [Test]
        public void CharacterTypeEnumTests_Default_Guitarist_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)CharacterTypeEnum.Guitarist;

            // Reset 

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
