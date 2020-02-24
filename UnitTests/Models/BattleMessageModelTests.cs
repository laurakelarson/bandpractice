using Game.Models;
using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    [TestFixture]
    public class BattleMessageModelTests
    {
        public object PlayerTypeEnum { get; private set; }

        // Test Default constructor 
        [Test]
        public void BattleMessageModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleMessagesModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test default Gets
        [Test]
        public void BattleMessageModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleMessagesModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(EntityTypeEnum.Unknown, result.PlayerType);

            Assert.AreEqual(HitStatusEnum.Unknown, result.HitStatus);

            Assert.AreEqual(string.Empty, result.AttackerName);
            Assert.AreEqual(string.Empty, result.TargetName);
            Assert.AreEqual(string.Empty, result.AttackStatus);
            Assert.AreEqual(string.Empty, result.TurnMessage);
            Assert.AreEqual(string.Empty, result.TurnMessageSpecial);
            Assert.AreEqual(string.Empty, result.LevelUpMessage);

            Assert.AreEqual(0, result.DamageAmount);
            Assert.AreEqual(0, result.CurrentHealth);

            Assert.AreEqual(@"<html><body bgcolor=""#E8D0B6""><p>", result.htmlHead);
            Assert.AreEqual(@"</p></body></html>", result.htmlTail);
        }

        // Test GetSwingResult method
        [Test]
        public void BattleMessageModel_GetSwingResult_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();

            // Act
            var result = message.GetSwingResult();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test GetDamageMessage method
        [Test]
        public void BattleMessageModel_GetDamageMessage_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();

            // Act
            var result = message.GetDamageMessage();

            // Reset

            // Assert

            Assert.AreEqual(" for 0 damage ", result);
        }

        // Test GetTurnMessage method
        [Test]
        public void BattleMessageModel_GetTurnMessage_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();

            // Act
            var result = message.GetTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test GetCurrentHealthMessage
        [Test]
        public void BattleMessageModel_GetCurrentHealthMessage_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();

            // Act
            var result = message.GetCurrentHealthMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLBlankMessage 
        [Test]
        public void BattleMessageModel_GetHTMLBlankMessage_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();

            // Act
            var result = message.GetHTMLBlankMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLFormattedTurnMessage
        [Test]
        public void BattleMessageModel_GetHTMLFormattedTurnMessage_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();

            // Act
            var result = message.GetHTMLFormattedTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLFormattedTurnMessage with Monster entity type
        [Test]
        public void BattleMessageModel_GetHTMLFormattedTurnMessage_Monster_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();
            message.PlayerType = EntityTypeEnum.Monster;

            // Act
            var result = message.GetHTMLFormattedTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLFormattedTurnMessage with Character Entity Type
        [Test]
        public void BattleMessageModel_GetHTMLFormattedTurnMessage_Character_Default_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();
            message.PlayerType = EntityTypeEnum.Character;

            // Act
            var result = message.GetHTMLFormattedTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLFormattedTurnMessage with Miss HitStatusEnum type. 
        [Test]
        public void BattleMessageModel_GetHTMLFormattedTurnMessage_HitStatus_Miss_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();
            message.HitStatus = HitStatusEnum.Miss;

            // Act
            var result = message.GetHTMLFormattedTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLFormattedMessage with Hit HitStatusEnum type
        [Test]
        public void BattleMessageModel_GetHTMLFormattedTurnMessage_HitStatus_Hitf_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();
            message.HitStatus = HitStatusEnum.Hit;

            // Act
            var result = message.GetHTMLFormattedTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        // Test for GetHTMLFormattedTurnMessage for Critical Hit
        [Test]
        public void BattleMessageModel_GetHTMLFormattedTurnMessage_HitStatus_CriticalHit_Should_Pass()
        {
            // Arrange
            var message = new BattleMessagesModel();
            message.HitStatus = HitStatusEnum.CriticalHit;

            // Act
            var result = message.GetHTMLFormattedTurnMessage();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
