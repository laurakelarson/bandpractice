﻿
using NUnit.Framework;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using System.Linq;

namespace UnitTests.Views
{
    [TestFixture]
    class MenuPageTests
    {
        App app;
        MenuPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MenuPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }


    }
}
