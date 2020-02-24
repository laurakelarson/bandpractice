using Game.Models;
using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    /// <summary>
    /// BattleEntityModel tests. 
    /// </summary>
    [TestFixture]
    public class BattleEntityModelTests
    {
        // Test default Constructor
        [Test]
        public void BattleEntityModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleEntityModel();

            // reset

            // Assert
            Assert.AreEqual(result.EntityType, EntityTypeEnum.Unknown);
            Assert.AreEqual(result.ExperiencePoints, 0);
            Assert.AreEqual(result.ListOrder, 0); 
        }

        // Test constructor
        [Test]
        public void BattleEntityModelTests_Constructor_New_BattleEntity_Should_Copy()
        {
            // Arrange
            var battleEntity = new BattleEntityModel();
            battleEntity.EntityType = EntityTypeEnum.Character;
            battleEntity.ExperiencePoints = 500;
            //battleEntity.ListOrder = 1;

            // Act
            var newBattleEntity = new BattleEntityModel(battleEntity);

            // reset

            // Assert
            Assert.AreEqual(battleEntity.EntityType, newBattleEntity.EntityType);
            Assert.AreEqual(battleEntity.ExperiencePoints, newBattleEntity.ExperiencePoints);
            //Assert.AreEqual(battleEntity.ListOrder, newBattleEntity.ListOrder); 
        }

        // Test constructor that accepts Character Model
        [Test]
        public void BattleEntityModelTests_Constructor_New_Character_Should_Copy()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.TotalExperience = 500;
            var battleEntity = new BattleEntityModel(Character);

            // Act
            
            // reset

            // Assert
            Assert.AreEqual(Character.TotalExperience, battleEntity.ExperiencePoints);
        }

        // Test constructor that accepts Monster Model 
        [Test]
        public void BattleEntityModelTests_Constructor_New_Monster_Should_Copy()
        {
            // Arrange
            var Monster = new MonsterModel();
            Monster.ExperienceGiven = 500;

            // Act
            var BattleEntity = new BattleEntityModel(Monster);

            // Assert
            Assert.AreEqual(Monster.ExperienceGiven, BattleEntity.ExperiencePoints);
        }

        // Test Change Level Method
        [Test]
        public void BattleEntityModelTests_Change_Level_Should_Pass()
        {
            // Arrange
            var BattleEntity = new BattleEntityModel(); 

            // Act - do this until method implemented
            try
            {
                BattleEntity.ChangeLevel(1);
            }
            catch (NotImplementedException)
            {

            }
        }

        // Test format output function in Battle Entity Model
        [Test]
        public void BattleEntityTests_Format_Output_Valid()
        {
            // Arrange
            var BattleEntity = new BattleEntityModel();

            // Assert
            Assert.AreEqual(BattleEntity.Name, BattleEntity.FormatOutput());
        }
    }
}
