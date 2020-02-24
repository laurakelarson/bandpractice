using Game.Engine;
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
    /// Unit tests for the RoundEngine class
    /// </summary>
    [TestFixture]
    public class RoundEngineTests
    {
        // BattleEngine for testing
        BattleEngine Engine;

        // Create a new BattleEngine and StartBattle
        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.StartBattle(false); // trigger new round
        }

        [TearDown]
        public void TearDown()
        {
        }

        // Test constructor
        [Test]
        public void RoundEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        #region Sort order

        // test that EntityList order is correct
        [Test]
        public void RoundEngine_OrderEntityListByTurnOrder_Speed_Higher_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceGiven = 1000,
                Name = "Z",
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "C",
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("me", result[0].Id);
        }

        // test sort order by level in case where Speed is equal
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Level_Higher_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceGiven = 1000,
                Name = "Z",
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "C",
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("me", result[0].Id);
        }

        // test sort order when speed and level are equal
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Experience_Higher_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceGiven = 1000,
                Name = "Z",
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "C",
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("me", result[0].Id);
        }

        // test case where sort is broken by entity type (character before monster)
        [Test]
        public void RoundEngine_OrderPlayerListByType_EntityType_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceGiven = 1,
                Name = "Z",
                Id = "me"
            };

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(Monster);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "C",
                Id = "c"
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("c", result[0].Id);
        }


        // test sort order when sort is broken by name
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Name_A_Z_Should_Pass()
        {
            // Arrange
            Engine.MonsterList.Clear();
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                TotalExperience = 1,
                Name = "Z",
                Id = "me"
            };

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            Character = new CharacterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 2,
                TotalExperience = 1,
                Name = "ZZ",
                Id = "c"
            };

            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EntityList = Engine.EntityList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.OrderEntityListByTurnOrder();

            // Resets

            // Assert
            Assert.AreEqual("me", result[0].Id);
        }

        #endregion Sort order

        #region Item swaps

        // check that item swap works when location is empty
        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_Location_Empty_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Z",
                Id = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Feet };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Feet };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.ItemPool.Add(item1);
            Engine.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.HeadItem = null;

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act

            var result = Engine.GetItemFromPoolIfBetter(Character, ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, Character.FeetItem);    // The 2nd item is better, so did they swap?
        }

        // check item swap when better item is in pool
        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_Head_Better_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Z",
                Id = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Head };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Head };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            Engine.ItemPool.Add(item1);
            Engine.ItemPool.Add(item2);

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.Head, item1);

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act

            var result = Engine.GetItemFromPoolIfBetter(Character, ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(item2.Id, Character.HeadItem);    // The 2nd item is better, so did they swap?
        }

        // case when item pool is empty
        [Test]
        public async Task RoundEngine_GetItemFromPoolIfBetter_Pool_Empty_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Z",
                Id = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Head };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Head };

            await ItemIndexViewModel.Instance.CreateAsync(item1);
            await ItemIndexViewModel.Instance.CreateAsync(item2);

            // Don't add items to battle engine pool

            // Put the Item on the Character
            Character.AddItem(ItemLocationEnum.Head, item2);

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act

            var result = Engine.GetItemFromPoolIfBetter(Character, ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        // test for default PickupItemsFromPool
        [Test]
        public async Task RoundEngine_PickupItemsFromPool_Default_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Z",
                Id = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act

            var result = Engine.PickupItemsFromPool(Character);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        #endregion Item swaps

        #region Round management

        // default case for EndRound
        [Test]
        public void RoundEngine_EndRound_Default_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Z",
                Id = "me"
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.CharacterList.Clear();
            Engine.CharacterList.Add(Character);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act
            var result = Engine.EndRound();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        // case where game is over because there are no alive characters
        [Test]
        public void RoundEngine_RoundNextTurn_No_Characters_Should_Return_GameOver()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Character"
            };

            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceGiven = 1,
                Name = "Monster",
            };

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            Engine.CharacterList.Clear();

            // Don't add character to battle
            //Engine.CharacterList.Add(new PlayerInfoModel(Character));

            Engine.MonsterList.Add(Monster);

            // Make the List
            Engine.EntityList = Engine.MakeEntityList();

            // Act
            var result = Engine.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.GameOver, result);
        }


        #endregion Round management
    }
}
