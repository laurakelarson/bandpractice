using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    [TestFixture]
    public class CharacterTypeEnumTests
    {
        [Test]
        public void CharacterTypeEnumTests_Default_Unknown_Should_Pass()
        {
            var result = (int)CharacterTypeEnum.Unknown;
            Assert.AreEqual(0, result);
        }
    }
}
