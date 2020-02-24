using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    [TestFixture]
    public class EntityTypeEnumTests
    {
        // Confirm Unknown set to correct value 
        [Test]
        public void EntityTypeEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)EntityTypeEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }

        // Confirm Character set to correct value 
        [Test]
        public void EntityTypeEnumTests_Default_Character_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)EntityTypeEnum.Character;

            // Reset 

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
