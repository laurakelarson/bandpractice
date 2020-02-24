using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Models
{
    [TestFixture]
    class ItemModelTests
    {
        [Test]
        public void ItemModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new ItemModel();
            dataNew.Value = 2;
            dataNew.Id = "oldID";

            // Act
            var result = new ItemModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        public void ItemModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.Value);
            Assert.IsNotNull(result.Range);
            Assert.IsNotNull(result.Damage);
            Assert.IsNotNull(result.Attribute);
            Assert.IsNotNull(result.Location);
        }

    }
}
