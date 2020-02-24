using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    [TestFixture]
    public class AtttributeEnumTests
    {
        [Test]
        public void AttributeEnumTests_Default_Unknown_Should_Pass()
        {
            var result = (int)AttributeEnum.Unknown; 
            Assert.AreEqual(0, result); 
        }

        [Test]
        public void AttributeEnumTests_Default_Speed_Should_Pass()
        {
            var result = (int)AttributeEnum.Speed;
            Assert.AreEqual(10, result);
        }
    }
}
