using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    ///  AttributeEnum tests. 
    /// </summary>
    [TestFixture]
    public class MenuItemEnumTests
    {
        // Confirm MenuItemEnum values set correctly 
        [Test]
        public void MenuItemEnumTests_Default_Values_Should_Pass()
        {
            // Arrange 

            // Act 
            var unknown = (int)MenuItemEnum.Unknown;
            var myBand = (int)MenuItemEnum.MyBand;
            var home = (int)MenuItemEnum.Home;
            var encyclopedia = (int)MenuItemEnum.Encyclopedia;
            var score = (int)MenuItemEnum.Score;
            var items = (int)MenuItemEnum.Items;
            var about = (int)MenuItemEnum.About;

            // Reset 

            // Assert
            Assert.AreEqual(0, unknown);
            Assert.AreEqual(1, myBand);
            Assert.AreEqual(2, home);
            Assert.AreEqual(3, encyclopedia);
            Assert.AreEqual(4, score);
            Assert.AreEqual(5, items);
            Assert.AreEqual(6, about); 
        }
    }
}
