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
        // Constructor test 
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

        // Test BaseModel Set 
        [Test]
        public void BaseModel_Set_Default_Should_Pass()
        {
            // Arrange
            var result = new BaseModel<ItemModel>();

            // Act
            result.Id = "bogus";
            result.ImageURI = "uri";

            // Reset

            // Assert
            Assert.AreEqual("bogus", result.Id);
            Assert.AreEqual("uri", result.ImageURI);
        }

        // Test BaseModel update. 
        [Test]
        public void BaseModel_Update_Default_Should_Pass()
        {
            // Arrange
            var data = new BaseModel<ItemModel>();
            var name = data.Name; 

            // Act
            data.Update(null);

            // Reset

            // Assert
            Assert.AreEqual(name, data.Name);
        }
    }
}
