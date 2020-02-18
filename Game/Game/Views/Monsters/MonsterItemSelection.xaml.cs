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
    public partial class MonsterItemSelection : ContentPage
    {
        // Use ItemIndexViewModel for data
        readonly ItemIndexViewModel ViewModel;
        // Keep track of selections
        List<ItemModel> ItemSelectionList;

        /// <summary>
        /// Constructor for Monster Item Selection Page
        /// 
        /// Get the ItemIndexView Model
        /// </summary>
        public MonsterItemSelection()
        {
            InitializeComponent();
            ItemSelectionList = new List<ItemModel>();
            BindingContext = ViewModel = ItemIndexViewModel.Instance;
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // TODO Add code to save selection and attach to monster
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Item Selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        void Selection_Changed_Handler(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
            // TODO add code to save item models to attach to monster
        }

        /// <summary>
        /// For displaying string of selected items
        /// </summary>
        /// <param name="previousSelectedItems"></param>
        /// <param name="currentSelectedItems"></param>
        void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            var current = ToList(currentSelectedItems);
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current; //display only
        }

        /// <summary>
        /// Helper method to show string of selected items
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        static string ToList(IEnumerable<object> items)
        {
            if (items == null)
            {
                return string.Empty;
            }

            return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((ItemModel)obj).Name);
        }

    }
}