using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views.Scores
{
    [TestFixture]
    public class ScoreUpdatePageTests : ScoreUpdatePage
    {
        App app;
        ScoreUpdatePage page;

        public ScoreUpdatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ScoreUpdatePage(new GenericViewModel<ScoreModel>(new ScoreModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }


    }
}
