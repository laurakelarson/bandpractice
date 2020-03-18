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


    }
}
