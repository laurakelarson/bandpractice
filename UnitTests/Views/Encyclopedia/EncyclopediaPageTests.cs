
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;

namespace UnitTests.Views.Encyclopedia
{
    [TestFixture]
    class EncyclopediaPageTests
    {
        App app;
        EncyclopediaPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new EncyclopediaPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void EncyclopediaPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void EncyclopediaPage_ItemsButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ItemsButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void EncyclopediaPage_MonstersButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.MonstersButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void EncyclopediaPage_CharactersButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CharactersButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void EncyclopediaPage_ScoresButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ScoresButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}
