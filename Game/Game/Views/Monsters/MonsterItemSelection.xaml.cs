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
    public partial class MonsterItemSelection : ContentPage
    {
        public MonsterItemSelection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves selection and closes the modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}