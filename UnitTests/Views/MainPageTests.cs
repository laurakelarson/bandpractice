using Game;
using Game.Views;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Mocks;
using Xamarin.Forms; 

namespace UnitTests.Views
{
    [TestFixture]
    public class MainPageTests
    {
        App app;
        MainPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MainPage();
        }
    }
}
