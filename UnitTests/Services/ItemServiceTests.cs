﻿using Game.Models;
using Game.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    [TestFixture]
    public class ItemServiceTests
    {
        // Setup
        [SetUp]
        public void Setup()
        {
            Game.Helpers.DataSetsHelper.WarmUp();
        }

        // Tear down
        [TearDown]
        public async Task TearDown()
        {
            await Game.Helpers.DataSetsHelper.WipeData();
        }

        // Test Contstructor
        [Test]
        public void ItemService_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemService.DefaultImageURI;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test getting group 1 items from service 
        [Test]
        public async Task ItemService_GetItemsFromServerGetAsync_Valid_1_Should_Pass()
        {
            // Arrange

            // Act
            var result = await ItemService.GetItemsFromServerGetAsync(1);

            // Reset

            // Assert
            Assert.AreEqual(true, result.Count == 2);
            Assert.AreEqual("Strong Shield", result[0].Name);
        }

        // Test post request for group 1 items from service 
        [Test]
        public async Task ItemService_GetItemsFromServerPostAsync_Valid_1_Should_Pass()
        {
            // Arrange
            var number = 1;

            var level = 6;  // Max Value of 6
            var attribute = AttributeEnum.Unknown;  // Any Attribute
            var location = ItemLocationEnum.Unknown;    // Any Location
            var random = true;  // Random between 1 and Level
            var updateDataBase = true;  // Add them to the DB
            var category = 0;   // What category to filter down to, 0 is all

            // will return shoes value 10 of speed.

            // Act
            var result = await ItemService.GetItemsFromServerPostAsync(number, level, attribute, location, category, random, updateDataBase);

            // Reset

            // Assert
            Assert.AreEqual(true, result.Count == 1);
        }

        // Test get request for group 10 items from service 
        [Test]
        public async Task ItemService_GetItemsFromServerPostAsync_Valid_10_Should_Pass()
        {
            // Arrange
            var number = 10;

            var level = 6;  // Max Value of 6
            var attribute = AttributeEnum.Unknown;  // Any Attribute
            var location = ItemLocationEnum.Unknown;    // Any Location
            var random = true;  // Random between 1 and Level
            var updateDataBase = true;  // Add them to the DB
            var category = 0;   // What category to filter down to, 0 is all

            // will return shoes value 10 of speed.

            // Act
            var result = await ItemService.GetItemsFromServerPostAsync(number, level, attribute, location, category, random, updateDataBase);

            // Reset

            // Assert
            Assert.AreEqual(true, result.Count == 10);
        }
    }
}
