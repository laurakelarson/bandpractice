﻿using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    ///  ItemLocationEnum tests. 
    /// </summary>
    [TestFixture]
    public class ItemLocationEnumTests
    {
        // Confirm Unknown set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }

        // Confirm Head set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_Head_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.Head;

            // Reset 

            // Assert
            Assert.AreEqual(10, result);
        }
    }
}
