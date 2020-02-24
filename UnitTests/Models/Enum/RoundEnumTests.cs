using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    ///  RoundEnum tests. 
    /// </summary>
    [TestFixture]
    public class RoundEnumTests
    {
        // Confirm enum entries set to correct default values
        [Test]
        public void RoundTypeEnumTests_Default_Values_Should_Pass()
        {
            // Arrange 
            var unknown = (int)RoundEnum.Unknown;
            var nextTurn = (int)RoundEnum.NextTurn;
            var newRound = (int)RoundEnum.NewRound;
            var gameOver = (int)RoundEnum.GameOver;

            // Act 

            // Reset 

            // Assert
            Assert.AreEqual(0, unknown);
            Assert.AreEqual(1, nextTurn);
            Assert.AreEqual(2, newRound);
            Assert.AreEqual(3, gameOver); 
        }
    }
}
