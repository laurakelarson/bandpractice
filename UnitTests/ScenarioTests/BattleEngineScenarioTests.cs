using Game.Engine;
using Game.Models;
using Game.Models.Enum;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ScenarioTests
{
    [TestFixture]
    public class BattleEngineScenarioTests
    {
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new AutoBattleEngine();
        }

        [TearDown]
        public void TearDown()
        {
        }

        //  test constructor
        [Test]
        public void BattleEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattleEngine_Battle_No_Characters_Should_Fail()
        {
            /*
             * Try running a battle with no characters.
             */

            // Arrange

            // monsters will be added by engine

            // Act
            Engine.StartBattle(false);
            var Player = Engine.GetNextPlayerTurn();
            var result = Engine.TakeTurn(Player);

            // Reset
            Engine.MonsterList.Clear();
            Engine.EntityList.Clear();

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void BattleEngine_Battle_No_Monsters_Should_Fail()
        {
            /*
             * Try running a battle with no monsters.
             */

            // Arrange
            Engine.CharacterList.Add(new CharacterModel());

            Engine.MaxNumberMonsters = 0;

            // Act
            Engine.StartBattle(false);
            var Player = Engine.GetNextPlayerTurn();
            var result = Engine.TakeTurn(Player);

            // Reset
            Engine.CharacterList.Clear();
            Engine.EntityList.Clear();
            Engine.MaxNumberMonsters = 6;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void BattleEngine_Battle_Character_Level_Up_Should_Pass()
        {
            /* 
             * Test to force leveling up of a character during the battle
             * 
             * 1 Character
             * 
             * 1 Monster
             * 
             * Character continually attacks Monster until it dies
             * Character Should Level UP 1 level
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            // To See Level UP happening, a character needs to be close to the next level
            var Character = new CharacterModel
            {
                TotalExperience = 300,    // Enough for next level
                Name = "Level Up",
                Level = 1,
                Attack = 100,
                Speed = 1000,    // Go first
                Range = 100,      // Can attack anywhere on grid
                CurrentHealth = 100,
                MaxHealth = 100
            };

            Engine.CharacterList.Add(Character);

            Engine.MaxNumberMonsters = 1;

            Engine.StartBattle(false);

            var Monster = Engine.EntityList.Where(a => a.EntityType == EntityTypeEnum.Monster).FirstOrDefault();
            var Player = Engine.EntityList.Where(a => a.Id == Character.Id).FirstOrDefault();

            //Act
            while (Monster.Alive)
            {
                Engine.TurnAsAttack(Player, Monster);
            }

            //Reset
            Engine.MonsterList.Clear();
            Engine.CharacterList.Clear();
            Engine.EntityList.Clear();
            Engine.MaxNumberMonsters = 6;

            //Assert
            Assert.AreEqual(true, Player.Level != 1);
        }

        [Test]
        public void BattleEngine_GameOver_Round_1_Should_Pass()
        {
            /* 
             * Test to have character lose battle in first round
             * 
             * 1 Character
             *      1 HP
             * 
             * 1 Monster
             * 
             * Monster continually attacks Character until it dies
             * Game state should be game over
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            // To See Level UP happening, a character needs to be close to the next level
            var Character = new CharacterModel
            {
                Level = 20,
                CurrentHealth = 1,
                MaxHealth = 0
            };

            Engine.CharacterList.Add(Character);

            Engine.MaxNumberMonsters = 1;

            Engine.StartBattle(false);

            var Monster = Engine.EntityList.Where(a => a.EntityType == EntityTypeEnum.Monster).FirstOrDefault();
            var Player = Engine.EntityList.Where(a => a.Id == Character.Id).FirstOrDefault();

            //Act
            while (Player.Alive)
            {
                Engine.TurnAsAttack(Monster, Player);
            }

            var result = Engine.RoundNextTurn();

            //Reset
            Engine.MonsterList.Clear();
            Engine.CharacterList.Clear();
            Engine.EntityList.Clear();
            Engine.MaxNumberMonsters = 6;

            //Assert
            Assert.AreEqual(RoundEnum.GameOver, result);
        }

        [Test]
        public void BattleEngine_Characters_Win_Round_1_NewRound_Should_Pass()
        {
            /* 
             * Test to have character win the first round
             * 
             * 1 Character
             * 
             * 1 Monster
             * 
             * Character continually attacks Monster until it dies
             * Game state should indicate new round
             * 
             */

            //Arrange

            // Add Characters

            Engine.MaxNumberCharacters = 1;

            var Character = new CharacterModel
            {
                Level = 10,
                CurrentHealth = 200,
                MaxHealth = 200
            };

            Engine.CharacterList.Add(Character);

            Engine.MaxNumberMonsters = 1;

            Engine.StartBattle(false);

            var Monster = Engine.EntityList.Where(a => a.EntityType == EntityTypeEnum.Monster).FirstOrDefault();
            var Player = Engine.EntityList.Where(a => a.Id == Character.Id).FirstOrDefault();

            //Act
            while (Monster.Alive)
            {
                Engine.TurnAsAttack(Player, Monster);
            }

            var result = Engine.RoundNextTurn();

            //Reset
            Engine.MonsterList.Clear();
            Engine.CharacterList.Clear();
            Engine.EntityList.Clear();
            Engine.MaxNumberMonsters = 6;

            //Assert
            Assert.AreEqual(RoundEnum.NewRound, result);
        }

        [Test]
        public void BattleEngine_Monster_Dies_Item_Drop_Should_Pass()
        {
            /* 
             * Test to have character win the first round
             * 
             * 1 Character
             * 
             * 1 Monster
             * 
             * Character continually attacks Monster until it dies
             * Monster should drop at least one item
             * 
             */

            //Arrange

            // Add Character

            Engine.MaxNumberCharacters = 1;

            var Character = new CharacterModel
            {
                Level = 10,
                CurrentHealth = 200,
                MaxHealth = 200
            };

            Engine.CharacterList.Add(Character);

            Engine.MaxNumberMonsters = 1;

            // ensure item pool is clear
            Engine.ItemPool.Clear();

            Engine.StartBattle(false);

            var Monster = Engine.EntityList.Where(a => a.EntityType == EntityTypeEnum.Monster).FirstOrDefault();
            var Player = Engine.EntityList.Where(a => a.Id == Character.Id).FirstOrDefault();

            //Act
            while (Monster.Alive)
            {
                Engine.TurnAsAttack(Player, Monster);
            }

            var result = Engine.ItemPool.Count;

            //Reset
            Engine.MonsterList.Clear();
            Engine.CharacterList.Clear();
            Engine.EntityList.Clear();
            Engine.MaxNumberMonsters = 6;

            //Assert
            Assert.AreEqual(true, result > 0);
        }
    }
}
