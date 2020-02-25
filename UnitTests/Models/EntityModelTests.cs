using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    /// <summary>
    /// Entity model tests 
    /// </summary>
    [TestFixture]
    class EntityModelTests
    {
        // Wipe all data before tests 
        [TearDown]
        public async Task TearDown()
        {
            await Game.Helpers.DataSetsHelper.WipeData();
        }

        // Test TakeDamage when character doesn't die from damage 
        [Test]
        public void EntityModelTests_TakeDamage_Dont_Die_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.CurrentHealth = 20;

            // Act
            data.TakeDamage(10);

            // Reset

            // Assert
            Assert.AreEqual(data.Alive, true);
            Assert.AreEqual(data.CurrentHealth, 10); 
        }

        // Test takedamage method when entity dies 
        [Test]
        public void EntityModelTests_TakeDamage_Die_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            data.CurrentHealth = 10;

            // act
            data.TakeDamage(10);

            // reset

            // Assert
            Assert.AreEqual(data.Alive, false);
            Assert.AreEqual(data.CurrentHealth, 0); 

        }
    }
}
