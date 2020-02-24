using Game.Engine;
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

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
