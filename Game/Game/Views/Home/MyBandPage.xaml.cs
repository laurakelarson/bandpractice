using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBandPage : ContentPage
    {
        /// <summary>
        /// Constructor for MyBandPage
        /// </summary>
        public MyBandPage()
        {
            InitializeComponent();
        }
    }
}