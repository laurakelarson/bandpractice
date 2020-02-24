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
        public void HitStatusEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)HitStatusEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }

        // Confirm Miss set to correct value
        [Test]
        public void HitStatusEnumTests_Default_Miss_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)HitStatusEnum.Miss;

            // Reset 

            // Assert
            Assert.AreEqual(1, result);
        }

        // Confirm Critical Miss set to correct value
        [Test]
        public void HitStatusEnumTests_Default_CriticalMiss_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)HitStatusEnum.CriticalMiss;

            // Reset 

            // Assert
            Assert.AreEqual(10, result);
        }

        // Confirm Hit set to correct value
        [Test]
        public void HitStatusEnumTests_Default_Hit_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)HitStatusEnum.Hit;

            // Reset 

            // Assert
            Assert.AreEqual(5, result);
        }

        // Confirm CriticalHit set to correct value
        [Test]
        public void HitStatusEnumTests_Default_CriticalHit_Should_Pass()
        {
            // Arrange 

            // Act
            var result = (int)HitStatusEnum.CriticalHit;

            // Reset 

            // Assert
            Assert.AreEqual(15, result);
        }

        // Confirm message for Unknown is correct
        [Test]
        public void HitStatusEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        // Confirm message for Hit is correct
        [Test]
        public void HitStatusEnumExtensionsTests_Hit_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.Hit.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" hits ", result);
        }

        // Confirm message for CriticalHit is correct
        [Test]
        public void HitStatusEnumExtensionsTests_CriticalHit_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnum.CriticalHit.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual(" hits really hard ", result);
        }
    }
}
