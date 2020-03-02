using System;
using System.Collections.Generic;
using Game.ViewModels;
using Xamarin.Forms;

namespace Game.Views.Battle
{
    public partial class RecruitPage : ContentPage
    {
        // Index View Model to help manage battle data across pages
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        public RecruitPage()
        {
            InitializeComponent();
            Title = "Recruit";

            // Set up binding to BattleEngineViewModel
            BindingContext = EngineViewModel;
        }
    }
}
