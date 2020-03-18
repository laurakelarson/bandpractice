using NUnit.Framework;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.ViewModels;
using System.Threading.Tasks;

namespace UnitTests.Views.Items
{
    [TestFixture]
    public class ItemIndexPageTests : ItemIndexPage
    {
        App app;
        ItemIndexPage page;

        public ItemIndexPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemIndexPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

    }
}
