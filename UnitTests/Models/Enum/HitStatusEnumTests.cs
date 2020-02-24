using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    ///  HitStatusEnum tests. 
    /// </summary>
    [TestFixture]
    public class HitStatusEnumTests
    {
        // Confirm Unknown set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)HitStatusEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
