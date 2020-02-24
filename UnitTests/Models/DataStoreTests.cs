using System;
using System.Collections.Generic;
using System.Text;
using Game.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class DataStoreTests
    {
        [Test]
        public void DataStoreTests_Default_Unknown_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)DataStoreEnum.Unknown;

            // Reset 

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
