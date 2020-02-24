using System;
using System.Collections.Generic;
using System.Text;
using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    class CharacterModelTests
    {
        [Test]
        public void CharacterModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterModel_Constructor_New_Character_Should_Copy()
        {
            // Arrange
            var dataNew = new CharacterModel();
            dataNew.TotalExperience = 200;
            dataNew.Id = "oldID";

            // Act
            var result = new CharacterModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
            Assert.AreEqual(200, result.TotalExperience);
        }

        [Test]
        public void CharacterModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CharacterModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.TotalExperience);
            Assert.IsNotNull(result.Unlocked);
            Assert.IsNotNull(result.Type);
            Assert.IsNotNull(result.Level);
        }

        [Test]
        public void CharacterModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new CharacterModel();
            result.TotalExperience = 600;
            result.Unlocked = false;
            result.HeadItem = "head";
            result.FeetItem = "feet";
            result.NecklassItem = "body";
            result.PrimaryHandItem = "hand";
            result.OffHandItem = "offhand";
            result.RightFingerItem = "right";
            result.LeftFingerItem = "left";

            // Reset

            // Assert 
            Assert.AreEqual(600, result.TotalExperience);
            Assert.AreEqual(false, result.Unlocked);
            Assert.AreEqual("head", result.HeadItem);
            Assert.AreEqual("body", result.NecklassItem);
            Assert.AreEqual("feet", result.FeetItem);
            Assert.AreEqual("hand", result.PrimaryHandItem);
            Assert.AreEqual("offhand", result.OffHandItem);
            Assert.AreEqual("right", result.RightFingerItem);
            Assert.AreEqual("left", result.LeftFingerItem);

        }

        [Test]
        public void CharacterModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new CharacterModel();
            dataOriginal.TotalExperience = 1;

            var dataNew = new CharacterModel();
            dataNew.TotalExperience = 2;

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.TotalExperience);
        }

        [Test]
        public void CharacterModel_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var dataOriginal = new CharacterModel();
            dataOriginal.TotalExperience = 2;

            // Act
            var result = dataOriginal.Update(null);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.TotalExperience);
        }

        [Test]
        public void CharacterModel_FormatOuput_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert 
            Assert.AreEqual("Name , Type: Unknown, Alive: True, Level: 1, Experience: 0, Speed: 0, Defense: 0, Attack: 0, Current Health: 1, Max Health: 1", result);
        }

        [Test]
        public void CharacterModel_ChangeLevel_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            var result = data.ChangeLevel(10);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
            Assert.AreEqual(10, data.Level);
        }

        [Test]
        public void CharacterModel_ChangeLevel_LevelZero_Should_Fail()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            var result = data.ChangeLevel(0);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CharacterModel_ChangeLevel_LevelTwentyOne_Should_Fail()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            var result = data.ChangeLevel(21);

            // Reset

            // Assert 
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CharacterModel_Default_RollDamageDice_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            var result = data.RollDamageDice();

            // Reset

            // Assert 
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CharacterModel_Default_GetAttackValue_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            DiceHelper.ForceConstantRoll = true;
            DiceHelper.SetForcedDiceRollValue(1);
            var result = data.GetAttackValue(); // roll + level

            // Reset
            DiceHelper.ForceConstantRoll = false;

            // Assert 
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CharacterModel_LevelUp_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Level = 1;

            // Act
            var result = data.LevelUp();

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
            Assert.AreEqual(2, data.Level);
        }

        [Test]
        public void CharacterModel_AddExperienceLevelTwenty_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Level = 20;

            // Act
            var result = data.AddExperience(50000);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void CharacterModel_AddExperienceLevelOne_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.Level = 1;

            // Act
            var result = data.AddExperience(300);

            // Reset

            // Assert 
            Assert.AreEqual(true, result);
            Assert.AreEqual(2, data.Level);
        }
        #region RemoveItem tests
        [Test]
        public void CharacterModel_RemoveHeadItem_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.HeadItem = "head";

            // Act
            var result = ItemIndexViewModel.Instance.GetItem(data.HeadItem);

            var item = data.RemoveItem(ItemLocationEnum.Head);
            //var itemString = ItemListToStringConverter.Convert(item);

            // Reset

            // Assert 
            //Assert.AreEqual("head", result);
            Assert.IsNull(data.HeadItem);
        }

        [Test]
        public void CharacterModel_RemoveFeetItem_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.FeetItem = "feet";

            // Act
            var result = ItemIndexViewModel.Instance.GetItem(data.FeetItem);

            var item = data.RemoveItem(ItemLocationEnum.Feet);
            //var itemString = ItemListToStringConverter.Convert(item);

            // Reset

            // Assert 
            //Assert.AreEqual("feet", result);
            Assert.IsNull(data.FeetItem);
        }

        [Test]
        public void CharacterModel_RemoveNecklassItem_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.NecklassItem = "body";

            // Act
            var result = ItemIndexViewModel.Instance.GetItem(data.NecklassItem);

            var item = data.RemoveItem(ItemLocationEnum.Necklass);
            //var itemString = ItemListToStringConverter.Convert(item);

            // Reset

            // Assert 
            //Assert.AreEqual("body", result);
            Assert.IsNull(data.NecklassItem);
        }

        [Test]
        public void CharacterModel_RemovePrimaryHandItem_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.PrimaryHandItem = "hand";

            // Act
            var result = ItemIndexViewModel.Instance.GetItem(data.PrimaryHandItem);

            var item = data.RemoveItem(ItemLocationEnum.PrimaryHand);
            //var itemString = ItemListToStringConverter.Convert(item);

            // Reset

            // Assert 
            //Assert.AreEqual("hand", result);
            Assert.IsNull(data.PrimaryHandItem);
        }

        #endregion

    }
}
