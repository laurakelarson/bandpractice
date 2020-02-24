using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    /// <summary>
    /// Unit tests for BaseModel class. 
    /// </summary>
    [TestFixture]
    public class BaseModelTests
    {
        [Test]
        public void BaseModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseModel<ItemModel>();

            // Reset

            // Assert
            Assert.AreEqual("Name", result.Name);
            Assert.AreEqual("Description", result.Description); 
        }
    }
}
