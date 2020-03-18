using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Monsters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterDeletePage : ContentPage
    {
        // View Model for Monster
        readonly GenericViewModel<MonsterModel> viewModel;

        // Empty Constructor for UTs
        public MonsterDeletePage(bool UnitTest) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>        
        public MonsterDeletePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.viewModel = data;

            this.viewModel.Title = data.Title;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", viewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}