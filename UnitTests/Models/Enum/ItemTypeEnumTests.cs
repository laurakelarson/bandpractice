using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models.Enum
{
    /// <summary>
    /// ItemTypeEnum unit tests
    /// </summary>
    [TestFixture]
    public class ItemTypeEnumTests
    {
        // Confirm Unknown set to correct value
        [Test]
        public void ItemTypeEnumTests_Default_Values_Should_Pass()
        {
            // Arrange 
            var unknown = (int)ItemTypeEnum.Unknown;
            var earplugs = (int)ItemTypeEnum.Earplugs;
            var earmuffs = (int)ItemTypeEnum.Earmuffs;
            var noiseCancellingHeadphones = (int)ItemTypeEnum.NoiseCancelingHeadphones;
            var microphone = (int)ItemTypeEnum.Microphone;
            var coffee = (int)ItemTypeEnum.Coffee;
            var energyDrink = (int)ItemTypeEnum.EnergyDrink;
            var metronome = (int)ItemTypeEnum.Metronome;
            var tuningFork = (int)ItemTypeEnum.TuningFork;
            var bandTShirt = (int)ItemTypeEnum.BandTshirt;
            var bandHoodie = (int)ItemTypeEnum.BandHoodie;
            var coolOutfit = (int)ItemTypeEnum.CoolOutfit;
            var ring = (int)ItemTypeEnum.Ring;
            var moodRing = (int)ItemTypeEnum.MoodRing;
            var temporaryTattoo = (int)ItemTypeEnum.TemporaryTattoo;
            var athleticSocks = (int)ItemTypeEnum.AthleticSocks;
            var luckySocks = (int)ItemTypeEnum.LuckySocks;
            var comfySneakers = (int)ItemTypeEnum.ComfySneakers;
            var bunnySlippers = (int)ItemTypeEnum.BunnySlippers;
            var triangle = (int)ItemTypeEnum.Triangle;
            var prankDoorbell = (int)ItemTypeEnum.PrankDoorbell;
            var whoopieCushion = (int)ItemTypeEnum.WhoopeeCushion;
            var vuvuzela = (int)ItemTypeEnum.Vuvuzela;
            var ocarina = (int)ItemTypeEnum.Ocarina;
            var bagpipe = (int)ItemTypeEnum.Bagpipe;
            var banjo = (int)ItemTypeEnum.Banjo;
            var keytar = (int)ItemTypeEnum.Keytar;
            var goldenRecorder = (int)ItemTypeEnum.GoldenRecorder;
            var rockOck = (int)ItemTypeEnum.RockOck;
            var glockenspiel = (int)ItemTypeEnum.Glockenspiel;
            var theremin = (int)ItemTypeEnum.Theremin;
            var didgeridooOfDestruction = (int)ItemTypeEnum.DidgeridooOfDestruction;

            // Act 

            // Reset 

            // Assert
            Assert.AreEqual(0, unknown);
            Assert.AreEqual(1, earplugs);
            Assert.AreEqual(2, earmuffs);
            Assert.AreEqual(3, noiseCancellingHeadphones);
            Assert.AreEqual(4, microphone);
            Assert.AreEqual(5, coffee);
            Assert.AreEqual(6, energyDrink);
            Assert.AreEqual(7, metronome);
            Assert.AreEqual(8, tuningFork);
            Assert.AreEqual(9, bandTShirt);
            Assert.AreEqual(10, bandHoodie);
            Assert.AreEqual(11, coolOutfit);
            Assert.AreEqual(12, ring);
            Assert.AreEqual(13, moodRing);
            Assert.AreEqual(14, temporaryTattoo);
            Assert.AreEqual(15, athleticSocks);
            Assert.AreEqual(16, luckySocks);
            Assert.AreEqual(17, comfySneakers);
            Assert.AreEqual(18, bunnySlippers);
            Assert.AreEqual(19, triangle);
            Assert.AreEqual(20, prankDoorbell);
            Assert.AreEqual(21, whoopieCushion);
            Assert.AreEqual(22, vuvuzela);
            Assert.AreEqual(23, ocarina);
            Assert.AreEqual(24, bagpipe);
            Assert.AreEqual(25, banjo);
            Assert.AreEqual(26, keytar);
            Assert.AreEqual(27, goldenRecorder);
            Assert.AreEqual(28, rockOck);
            Assert.AreEqual(29, glockenspiel);
            Assert.AreEqual(30, theremin);
            Assert.AreEqual(31, didgeridooOfDestruction);
        }
    }
}
