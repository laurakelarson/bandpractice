﻿using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;

namespace UnitTests.ScenarioTests
{
    [TestFixture]
    class Hackathon
    {
        BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        AutoBattleEngine AutoBattleEngine;
        BattleEngine BattleEngine;

        [SetUp]
        public void Setup()
        {
            AutoBattleEngine = new AutoBattleEngine();
            BattleEngine = EngineViewModel.Engine;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void HackathonScenario_Constructor_0_Default_Should_Pass()
        {
            // Arrange

            // Act

            // Assert


            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_1_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            AutoBattleEngine.MaxNumberCharacters = 1;
            AutoBattleEngine.CharacterList.Clear();

            var CharacterPlayerMike = new CharacterModel
            {
                Speed = -1, // Will go last...
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Mike"
            };

            AutoBattleEngine.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions
            AutoBattleEngine.MaxNumberMonsters = 20;
            var StrongMonster = new MonsterModel
            {
                Speed = 10000,
                Level = 20,
                Attack = 1000
            };

            AutoBattleEngine.MonsterList.Add(StrongMonster);

            // Auto Battle will add the monsters


            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset
            AutoBattleEngine.MaxNumberMonsters = 6;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, AutoBattleEngine.EntityList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, AutoBattleEngine.Score.RoundCount);
        }

        [Test]
        public async Task HackathonScenario_Scenario_2_Character_Bob_Should_Miss()
        {
            /* 
             * Scenario Number:  
             *  2
             *  
             * Description: 
             *      Make a Character called Bob
             *      Bob Always Misses
             *      Other Characters Always Hit
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Change to Turn Engine
             *      Changed TurnAsAttack method
             *      Check for Name of Bob and return miss
             *                 
             * Test Algrorithm:
             *  Create Character named Bob
             *  Create Monster
             *  Call TurnAsAttack
             * 
             * Test Conditions:
             *  Test with Character of Named Bob
             *  Test with Character of any other name
             * 
             * Validation:
             *      Verify Enum is Miss
             *  
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;
            var Bob = new CharacterModel
            {
                Speed = 200,
                Level = 10,
                CurrentHealth = 100,
                TotalExperience = 100,
                Name = "Bob"
            };
            var CharacterPlayer = new BattleEntityModel(Bob);

            BattleEngine.CharacterList.Add(Bob);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberMonsters = 1;

            var Monster = new MonsterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                ExperienceGiven = 1,
                Name = "Monster",
            };
            var MonsterPlayer = new BattleEntityModel(Monster);

            BattleEngine.MonsterList.Add(Monster);

            // Have dice rull 19
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(19);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            //Reset
            DiceHelper.EnableRandomValues();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Miss, BattleEngine.BattleMessages.HitStatus);
        }

        [Test]
        public async Task HackathonScenario_Scenario_2_Character_Not_Bob_Should_Hit()
        {
            /* 
             * Scenario Number:  
             *      2
             *      
             * Description: 
             *      See Default Test
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      See Defualt Test
             *                 
             * Test Algrorithm:
             *      Create Character named Mike
             *      Create Monster
             *      Call TurnAsAttack so Mike can attack Monster
             * 
             * Test Conditions:
             *      Control Dice roll so natural hit
             *      Test with Character of not named Bob
             *  
             *  Validation
             *      Verify Enum is Hit
             *      
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var Yoshi = new CharacterModel
            {
                Speed = 200,
                Level = 10,
                CurrentHealth = 100,
                TotalExperience = 100,
                Name = "Yoshi"
            };
            var CharacterPlayer = new BattleEntityModel(Yoshi);

            BattleEngine.CharacterList.Add(Yoshi);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberMonsters = 1;

            var Monster = new MonsterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                ExperienceGiven = 1,
                Name = "Monster",
            };
            var MonsterPlayer = new BattleEntityModel(Monster);

            BattleEngine.MonsterList.Add(Monster);

            // Have dice roll 20
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            // Battle needs to create entity list
            BattleEngine.MakeEntityList();

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            //Reset
            DiceHelper.EnableRandomValues();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Hit, BattleEngine.BattleMessages.HitStatus);
        }

        [Test]
        public async Task HackathonScenario_Scenario_9_MiracleMax_SaveCharacter_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      9
            *      
            * Description: 
            *      Miracle Max steps in once per character per battle to save characters on the brink of death.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      CharacterModel: added field for MiracleMax (bool) 
            *      TurnEngine class: update TakeDamage method to add conditions for checking MiracleMax 
            *      status if character would otherwise die.
            * 
            * Test Algorithm:
            *      Create Character
            *      Set health low and speed low so it will take damage
            *      Set Current health low but Max health high
            *      
            *      Start a battle, initiate attack on character
            * 
            * Test Conditions:
            *      Character should take damage and be saved by Miracle Max 
            * 
            * Validation:
            *      Character's alive status will be alive and current health will match max health
            *      MiracleMax field will be false
            *  
            */

            //Arrange
            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = -1, // will go last and take damage 
                Level = 1,
                CurrentHealth = 1,
                MaxHealth = 100,
                TotalExperience = 1,
                Attack = 10,
                Defense = 10,
                Name = "Yoshi"
            };
            var CharacterPlayer = new BattleEntityModel(CharacterPlayerYoshi);

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            // Add a monster to attack
            BattleEngine.MaxNumberMonsters = 1;

            var Monster = new MonsterModel
            {
                Speed = 100,
                Level = 1,
                CurrentHealth = 1,
                ExperienceGiven = 1,
                Name = "Monster",
            };
            var MonsterPlayer = new BattleEntityModel(Monster);

            BattleEngine.MonsterList.Add(Monster);

            // Update Round Count for test (starting game from beginning)
            BattleEngine.Score.RoundCount = 1;
            // Have dice roll 20
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            // Battle needs to create entity list
            BattleEngine.NewRound();

            //Act
            var result = BattleEngine.TurnAsAttack(BattleEngine.EntityList[0], BattleEngine.EntityList[1]);
            var result2 = BattleEngine.CharacterList[0];

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(100, result2.CurrentHealth);
            Assert.AreEqual(false, result2.MiracleMax);
        }

        //[Test]
        //public async Task HackathonScenario_Scenario_10_Grenade_ItemDrop_Should_Pass()
        //{
        //    /* 
        //    * Scenario Number:  
        //    *      10
        //    *      
        //    * Description: 
        //    *      When a Unique Item from a monster Drops, there is a chance, that it is a 
        //    *      Hand Grenade that suddenly does damage to all monsters. 
        //    * 
        //    * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
        //    *      TurnEngine class: update ItemDrop method to dice roll for grenade drop which 
        //    *      causes damage to all monsters in MonsterList
        //    * 
        //    * Test Algorithm:
        //    *      Create Characters (normal stats), Monsters (weak stats)
        //    *      
        //    *      Start a battle 
        //    *      Force dice roll
        //    *      Force item drop
        //    * 
        //    * Test Conditions:
        //    *      Monsters should take damage from grenade drop
        //    * 
        //    * Validation:
        //    *      Monsters' health should be lower than original health
        //    *  
        //    */

        //    //Arrange
        //    // Set Character Conditions

        //    BattleEngine.MaxNumberCharacters = 1;

        //    var CharacterPlayerYoshi = new CharacterModel
        //    {
        //        Speed = 20, 
        //        Level = 1,
        //        CurrentHealth = 1,
        //        MaxHealth = 10,
        //        TotalExperience = 10,
        //        Attack = 50,
        //        Defense = 10,
        //        Name = "Yoshi"
        //    };
        //    var CharacterPlayer = new BattleEntityModel(CharacterPlayerYoshi);

        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

        //    // Set Monster Conditions
        //    // Add a monster to attack
        //    BattleEngine.MaxNumberMonsters = 4;

        //    var MonsterWeak = new MonsterModel
        //    {
        //        Speed = -1, // character needs to go first to hit
        //        Level = 1,
        //        CurrentHealth = 1, // needs to die to drop item and trigger grenade drop
        //        ExperienceGiven = 1,
        //        Name = "Monster",
        //    };
        //    var Monster = new MonsterModel
        //    {
        //        Speed = -1, // character needs to go first to hit
        //        Level = 1,
        //        CurrentHealth = 10,
        //        ExperienceGiven = 1,
        //        Name = "Monster",
        //    };

        //    BattleEngine.MonsterList.Add(MonsterWeak);
        //    BattleEngine.MonsterList.Add(Monster);
        //    BattleEngine.MonsterList.Add(Monster);
        //    BattleEngine.MonsterList.Add(Monster);

        //    // Update Round Count for test (grenade drop uses round count for damage calculation)
        //    BattleEngine.Score.RoundCount = 2;
        //    // Have dice roll 1 to trigger grenade drop
        //    DiceHelper.DisableRandomValues();
        //    DiceHelper.SetForcedDiceRollValue(1);

        //    // Battle needs to create entity list
        //    BattleEngine.NewRound();

        //    //Act
        //    // Force weak monster to take damage, which should force an Item drop that forces damaging grenade
        //    BattleEngine.TakeDamage(BattleEngine.EntityList.First(a => a.Id == BattleEngine.MonsterList[0].Id), 10);
        //    var monster1 = BattleEngine.MonsterList[0]; // should be dead
        //    var monster2 = BattleEngine.MonsterList[1]; // three others should have taken damage
        //    var monster3 = BattleEngine.MonsterList[2];
        //    var monster4 = BattleEngine.MonsterList[3];

        //    //Reset
        //    BattleEngine.Score.RoundCount = 0;
        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.MonsterList.Clear();
        //    BattleEngine.ItemPool.Clear();
        //    DiceHelper.EnableRandomValues();

        //    //Assert
        //    Assert.AreEqual(false, monster1.Alive);
        //    Assert.AreNotEqual(Monster.CurrentHealth, monster2.CurrentHealth);
        //    Assert.AreNotEqual(Monster.CurrentHealth, monster3.CurrentHealth);
        //    Assert.AreNotEqual(Monster.CurrentHealth, monster4.CurrentHealth);
        //}

       // [Test]
        //public async Task HackathonScenario_Scenario_30_FirstCharacter_Buffed_Should_Pass()
        //{
        //    /* 
        //    * Scenario Number:  
        //    *      30
        //    *      
        //    * Description: 
        //    *      The first character in the player list gets their base Attack, Speed, Defense values 
        //    *      buffed by 2x for the time they are the first in the list.
        //    * 
        //    * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
        //    *      BattleEntityModel: added field for FirstBuff (bool) and methods to buff/unbuff entity
        //    *      RoundEngine class: update OrderEntityListByTurnOrder method to check for conditions
        //    *      on whether character is first in entity list, and if they are, buff their stats. If 
        //    *      the character was previously buffed and no longer gets the buff, they are debuffed.
        //    * 
        //    * Test Algorithm:
        //    *      Create Character
        //    *      Set speed to 100 (very fast, first in order)
        //    *      
        //    *      Start a battle, check if that character is buffed
        //    * 
        //    * Test Conditions:
        //    *      Character should have highest speed, and therefore would hold position 0 in list
        //    * 
        //    * Validation:
        //    *      Entity field FirstBuff() will be true
        //    *      Attack attribute will be doubled
        //    *  
        //    */

        //    //Arrange
        //    // Set Character Conditions

        //    BattleEngine.MaxNumberCharacters = 1;

        //    var CharacterPlayerYoshi = new CharacterModel
        //    {
        //        Speed = 100, // Will go first and trigger buff
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Attack = 10,
        //        Defense = 10,
        //        Name = "Yoshi"
        //    };

        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

        //    // Set Monster Conditions

        //    // Auto Battle will add the monsters

        //    // Update Round Count for test (starting game from beginning)
        //    BattleEngine.Score.RoundCount = 0;

        //    //Act
        //    BattleEngine.NewRound();

        //    // get the first Entity in list
        //    var character = BattleEngine.EntityList[0];

        //    //Reset
        //    BattleEngine.Score.RoundCount = 0;
        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.MonsterList.Clear();
        //    BattleEngine.ItemPool.Clear();

        //    //Assert
        //    Assert.AreEqual(true, character.FirstBuff);
        //    Assert.AreEqual(20, character.Attack);
        //}
        //[Test]
        //public async Task HackathonScenario_Scenario_30_SecondCharacter_NotBuffed_Should_Pass()
        //{
        //    /* 
        //    * Scenario Number:  
        //    *      30
        //    *      
        //    * Description: 
        //    *      The first character in the player list gets their base Attack, Speed, Defense values 
        //    *      buffed by 2x for the time they are the first in the list.
        //    * 
        //    * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
        //    *      BattleEntityModel: added field for FirstBuff (bool) and methods to buff/unbuff entity
        //    *      RoundEngine class: update OrderEntityListByTurnOrder method to check for conditions
        //    *      on whether character is first in entity list, and if they are, buff their stats. If 
        //    *      the character was previously buffed and no longer gets the buff, they are debuffed.
        //    * 
        //    * Test Algorithm:
        //    *      Create Character
        //    *      Set speed to 100 (very fast, first in order)
        //    *      Create second character
        //    *      Set their speed to a lower amount
        //    *      
        //    *      Start a battle, check if second character is not buffed
        //    * 
        //    * Test Conditions:
        //    *      Character should not have highest speed, and therefore would not hold position 0 in list
        //    * 
        //    * Validation:
        //    *      Entity field FirstBuff() will be false
        //    *  
        //    */

        //    //Arrange
        //    // Set Character Conditions

        //    BattleEngine.MaxNumberCharacters = 1;

        //    var CharacterPlayerYoshi = new CharacterModel
        //    {
        //        Speed = 100, // Will go first and trigger buff
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Attack = 10,
        //        Defense = 10,
        //        Name = "Yoshi"
        //    };

        //    var CharacterPlayerMarble = new CharacterModel
        //    {
        //        Speed = 90, // high enough speed to occupy position 1
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Attack = 10,
        //        Defense = 10,
        //        Name = "Marble"
        //    };

        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);

        //    // Set Monster Conditions

        //    // Auto Battle will add the monsters

        //    // Update Round Count for test (starting game from beginning)
        //    BattleEngine.Score.RoundCount = 0;

        //    //Act
        //    BattleEngine.NewRound();

        //    // get the first Entity in list
        //    var character = BattleEngine.EntityList[1];

        //    //Reset
        //    BattleEngine.Score.RoundCount = 0;
        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.MonsterList.Clear();
        //    BattleEngine.ItemPool.Clear();

        //    //Assert
        //    Assert.AreEqual(false, character.FirstBuff);
        //    Assert.AreEqual(10, character.Attack);
        //}

        //[Test]
        //public async Task HackathonScenario_Scenario_30_NewRoundUnbuff_Buffed_Should_Pass()
        //{
        //    /* 
        //    * Scenario Number:  
        //    *      30
        //    *      
        //    * Description: 
        //    *      The first character in the player list gets their base Attack, Speed, Defense values 
        //    *      buffed by 2x for the time they are the first in the list.
        //    * 
        //    * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
        //    *      BattleEntityModel: added field for FirstBuff (bool) and methods to buff/unbuff entity
        //    *      RoundEngine class: update OrderEntityListByTurnOrder method to check for conditions
        //    *      on whether character is first in entity list, and if they are, buff their stats. If 
        //    *      the character was previously buffed and no longer gets the buff, they are debuffed.
        //    * 
        //    * Test Algorithm:
        //    *      Create Character - Set speed to 100 (very fast, first in order)
        //    *      Create other character - speed to 90
        //    *      
        //    *      Start a battle, check if first character is buffed
        //    *      Adjust speeds of first character and another character so other character is fastest
        //    *      Advance round, check if other character is buffed and first character unbuffed
        //    * 
        //    * Test Conditions:
        //    *      Characters will change speeds and force change in buffs
        //    * 
        //    * Validation:
        //    *      Entity field FirstBuff() will be true for first character in first round
        //    *      FirstBuff() will be true for second character in second round, false for first character
        //    *  
        //    */

        //    //Arrange
        //    // Set Character Conditions

        //    BattleEngine.MaxNumberCharacters = 1;

        //    var CharacterPlayerYoshi = new CharacterModel
        //    {
        //        Speed = 100, // Will go first and trigger buff
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Attack = 10,
        //        Defense = 10,
        //        Name = "Yoshi"
        //    };

        //    var CharacterPlayerMarble = new CharacterModel
        //    {
        //        Speed = 90,
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Attack = 10,
        //        Defense = 10,
        //        Name = "Marble"
        //    };

        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);

        //    // Set Monster Conditions

        //    // Auto Battle will add the monsters

        //    // Update Round Count for test (starting game from beginning)
        //    BattleEngine.Score.RoundCount = 0;


        //    //Act
        //    BattleEngine.NewRound();
        //    var character1 = BattleEngine.EntityList[0].Name;
        //    var result1 = BattleEngine.EntityList[0].FirstBuff; // Yoshi should be buffed first round

        //    // adjust Yoshi's speed so Marble goes first next round
        //    BattleEngine.CharacterList[0].Speed = 20;
        //    BattleEngine.NewRound();
        //    var test = BattleEngine.EntityList[0];
        //    var character2 = BattleEngine.EntityList[0].Name;
        //    var result2 = BattleEngine.EntityList[0].FirstBuff; // Marble should be buffed
        //    var result3 = BattleEngine.EntityList[1].FirstBuff; // Yoshi should not be buffed

        //    //Reset
        //    BattleEngine.Score.RoundCount = 0;
        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.MonsterList.Clear();
        //    BattleEngine.ItemPool.Clear();

        //    //Assert
        //    Assert.AreEqual(true, result1);
        //    Assert.AreEqual("Yoshi", character1);
        //    Assert.AreEqual(true, result2);
        //    Assert.AreEqual("Marble", character2);
        //    Assert.AreEqual(false, result3);
        //}

        [Test]
        public async Task HackathonScenario_Scenario_32_Round1_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      32
            *      
            * Description: 
            *      Every 5th round, the sort order for turn order changes and list is sorted by Characters first, 
            *      then lowest health, then lowest speed
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: update OrderEntityListByTurnOrder method to check for every 5th round,
            *      and apply new sorting order rule if Round number is a multiple of 5
            * 
            * Test Algorithm:
            *      Create Character
            *      Set speed to -1 (very slow)
            *      
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 1, so usual Entity sort order should be applied
            * 
            * Validation:
            *      Verify slow Character is last in EntityList
            *  
            */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = -1, // Will go last...
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Update Round Count for test (starting game from beginning)
            BattleEngine.Score.RoundCount = 0;

            //Act
            BattleEngine.NewRound();
            int count = BattleEngine.EntityList.Count();
            // get the last Entity in list
            var result = BattleEngine.EntityList.ElementAt(count - 1);

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(CharacterPlayerYoshi.Name, result.Name);
        }

        [Test]
        public async Task HackathonScenario_Scenario_32_Round5_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      32
            *      
            * Description: 
            *      Every 5th round, the sort order for turn order changes and list is sorted by Characters first, 
            *      then lowest health, then lowest speed
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: update OrderEntityListByTurnOrder method to check for every 5th round,
            *      and apply new sorting order rule if Round number is a multiple of 5
            * 
            * Test Algorithm:
            *      Create Character
            *      Set speed to -1 (very slow)
            *      
            *      Set Round number to 4 completed
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 5, so new hackathon Entity sort order should be applied
            * 
            * Validation:
            *      Character is first in EntityList
            *  
            */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = -1, // Will go last...
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Update Round Count for test (4 rounds have been completed already)
            BattleEngine.Score.RoundCount = 4;

            //Act
            BattleEngine.NewRound();
            // get the first Entity in list
            var result = BattleEngine.EntityList.ElementAt(0);

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(CharacterPlayerYoshi.Name, result.Name);
        }

        //[Test]
        //public async Task HackathonScenario_Scenario_33_Round1_Should_Pass()
        //{
        //    /* 
        //    * Scenario Number:  
        //    *      33
        //    *      
        //    * Description: 
        //    *      On 13th round, a random character dies at the beginning of the round.
        //    * 
        //    * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
        //    *      RoundEngine class: added UnluckyRound() method to randomly choose a character to die.
        //    * 
        //    * Test Algorithm:
        //    *      Create Characters - six
        //    *      Set forced dice roll to 1 to kill first character
        //    *      Set Round number to 12
        //    *      Start New Round
        //    * 
        //    * Test Conditions:
        //    *      Round number is 1, so UnluckyRound should not kill a character
        //    * 
        //    * Validation:
        //    *      First character in character list is alive
        //    *  
        //    */

        //    //Arrange

        //    // Set Character Conditions

        //    BattleEngine.MaxNumberCharacters = 6;

        //    var CharacterPlayerYoshi = new CharacterModel
        //    {
        //        Speed = 1,
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Name = "Yoshi"
        //    };

        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

        //    // Set Monster Conditions
        //    BattleEngine.MaxNumberMonsters = 6;
        //    BattleEngine.MonsterList.Clear();

        //    // Battle will add the monsters

        //    // Don't need any items for test
        //    BattleEngine.ItemPool.Clear();

        //    // Update Round Count for test
        //    BattleEngine.Score.RoundCount = 0;

        //    //Act
        //    BattleEngine.NewRound();
        //    // get the first Entity in list
        //    var result = BattleEngine.CharacterList.ElementAt(0);

        //    //Reset
        //    BattleEngine.Score.RoundCount = 0;
        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.MonsterList.Clear();
        //    BattleEngine.ItemPool.Clear();
        //    DiceHelper.EnableRandomValues();

        //    //Assert
        //    Assert.AreEqual(true, result.Alive);
        //}

        //[Test]
        //public async Task HackathonScenario_Scenario_33_Round13_Should_Fail()
        //{
        //    /* 
        //    * Scenario Number:  
        //    *      33
        //    *      
        //    * Description: 
        //    *      On 13th round, a random character dies at the beginning of the round.
        //    * 
        //    * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
        //    *      RoundEngine class: added UnluckyRound() method to randomly choose a character to die.
        //    * 
        //    * Test Algorithm:
        //    *      Create Characters - six
        //    *      Set forced dice roll to 1 to kill first character
        //    *      Set Round number to 12
        //    *      Start New Round
        //    * 
        //    * Test Conditions:
        //    *      Round number is 13, so UnluckyRound should kill a character
        //    * 
        //    * Validation:
        //    *      First character (named "Yoshi") is dead
        //    *  
        //    */

        //    //Arrange

        //    // Set Character Conditions

        //    BattleEngine.MaxNumberCharacters = 6;

        //    var CharacterPlayerYoshi = new CharacterModel
        //    {
        //        Speed = 1,
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Name = "Yoshi"
        //    };

        //    var CharacterPlayerMarble = new CharacterModel
        //    {
        //        Speed = 1,
        //        Level = 1,
        //        CurrentHealth = 1,
        //        TotalExperience = 1,
        //        Name = "Marble"
        //    };


        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);
        //    BattleEngine.CharacterList.Add(CharacterPlayerMarble);

        //    // Set Monster Conditions
        //    BattleEngine.MaxNumberMonsters = 6;
        //    BattleEngine.MonsterList.Clear();

        //    // Battle will add the monsters

        //    // Don't need any items for test
        //    BattleEngine.ItemPool.Clear();

        //    // Update Round Count for test (12 rounds have been completed already)
        //    BattleEngine.Score.RoundCount = 12;
        //    DiceHelper.DisableRandomValues();
        //    DiceHelper.SetForcedDiceRollValue(1);
        //    //Act
        //    BattleEngine.NewRound();
        //    // get the first Entity in list
        //    var result = BattleEngine.CharacterList.Any(a => a.Name == "Yoshi");
        //    var result2 = BattleEngine.CharacterList.Any(a => a.Name == "Marble");

        //    //Reset
        //    BattleEngine.Score.RoundCount = 0;
        //    BattleEngine.CharacterList.Clear();
        //    BattleEngine.MonsterList.Clear();
        //    BattleEngine.ItemPool.Clear();
        //    DiceHelper.EnableRandomValues();

        //    //Assert
        //    Assert.AreEqual(false, result);
        //    Assert.AreEqual(true, result2);
        //}

        [Test]
        public async Task HackathonScenario_Scenario_5_CriticalHits_Disabled_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      5
             *      
             * Description: 
             *      Critical Hits can be enabled in the battle engine.
             *      The attacker will automatically hit and cause double damage if the tohit roll is a natural 20 (Modifies are not included). 
             *      So, a rat of level 1, can take a big bite out of a level 20 warrior’s ear by rolling that lucky 20.
             *      Both Monsters and Characters get the benefit of a Critical Hit
             *      A roll of 20 always hits regardless of the critical hit enabled or not.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      CriticalHitsEnabled flag added to BaseEngine
             *      Update TurnEngine to implement Critical Hits if enabled
             *      Flag added to BattleMessagesModel to help in display of debug/battle messages
             *      Add debug switch to About page
             * 
             * Test Algorithm:
             *      Add Character to engine - very fast, so hits first
             *      Disable critical hits
             *      Dice rolls set to 20 - always hit
             * 
             * Test Conditions:
             *      Player takes one turn (attack)
             * 
             * Validation:
             *      Verify Battle Message after attack does not contain "Critical"
             *  
             */
            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 1000000, // Will go first...
                Level = 1,
                CurrentHealth = 100,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Disable Critical Hits
            BattleEngine.CriticalHitsEnabled = false;

            // Have dice roll 20
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            //Act
            BattleEngine.NewRound();
            var Player = BattleEngine.GetNextPlayerTurn();
            BattleEngine.Attack(Player);
            var result = BattleEngine.BattleMessages.TurnMessage.Contains("Critical");

            //Resets
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();
            DiceHelper.EnableRandomValues();

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_5_CriticalHits_Enabled_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      5
             *      
             * Description: 
             *      Critical Hits can be enabled in the battle engine.
             *      The attacker will automatically hit and cause double damage if the tohit roll is a natural 20 (Modifies are not included). 
             *      So, a rat of level 1, can take a big bite out of a level 20 warrior’s ear by rolling that lucky 20.
             *      Both Monsters and Characters get the benefit of a Critical Hit
             *      A roll of 20 always hits regardless of the critical hit enabled or not.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      CriticalHitsEnabled flag added to BaseEngine
             *      Update TurnEngine to implement Critical Hits if enabled
             *      Flag added to BattleMessagesModel to help in display of debug/battle messages
             *      Add debug switch to About page
             * 
             * Test Algorithm:
             *      Add Character to engine - very fast, so hits first
             *      Enable critical hits
             *      Dice rolls set to 20 - always critical hit
             * 
             * Test Conditions:
             *      Player takes one turn (attack)
             * 
             * Validation:
             *      Verify Battle Message after attack contains "Critical"
             *  
             */
            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 1000000, // Will go first...
                Level = 1,
                CurrentHealth = 100,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Disable Critical Hits
            BattleEngine.CriticalHitsEnabled = true;

            // Have dice roll 20
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            //Act
            BattleEngine.NewRound();
            var Player = BattleEngine.GetNextPlayerTurn();
            BattleEngine.Attack(Player);
            var result = BattleEngine.BattleMessages.TurnMessage.Contains("Critical");

            //Resets
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();
            DiceHelper.EnableRandomValues();
            BattleEngine.CriticalHitsEnabled = false;

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_39_Round1_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      39
            *      
            * Description: 
            *      On any round divisible by three, any surviving characters should double their experience
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: added WisdomCheck() method to double experience for all surviving characters
            * 
            * Test Algorithm:
            *      Create Characters - three with regular stats
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 1, so characters should not get wisdom bonus
            * 
            * Validation:
            *      All three characters are untouched by wisdom bonus
            *  
            */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 3;

            var Yoshi = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 2,
                Name = "Yoshi"
            };

            var Marble = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 5,
                Name = "Marble"
            };

            var Baby = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 10,
                Name = "Baby"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(Yoshi);
            BattleEngine.CharacterList.Add(Marble);
            BattleEngine.CharacterList.Add(Baby);


            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Update Round Count for test
            BattleEngine.Score.RoundCount = 1;

            //Act
            BattleEngine.NewRound();
            // get entities in character list
            var char1 = BattleEngine.CharacterList.ElementAt(0);
            var char2 = BattleEngine.CharacterList.ElementAt(1);
            var char3 = BattleEngine.CharacterList.ElementAt(2);

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(2, char1.TotalExperience);
            Assert.AreEqual(5, char2.TotalExperience);
            Assert.AreEqual(10, char3.TotalExperience);
        }

        [Test]
        public async Task HackathonScenario_Scenario_39_Round3_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      39
            *      
            * Description: 
            *      On any round divisible by three, any surviving characters should double their experience
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: added WisdomCheck() method to double experience for all surviving characters
            * 
            * Test Algorithm:
            *      Create Characters - three with regular stats
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 3, so characters should get wisdom bonus
            * 
            * Validation:
            *      All three characters should be affected by wisdom bonus
            *  
            */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 3;

            var Yoshi = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 2,
                Name = "Yoshi"
            };

            var Marble = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 5,
                Name = "Marble"
            };

            var Baby = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 10,
                Name = "Baby"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(Yoshi);
            BattleEngine.CharacterList.Add(Marble);
            BattleEngine.CharacterList.Add(Baby);


            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Update Round Count for test - will update to 3 inside of NewRound()
            BattleEngine.Score.RoundCount = 2;

            //Act
            BattleEngine.NewRound();
            // get entities in character list
            var char1 = BattleEngine.CharacterList.ElementAt(0);
            var char2 = BattleEngine.CharacterList.ElementAt(1);
            var char3 = BattleEngine.CharacterList.ElementAt(2);

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(4, char1.TotalExperience);
            Assert.AreEqual(10, char2.TotalExperience);
            Assert.AreEqual(20, char3.TotalExperience);
        }

        [Test]
        public async Task HackathonScenario_Scenario_6_CriticalMiss_Disabled_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      6
             *      
             * Description: 
             *      Critical Miss can be enabled in the battle engine.
             *      On a roll of 1 (miss), something bad might happen.
             *      After rolling a critical miss, a 10 sided dice is rolled to select a critical miss event.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      CriticalMissEnabled flag added to BaseEngine
             *      Update TurnEngine to implement Critical Miss if enabled
             *      Flag and message string added to BattleMessagesModel to help in display of debug/battle messages
             *      Add debug switch to About page
             * 
             * Test Algorithm:
             *      Add Character to engine - very fast, so hits first
             *      Disable critical miss
             *      Dice rolls set to 1 - miss (threshold for critical miss)
             * 
             * Test Conditions:
             *      Player takes one turn (attack)
             * 
             * Validation:
             *      Verify Battle Message after attack does not contain "Critical"
             *  
             */
            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 1000000, // Will go first...
                Level = 1,
                CurrentHealth = 100,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Disable Critical Hits
            BattleEngine.CriticalMissEnabled = false;

            // Have dice roll 20
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(1);

            //Act
            BattleEngine.NewRound();
            var Player = BattleEngine.GetNextPlayerTurn();
            BattleEngine.Attack(Player);
            var result = BattleEngine.BattleMessages.TurnMessage.Contains("Critical");

            //Resets
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();
            DiceHelper.EnableRandomValues();

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_6_CriticalMiss_Enabled_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      6
             *      
             * Description: 
             *      Critical Miss can be enabled in the battle engine.
             *      On a roll of 1 (miss), something bad might happen.
             *      After rolling a critical miss, a 10 sided dice is rolled to select a critical miss event.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      CriticalMissEnabled flag added to BaseEngine
             *      Update TurnEngine to implement Critical Miss if enabled
             *      Flag and message string added to BattleMessagesModel to help in display of debug/battle messages
             *      Add debug switch to About page
             * 
             * Test Algorithm:
             *      Add Character to engine - very fast, so hits first
             *      Disable critical miss
             *      Dice rolls set to 1 - critical miss!
             * 
             * Test Conditions:
             *      Player takes one turn (attack)
             * 
             * Validation:
             *      Verify Battle Message after attack contains "Critical"
             *  
             */
            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 1000000, // Will go first...
                Level = 1,
                CurrentHealth = 100,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Disable Critical Hits
            BattleEngine.CriticalHitsEnabled = true;

            // Have dice roll 20
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(20);

            //Act
            BattleEngine.NewRound();
            var Player = BattleEngine.GetNextPlayerTurn();
            BattleEngine.Attack(Player);
            var result = BattleEngine.BattleMessages.TurnMessage.Contains("Critical");

            //Resets
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();
            DiceHelper.EnableRandomValues();
            BattleEngine.CriticalHitsEnabled = false;

            //Assert
            Assert.AreEqual(true, result);
        }

    }
}
