using Game.Engine;
using Game.Helpers;
using Game.Models;
using Game.Models.Enum;
using Game.ViewModels;
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

        // case where there is no monster to select
        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange
            var MonsterModel = new MonsterModel();
            Engine.MonsterList = new List<MonsterModel>();

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        // case where monster list is null
        [Test]
        public void TurnEngine_SelectMonsterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange

            // Remember the List
            var saveList = Engine.MonsterList;

            Engine.MonsterList = null;

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.MonsterList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        // case where there is a monster to select
        [Test]
        public void TurnEngine_SelectMonsterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange
            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(new MonsterModel());

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }

        #endregion Attack

        #region Mechanics

        // test roll to hit target results in Hit
        [Test]
        public void TurnEngine_RolltoHitTarget_Hit_Should_Pass()
        {
            // Arrange
            var AttackScore = 10;
            var DefenseScore = 0;

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(3); // Always roll a 3.

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.EnableRandomValues();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        // case where roll results in miss
        [Test]
        public void TurnEngine_RolltoHitTarget_Miss_Should_Pass()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(2);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.EnableRandomValues();

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        // test forced roll of 1
        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_1_Should_Miss()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(1);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.EnableRandomValues();

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        // test forced roll of 20
        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_20_Should_Hit()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.EnableRandomValues();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        // test character taking a turn
        [Test]
        public void TurnEngine_TakeTurn_Default_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.Id = "me";
            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);
            Engine.MakeEntityList();

            // Act
            var result = Engine.TakeTurn(Engine.EntityList
                .Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(true, result);
        }

        // case where no items to drop
        [Test]
        public void TurnEngine_DropItems_No_Items_Should_Return_0()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.Id = "me";
            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);
            Engine.MakeEntityList();

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(0);

            // Act
            var result = Engine.DropItems(Engine.EntityList
                .Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            DiceHelper.EnableRandomValues();
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(0, result);
        }

        // case where character has two items
        [Test]
        public void TurnEngine_DropItems_Character_Items_2_Should_Return_2()
        {
            // Arrange
            var Character = new CharacterModel
            {
                HeadItem = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
                FeetItem = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
                Id = "me"
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);
            Engine.MakeEntityList();

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(0);

            // Act
            var result = Engine.DropItems(Engine.EntityList
                .Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            DiceHelper.EnableRandomValues();
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(2, result);
        }

        // test random drop
        [Test]
        public void TurnEngine_DropItems_Monster_Items_0_Random_Drop_1_Should_Return_1()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.Id = "me";
            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);
            Engine.MakeEntityList();

            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(1);

            // Act
            var result = Engine.DropItems(Engine.EntityList
                .Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            DiceHelper.EnableRandomValues();
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(1, result);
        }

        #endregion Mechanics

        #region Death

        // case where character dies
        [Test]
        public void TurnEngine_TargetDied_Character_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.Id = "me";
            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);
            Engine.MakeEntityList();

            // Act
            var result = Engine.TargetDied(Engine.EntityList
                .Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(true, result);
        }

        // case where monster dies
        [Test]
        public void TurnEngine_TargetDied_Monster_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            Monster.Id = "me";
            Engine.CharacterList.Clear();
            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);
            Engine.MakeEntityList();

            // Act
            var result = Engine.TargetDied(Engine.EntityList
                .Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(true, result);
        }

        // try removing a Monster that is not dead
        [Test]
        public void TurnEngine_RemoveIfDead_Alive_True_Should_Return_False()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                CurrentHealth = 1,
                Alive = true,
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);
            Engine.MakeEntityList();

            // Act
            var result = Engine.RemoveIfDead(Engine.EntityList.
                Where(a => a.Id == "me").FirstOrDefault());

            // Reset
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(false, result);
        }

        // case that monster is dead
        [Test]
        public void TurnEngine_RemoveIfDead_Dead_true_Should_Return_true()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                CurrentHealth = 0,
                Alive = false,
                Id = "me"
            };

            var BattleMonster = new BattleEntityModel(Monster);

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);
            //        Engine.MakeEntityList();
            Engine.EntityList.Add(BattleMonster);

            // Act
            var result = Engine.RemoveIfDead(BattleMonster);

            // Reset
            Engine.StartBattle(false);

            // Assert
            Assert.AreEqual(true, result);
        }

        #endregion Death

        #region TurnAsAttack

        // case where character tries to attack null
        [Test]
        public void TurnEngine_TurnAsAttack_Character_Attacks_Null_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel();
            Engine.CharacterList.Add(Character);

            var Monster = new MonsterModel();
            Engine.MonsterList.Add(Monster);

            Engine.MakeEntityList();

            // Act
            var result = Engine.TurnAsAttack(
                Engine.EntityList.First(a => a.Id == Character.Id), null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        #endregion TurnAsAttack

    }
}
