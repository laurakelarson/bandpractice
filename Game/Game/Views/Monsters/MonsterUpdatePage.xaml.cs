using Game.Helpers;
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
    public partial class MonsterUpdatePage : ContentPage
    {

        // View Model for Monster
        readonly GenericViewModel<MonsterModel> ViewModel;

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        // Variable to hold starting state of Monster in case 
        // user hits cancel during update
        MonsterModel startingState;
        int startingLevel;

        /// <summary>
        /// Constructor for Monster Update Page. 
        /// </summary>
        /// <param name="data"></param>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            startingLevel = data.Data.Level;
            InitializeComponent();

            BindingContext = ViewModel = data;
            LevelLabel.Text = startingLevel.ToString();

            // Load values into level picker
            for (var i = 1; i <= 20; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }

            startingState = new MonsterModel(data.Data);
            startingState.Level = startingLevel;
            LevelPicker.SelectedItem = startingLevel.ToString();

            this.ViewModel.Title = "Update";

            AddItemsToDisplay1();
            AddItemsToDisplay2();
            AddItemsToDisplay3();

        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

            // Revert Character attributes back to starting state
            ViewModel.Data.Update(startingState);
        }

        /// <summary>
        /// Event handler for type picker - sets the character stats to the type default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterLevelPicker(object sender, EventArgs e)
        {

            // Scale character to new level
            int level = int.Parse((string)LevelPicker.SelectedItem);
            ViewModel.Data.ChangeLevel(level);
            ViewModel.Data.ExperienceGiven = LevelAttributesHelper.Instance.LevelAttributesList[level].Experience;


            // Update the labels to display monster type default stats
            LevelLabel.Text = ViewModel.Data.Level.ToString();
            ExperienceLabel.Text = ViewModel.Data.ExperienceGiven.ToString();
            MaxHealthLabel.Text = ViewModel.Data.MaxHealth.ToString();
            DefenseLabel.Text = ViewModel.Data.Defense.ToString();
            AttackLabel.Text = ViewModel.Data.Attack.ToString();
            SpeedLabel.Text = ViewModel.Data.Speed.ToString();
            RangeLabel.Text = ViewModel.Data.Range.ToString();
        }

        #region item slot 1 popup methods
        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup1(ItemModel data)
        {
            PopupItemSelector1.IsVisible = true;

            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // will use null to clear the item
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None"
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };

            // Add the rest of the items to the list
            itemList.AddRange(ItemIndexViewModel.Instance.Dataset);

            // Populate the list with the items
            PopupLocationItemListView1.ItemsSource = itemList;
            return true;
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay1()
        {
            var data = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.ItemPocket1);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Location = ItemLocationEnum.Unknown, ImageURI = "icon_cancel.png" };
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            // Add a event to the user can click the item and see more
            ItemButton.Clicked += (sender, args) => ShowPopup1(data);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = "Item Pocket",
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnPopupItemSelected1(object sender, SelectedItemChangedEventArgs args)
        {
            ItemModel data = args.SelectedItem as ItemModel;
            if (data == null)
            {
                return;
            }

            ViewModel.Data.ItemPocket1 = data.Id;

            AddItemsToDisplay1();

            ClosePopup1();
        }

        /// <summary>
        /// Show the Items the Character has
        /// </summary>
        public void AddItemsToDisplay1()
        {
            var FlexList = ItemBox1.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox1.Children.Remove(data);
            }

            ItemBox1.Children.Add(GetItemToDisplay1());

        }

        /// <summary>
        /// When the user clicks the close in the Popup
        /// hide the view
        /// show the scroll view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked1(object sender, EventArgs e)
        {
            ClosePopup1();
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        public void ClosePopup1()
        {
            PopupItemSelector1.IsVisible = false;
        }


        #endregion

        #region item slot 2 popup methods
        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup2(ItemModel data)
        {
            PopupItemSelector2.IsVisible = true;

            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // will use null to clear the item
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None"
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };

            // Add the rest of the items to the list
            itemList.AddRange(ItemIndexViewModel.Instance.Dataset);

            // Populate the list with the items
            PopupLocationItemListView2.ItemsSource = itemList;
            return true;
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay2()
        {
            var data = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.ItemPocket2);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Location = ItemLocationEnum.Unknown, ImageURI = "icon_cancel.png" };
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            // Add a event to the user can click the item and see more
            ItemButton.Clicked += (sender, args) => ShowPopup2(data);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = "Item Pocket",
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }
        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnPopupItemSelected2(object sender, SelectedItemChangedEventArgs args)
        {
            ItemModel data = args.SelectedItem as ItemModel;
            if (data == null)
            {
                return;
            }

            ViewModel.Data.ItemPocket2 = data.Id;

            AddItemsToDisplay2();

            ClosePopup2();
        }

        /// <summary>
        /// Show the Items the Character has
        /// </summary>
        public void AddItemsToDisplay2()
        {
            var FlexList = ItemBox2.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox2.Children.Remove(data);
            }

            ItemBox2.Children.Add(GetItemToDisplay2());

        }

        /// <summary>
        /// When the user clicks the close in the Popup
        /// hide the view
        /// show the scroll view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked2(object sender, EventArgs e)
        {
            ClosePopup2();
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        public void ClosePopup2()
        {
            PopupItemSelector2.IsVisible = false;
        }


        #endregion

        #region item slot 3 popup methods
        /// <summary>
        /// Show the Popup for the Item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup3(ItemModel data)
        {
            PopupItemSelector3.IsVisible = true;

            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // will use null to clear the item
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None"
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };

            // Add the rest of the items to the list
            itemList.AddRange(ItemIndexViewModel.Instance.Dataset);

            // Populate the list with the items
            PopupLocationItemListView3.ItemsSource = itemList;
            return true;
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay3()
        {
            var data = ItemIndexViewModel.Instance.GetItem(ViewModel.Data.ItemPocket3);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Location = ItemLocationEnum.Unknown, ImageURI = "icon_cancel.png" };
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            // Add a event to the user can click the item and see more
            ItemButton.Clicked += (sender, args) => ShowPopup3(data);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = "Item Pocket",
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }
        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnPopupItemSelected3(object sender, SelectedItemChangedEventArgs args)
        {
            ItemModel data = args.SelectedItem as ItemModel;
            if (data == null)
            {
                return;
            }

            ViewModel.Data.ItemPocket3 = data.Id;

            AddItemsToDisplay3();

            ClosePopup3();
        }

        /// <summary>
        /// Show the Items the Character has
        /// </summary>
        public void AddItemsToDisplay3()
        {
            var FlexList = ItemBox3.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox3.Children.Remove(data);
            }

            ItemBox3.Children.Add(GetItemToDisplay3());

        }

        /// <summary>
        /// When the user clicks the close in the Popup
        /// hide the view
        /// show the scroll view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked3(object sender, EventArgs e)
        {
            ClosePopup3();
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        public void ClosePopup3()
        {
            PopupItemSelector3.IsVisible = false;
        }


        #endregion

    }
}