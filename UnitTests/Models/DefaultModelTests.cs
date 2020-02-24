using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Game.Models;

namespace UnitTests.Models
{
    class DefaultModelTests
    {
        [Test]
        public void DefaultModel_Default_Constructor_Should_Pass()
        {
            // Arrange
            var data = new DefaultModel();
            // Act

            // Reset

            // Assert 
            Assert.IsNotNull(data);
        }

        [Test]
        public void DefaultModel_Constructor_Should_Pass()
        {
            // Arrange
            var data = new DefaultModel
            {
                Name = "name",
                Description = "desc",
                Id = "id"
            };
            
            // Act

            // Reset

            // Assert 
            Assert.AreEqual("name", data.Name);
            Assert.AreEqual("desc", data.Description);
            Assert.AreEqual("id", data.Id);
        }
    }
}
