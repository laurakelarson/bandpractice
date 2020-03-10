using NUnit.Framework;

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
            *      Make a Character called Yoshi, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Yoshi
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
            *      Verify Yoshi is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            AutoBattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                TotalExperience = 1,
                                Name = "Yoshi"
                            };

            AutoBattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions

            // Auto Battle will add the monsters


            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, AutoBattleEngine.EntityList.Find(m => m.Name.Equals("Yoshi")));
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
        public async Task HackathonScenario_Scenario_30_FirstCharacter_Buffed_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      30
            *      
            * Description: 
            *      The first character in the player list gets their base Attack, Speed, Defense values 
            *      buffed by 2x for the time they are the first in the list.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      BattleEntityModel: added field for FirstBuff (bool) and methods to buff/unbuff entity
            *      RoundEngine class: update OrderEntityListByTurnOrder method to check for conditions
            *      on whether character is first in entity list, and if they are, buff their stats. If 
            *      the character was previously buffed and no longer gets the buff, they are debuffed.
            * 
            * Test Algorithm:
            *      Create Character
            *      Set speed to 100 (very fast, first in order)
            *      
            *      Start a battle, check if that character is buffed
            * 
            * Test Conditions:
            *      Character should have highest speed, and therefore would hold position 0 in list
            * 
            * Validation:
            *      Entity field FirstBuff() will be true
            *      Attack attribute will be doubled
            *  
            */

            //Arrange
            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 100, // Will go first and trigger buff
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Attack = 10,
                Defense = 10,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Update Round Count for test (starting game from beginning)
            BattleEngine.Score.RoundCount = 0;

            //Act
            BattleEngine.NewRound();

            // get the first Entity in list
            var character = BattleEngine.EntityList[0];

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(true, character.FirstBuff);
            Assert.AreEqual(20, character.Attack);
        }
        [Test]
        public async Task HackathonScenario_Scenario_30_SecondCharacter_NotBuffed_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      30
            *      
            * Description: 
            *      The first character in the player list gets their base Attack, Speed, Defense values 
            *      buffed by 2x for the time they are the first in the list.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      BattleEntityModel: added field for FirstBuff (bool) and methods to buff/unbuff entity
            *      RoundEngine class: update OrderEntityListByTurnOrder method to check for conditions
            *      on whether character is first in entity list, and if they are, buff their stats. If 
            *      the character was previously buffed and no longer gets the buff, they are debuffed.
            * 
            * Test Algorithm:
            *      Create Character
            *      Set speed to 100 (very fast, first in order)
            *      Create second character
            *      Set their speed to a lower amount
            *      
            *      Start a battle, check if second character is not buffed
            * 
            * Test Conditions:
            *      Character should not have highest speed, and therefore would not hold position 0 in list
            * 
            * Validation:
            *      Entity field FirstBuff() will be false
            *  
            */

            //Arrange
            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 100, // Will go first and trigger buff
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Attack = 10,
                Defense = 10,
                Name = "Yoshi"
            };

            var CharacterPlayerMarble = new CharacterModel
            {
                Speed = 90, // high enough speed to occupy position 1
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Attack = 10,
                Defense = 10,
                Name = "Marble"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerMarble);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Update Round Count for test (starting game from beginning)
            BattleEngine.Score.RoundCount = 0;

            //Act
            BattleEngine.NewRound();

            // get the first Entity in list
            var character = BattleEngine.EntityList[1];

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(false, character.FirstBuff);
            Assert.AreEqual(10, character.Attack);
        }

        [Test]
        public async Task HackathonScenario_Scenario_30_NewRoundUnbuff_Buffed_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      30
            *      
            * Description: 
            *      The first character in the player list gets their base Attack, Speed, Defense values 
            *      buffed by 2x for the time they are the first in the list.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      BattleEntityModel: added field for FirstBuff (bool) and methods to buff/unbuff entity
            *      RoundEngine class: update OrderEntityListByTurnOrder method to check for conditions
            *      on whether character is first in entity list, and if they are, buff their stats. If 
            *      the character was previously buffed and no longer gets the buff, they are debuffed.
            * 
            * Test Algorithm:
            *      Create Character - Set speed to 100 (very fast, first in order)
            *      Create other character - speed to 90
            *      
            *      Start a battle, check if first character is buffed
            *      Adjust speeds of first character and another character so other character is fastest
            *      Advance round, check if other character is buffed and first character unbuffed
            * 
            * Test Conditions:
            *      Characters will change speeds and force change in buffs
            * 
            * Validation:
            *      Entity field FirstBuff() will be true for first character in first round
            *      FirstBuff() will be true for second character in second round, false for first character
            *  
            */

            //Arrange
            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 1;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 100, // Will go first and trigger buff
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Attack = 10,
                Defense = 10,
                Name = "Yoshi"
            };

            var CharacterPlayerMarble = new CharacterModel
            {
                Speed = 90, 
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Attack = 10,
                Defense = 10,
                Name = "Marble"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerMarble);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Update Round Count for test (starting game from beginning)
            BattleEngine.Score.RoundCount = 0;


            //Act
            BattleEngine.NewRound();
            var character1 = BattleEngine.EntityList[0].Name;
            var result1 = BattleEngine.EntityList[0].FirstBuff; // Yoshi should be buffed first round

            // adjust Yoshi's speed so Marble goes first next round
            BattleEngine.CharacterList[0].Speed = 20;
            BattleEngine.NewRound();
            var test = BattleEngine.EntityList[0];
            var character2 = BattleEngine.EntityList[0].Name;
            var result2 = BattleEngine.EntityList[0].FirstBuff; // Marble should be buffed
            var result3 = BattleEngine.EntityList[1].FirstBuff; // Yoshi should not be buffed

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();

            //Assert
            Assert.AreEqual(true, result1);
            Assert.AreEqual("Yoshi", character1);
            Assert.AreEqual(true, result2);
            Assert.AreEqual("Marble", character2);
            Assert.AreEqual(false, result3);
        }

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

        [Test]
        public async Task HackathonScenario_Scenario_33_Round1_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      33
            *      
            * Description: 
            *      On 13th round, a random character dies at the beginning of the round.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: added UnluckyRound() method to randomly choose a character to die.
            * 
            * Test Algorithm:
            *      Create Characters - six
            *      Set forced dice roll to 1 to kill first character
            *      Set Round number to 12
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 13, so UnluckyRound should kill a character
            * 
            * Validation:
            *      First character in character list is dead
            *  
            */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberCharacters = 6;

            var CharacterPlayerYoshi = new CharacterModel
            {
                Speed = 1, 
                Level = 1,
                CurrentHealth = 1,
                TotalExperience = 1,
                Name = "Yoshi"
            };

            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);
            BattleEngine.CharacterList.Add(CharacterPlayerYoshi);

            // Set Monster Conditions
            BattleEngine.MaxNumberMonsters = 6;
            BattleEngine.MonsterList.Clear();

            // Battle will add the monsters

            // Don't need any items for test
            BattleEngine.ItemPool.Clear();

            // Update Round Count for test (12 rounds have been completed already)
            BattleEngine.Score.RoundCount = 12;
            DiceHelper.DisableRandomValues();
            DiceHelper.SetForcedDiceRollValue(1);
            //Act
            BattleEngine.NewRound();
            // get the first Entity in list
            var result = BattleEngine.EntityList.ElementAt(0);

            //Reset
            BattleEngine.Score.RoundCount = 0;
            BattleEngine.CharacterList.Clear();
            BattleEngine.MonsterList.Clear();
            BattleEngine.ItemPool.Clear();
            DiceHelper.EnableRandomValues();

            //Assert
            Assert.AreEqual(false, result.Alive);
        }

        [Test]
        public async Task HackathonScenario_Scenario_33_Round13_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      33
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
    }
}
