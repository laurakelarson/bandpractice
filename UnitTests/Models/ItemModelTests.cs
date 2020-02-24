﻿using System;
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

        [Test]
        public void ItemModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();
            result.Value = 6;
            result.Range = 7;
            result.Damage = 8;
            result.Attribute = AttributeEnum.Attack;
            result.Location = ItemLocationEnum.Feet;

            // Reset

            // Assert 
            Assert.AreEqual(6, result.Value);
            Assert.AreEqual(7, result.Range);
            Assert.AreEqual(8, result.Damage);
            Assert.AreEqual(AttributeEnum.Attack, result.Attribute);
            Assert.AreEqual(ItemLocationEnum.Feet, result.Location);
        }

        [Test]
        public void ItemModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new ItemModel();
            dataOriginal.Value = 1;

            var dataNew = new ItemModel();
            dataNew.Value = 2;

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Value);
        }

        [Test]
        public void ItemModel_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var dataOriginal = new ItemModel();
            dataOriginal.Value = 2;

            // Act
            var result = dataOriginal.Update(null);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Value);
        }
    }
}