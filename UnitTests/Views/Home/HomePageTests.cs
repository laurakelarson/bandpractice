﻿using NUnit.Framework;
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

namespace UnitTests.Views
{
    [TestFixture]
    public class HomePageTests
    {
        App app;
        HomePage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new HomePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void HomePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void HomePage_MyBandButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.MyBand_Button_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void HomePage_HighScoreButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.HighScore_Button_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void HomePage_EncyclopediaButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.Encyclopedia_Button_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void HomePage_DemoTapeButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.Demotape_Button_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}
