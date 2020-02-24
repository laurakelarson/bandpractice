using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    /// ItemTypeEnum unit tests
    /// </summary>
    [TestFixture]
    public class ItemTypeEnumTests
    {
        // Confirm Unknown set to correct value
        [Test]
        public void ItemTypeEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemTypeEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
