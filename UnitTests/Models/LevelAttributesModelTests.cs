using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class LevelAttributesModelTests
    {
        [Test]
        public void LevelAttributesModel_Constructor_Should_Pass()
        {
            // Arrange

            // Act
            var result = new LevelAttributesModel(1, 1, 1, 1, 1, 1);

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }
    }
}
