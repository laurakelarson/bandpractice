using System;
using Game.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickItemsPage : ContentPage
    {
        // Index View Model to help manage battle data across pages
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        /// <summary>
        /// Constructor
        /// </summary>
        public PickItemsPage()
        {
            InitializeComponent();

            // Bind to battle engine instance
            BindingContext = EngineViewModel;

            // Display the items equipped during the round
            string DummyText = "Spot equipped bowtie.\nBowie equipped bunny slippers.\nKoopa equipped mushroom.\n"
                + "Dr. Dog equipped headphones.\nFall McCartney equipped didgeridoo.";
            ItemsLabel.Text = DummyText;
            //TODO hook up battle so real message is displayed
            //ItemsLabel.Text = EngineViewModel.Engine.BattleMessages.GetItemsEquippedMessage();
        }

        /// <summary>
        /// Quit the Battle
        /// 
        /// Quitting out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}