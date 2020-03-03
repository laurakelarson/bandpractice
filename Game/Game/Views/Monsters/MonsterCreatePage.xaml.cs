using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using Game.Views.Monsters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Monster
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        // The Monster to create
        GenericViewModel<MonsterModel> ViewModel;

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            data.Data = new MonsterModel();

            BindingContext = this.ViewModel = data;
            for (var i = 1; i <= 20; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }
            LevelPicker.SelectedItem = 1.ToString();

            this.ViewModel.Title = "Create";

            AddItemsToDisplay1();
            AddItemsToDisplay2();
            AddItemsToDisplay3();

        }


        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            // Check input of Name (cannot be empty)
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                NameWarning.IsVisible = true;
                return;
            }

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.EntityService.DefaultMonsterImageURI;
            }

            // Send "Create" message and pop the page from the stack 
            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Event handler for level picker - sets the monster stats to the level table values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterLevelPicker(object sender, EventArgs e)
        {
            // Update default character type
            var currName = ViewModel.Data.Name;
            int newLevel = int.Parse((string)LevelPicker.SelectedItem);

            ViewModel.Data.ChangeLevel(newLevel);

            ViewModel.Data.Name = currName;
            ViewModel.Data.Level = newLevel;

            // Update the labels to display monster type default stats
            LevelLabel.Text = ViewModel.Data.Level.ToString();
            ExperienceLabel.Text = ViewModel.Data.ExperienceGiven.ToString();
            MaxHealthLabel.Text = ViewModel.Data.MaxHealth.ToString();
            DefenseLabel.Text = ViewModel.Data.Defense.ToString();
            AttackLabel.Text = ViewModel.Data.Attack.ToString();
            SpeedLabel.Text = ViewModel.Data.Speed.ToString();
            RangeLabel.Text = ViewModel.Data.Range.ToString();

        }

        /// <summary>
        /// Event handler for type picker - sets the character stats to the type default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Changed_MonsterTypePicker(object sender, EventArgs e)
        {
            // Update default monster type
            var currName = ViewModel.Data.Name;

            var newType = DefaultMonsterHelper.ConvertStringToEnum(MonsterTypePicker.SelectedItem.ToString());

            ViewModel.Data.Update(DefaultMonsterHelper.DefaultMonster(newType));

            ViewModel.Data.Name = currName;

            // Update displayed monster image
            IconImage.Source = ViewModel.Data.ImageURI;
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