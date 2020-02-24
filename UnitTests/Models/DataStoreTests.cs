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

        [Test]
        public void DataStoreTests_Default_SQL_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)DataStoreEnum.SQL;

            // Reset 

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void DataStoreTests_Default_Mock_Should_Pass()
        {
            // Arrange 

            // Act 
            var result = (int)DataStoreEnum.Mock;

            // Reset 

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
