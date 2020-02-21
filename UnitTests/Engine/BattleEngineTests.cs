using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Models;
using Game.Engine;

namespace UnitTests.Engine
{
    [TestFixture]
    public class BattleEngineTests
    {
        BattleEngine Engine;

        [SetUp]
        public void SetUp()
        {
            Engine = new BattleEngine();
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
