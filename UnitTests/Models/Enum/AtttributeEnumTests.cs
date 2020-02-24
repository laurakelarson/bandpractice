using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    ///  AttributeEnum tests. 
    /// </summary>
    [TestFixture]
    public class AtttributeEnumTests
    {
        // Confirm Unknown set to correct value 
        [Test]
        public void AttributeEnumTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)AttributeEnum.Unknown; 

            // Reset 

            // Assert
            Assert.AreEqual(0, result); 
        }

        // Confirm Speed set to correct value 
        [Test]
        public void AttributeEnumTests_Default_Speed_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)AttributeEnum.Speed;

            // Reset 

            // Assert
            Assert.AreEqual(10, result);
        }

        // Confirm Defense set to correct value 
        [Test]
        public void AttributeEnumTests_Default_Defense_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)AttributeEnum.Defense;

            // Reset 

            // Assert
            Assert.AreEqual(12, result);
        }

        // Confirm Attack set to correct value 
        [Test]
        public void AttributeEnumTests_Default_Attack_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)AttributeEnum.Attack;

            // Reset 

            // Assert
            Assert.AreEqual(14, result);
        }

        // Confirm CurrentHealth set to correct value 
        [Test]
        public void AttributeEnumTests_Default_CurrentHealth_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)AttributeEnum.CurrentHealth;

            // Reset 

            // Assert
            Assert.AreEqual(16, result);
        }

        // Confirm MaxHealth set to correct value 
        [Test]
        public void AttributeEnumTests_Default_MaxHealth_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)AttributeEnum.MaxHealth;

            // Reset 

            // Assert
            Assert.AreEqual(18, result);
        }
    }
}
