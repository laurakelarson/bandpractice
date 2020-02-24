using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;
using Game.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class CharacterModelTests
    {
        [Test]
        public void CharacterModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }
    }
}
