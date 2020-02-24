using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    /// MonsterTypeEnum tests. 
    /// </summary>
    [TestFixture]
    public class MonsterTypeEnumTests
    {
        // Confirm enum values set correctly
        public void MonsterTypeEnumTests_Default_Values_Should_Pass()
        {
            // Arrange 

            // Act 
            var unknown = (int)MonsterTypeEnum.Unknown;
            var chomper = (int)MonsterTypeEnum.Chomper;
            var massiveStatic = (int)MonsterTypeEnum.MassiveStatic;
            var motoBeast = (int)MonsterTypeEnum.Motobeast;
            var kazoom = (int)MonsterTypeEnum.Kazoom;
            var panpot = (int)MonsterTypeEnum.Panpot;
            var jackhammer = (int)MonsterTypeEnum.Jackhammer;
            var brakez = (int)MonsterTypeEnum.Brakez;
            var driller = (int)MonsterTypeEnum.Driller;
            var alarmer = (int)MonsterTypeEnum.Alarmer;
            var shrillBabe = (int)MonsterTypeEnum.ShrillBabe;
            var buzzRowdy = (int)MonsterTypeEnum.BuzzRowdy;
            var piercingFeedback = (int)MonsterTypeEnum.PiercingFeedback;
            var franDrescher = (int)MonsterTypeEnum.FranDrescher;
            var yowlingFeline = (int)MonsterTypeEnum.YowlingFeline;
            var nickelBack = (int)MonsterTypeEnum.Nickelback;
            var lloydChristmas = (int)MonsterTypeEnum.LloydChristmas;
            var recorderApprentice = (int)MonsterTypeEnum.RecorderApprentice;
            var airhornLeviathan = (int)MonsterTypeEnum.AirhornLeviathan;
            var earsplittingChalkboard = (int)MonsterTypeEnum.EarsplittingChalkboard;
            var rubberChickenBlob = (int)MonsterTypeEnum.RubberChickenBlob;
            var agonizingSilence = (int)MonsterTypeEnum.AgonizingSilence;
            var gilbertGottfriend = (int)MonsterTypeEnum.GilbertGottfried;

            // Reset 

            // Assert
            Assert.AreEqual(0, unknown);
            Assert.AreEqual(1, chomper);
            Assert.AreEqual(2, massiveStatic);
            Assert.AreEqual(3, motoBeast);
            Assert.AreEqual(4, kazoom);
            Assert.AreEqual(5, panpot);
            Assert.AreEqual(6, jackhammer);
            Assert.AreEqual(7, brakez);
            Assert.AreEqual(8, driller);
            Assert.AreEqual(9, alarmer);
            Assert.AreEqual(10, shrillBabe);
            Assert.AreEqual(11, buzzRowdy);
            Assert.AreEqual(12, piercingFeedback);
            Assert.AreEqual(13, franDrescher);
            Assert.AreEqual(14, yowlingFeline);
            Assert.AreEqual(15, nickelBack);
            Assert.AreEqual(16, lloydChristmas);
            Assert.AreEqual(17, recorderApprentice);
            Assert.AreEqual(18, airhornLeviathan);
            Assert.AreEqual(19, earsplittingChalkboard);
            Assert.AreEqual(20, rubberChickenBlob);
            Assert.AreEqual(21, agonizingSilence);
            Assert.AreEqual(22, gilbertGottfriend);
        }
    }
}
