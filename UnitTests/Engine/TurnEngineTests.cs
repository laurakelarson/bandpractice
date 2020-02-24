﻿using Game.Engine;
using Game.Models;
using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Engine
{
    /// <summary>
    /// Unit tests for TurnEngine class
    /// </summary>
    [TestFixture]
    public class TurnEngineTests
    {
        // BattleEngine to use
        BattleEngine Engine;

        [SetUp]
        public void SetUp()
        {
            Engine = new BattleEngine();
            Engine.StartBattle(false);  // refresh state
        }

        [TearDown]
        public void TearDown()
        {
        }

        // test constructor
        [Test]
        public void TurnEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        #region Attack

        // case where there is a character but no monsters
        [Test]
        public void TurnEngine_Attack_Valid_Empty_Monster_List_Should_Fail()
        {
            // Arrange
            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(new CharacterModel());
            Engine.MonsterList.Clear();

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act
            var result = Engine.Attack(Engine.EntityList
                .Where(m => m.EntityType == EntityTypeEnum.Character).FirstOrDefault());

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result); // should be false since no monster to attack
        }

        // case where there is a monster but no character to attack
        [Test]
        public void TurnEngine_Attack_Valid_Empty_Character_List_Should_Fail()
        {
            // Arrange
            Engine.CharacterList.Clear();
            Engine.MonsterList.Add(new MonsterModel());
            Engine.CharacterList.Clear();

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act
            var result = Engine.Attack(Engine.EntityList
                .Where(m => m.EntityType == EntityTypeEnum.Monster).FirstOrDefault());

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result); // should be false since there's no one to attack
        }

        // case where trying to select a character from empty character list
        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange
            var CharacterModel = new CharacterModel();
            Engine.CharacterList = new List<CharacterModel>();

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        // case where character list is null
        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange
            var CharacterModel = new CharacterModel();

            // Remember the List
            var saveList = Engine.CharacterList;

            Engine.CharacterList = null;

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset
            Engine.CharacterList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        // case where there is a character to select
        [Test]
        public void TurnEngine_SelectCharacterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange
            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(new CharacterModel());

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }

        #endregion Attack

    }
}
