using Game.Models;
using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    /// <summary>
    /// BattleEntityModel tests. 
    /// </summary>
    [TestFixture]
    public class BattleEntityModelTests
    {
        // Test default Constructor
        public void BattleEntityModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleEntityModel();

            // reset

            // Assert
            Assert.AreEqual(result.EntityType, EntityTypeEnum.Unknown);
            Assert.AreEqual(result.ExperiencePoints, 0);
            Assert.AreEqual(result.ListOrder, 0); 
        }
    }
}
