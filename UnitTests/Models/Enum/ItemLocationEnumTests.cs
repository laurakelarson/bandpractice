using Game.Models;
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

        // Confirm Necklass set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_Necklass_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.Necklass;

            // Reset 

            // Assert
            Assert.AreEqual(12, result);
        }

        // Confirm Primary Hand set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_PrimaryHand_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.PrimaryHand;

            // Reset 

            // Assert
            Assert.AreEqual(20, result);
        }

        // Confirm Off Hand set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_OffHand_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.OffHand;

            // Reset 

            // Assert
            Assert.AreEqual(22, result);
        }

        // Confirm Finger set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_Finger_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.Finger;

            // Reset 

            // Assert
            Assert.AreEqual(30, result);
        }

        // Confirm RightFinger set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_RightFiner_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.RightFinger;

            // Reset 

            // Assert
            Assert.AreEqual(31, result);
        }

        // Confirm LeftFinger set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_LeftFinger_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.LeftFinger;

            // Reset 

            // Assert
            Assert.AreEqual(32, result);
        }

        // Confirm Feet set to correct value
        [Test]
        public void ItemLocationEnumTests_Default_Feet_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)ItemLocationEnum.Feet;

            // Reset 

            // Assert
            Assert.AreEqual(40, result);
        }
    }
}
