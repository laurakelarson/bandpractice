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

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
