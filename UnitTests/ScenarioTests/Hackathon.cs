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
    }
}
