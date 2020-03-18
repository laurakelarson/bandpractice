using NUnit.Framework;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;
using Game.Views.Monsters;

namespace UnitTests.Views.Monsters
{
    [TestFixture]
    public class MonsterIndexPageTests : MonsterIndexPage
    {
        App app;
        MonsterIndexPage page;

        public MonsterIndexPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterIndexPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

    }
}
