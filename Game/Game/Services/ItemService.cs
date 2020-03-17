using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Services
{
    /// <summary>
    /// Item Service class 
    /// </summary>
    static class ItemService
    {
        // Return the Default Image URI for the Local Image for an Item.
        public static string DefaultImageURI = "icon_new.png";

        public static async Task<List<ItemModel>> GetItemsFromServerGetAsync(int parameter = 100)
        {
            // parameter is the ItemModel group to request.  1, 2, 3, 100

            // Needs to get items from the server
            // Parse them
            // Then update the database
            // Only update fields on existing items
            // Insert new items
            // Then notify the viewmodel of the change

            // Needs to get items from the server

            var URLComponent = "GetItemList/";

            var DataResult = await HttpClientService.Instance.GetJsonGetAsync(WebGlobalsModel.WebSiteAPIURL + URLComponent + parameter);

            // Parse them
            var myList = ItemModelJsonHelper.ParseJson(DataResult);
            //if (myList == null)
            //{
            //    // Error, no results
            //    return null;
            //}

            // Then update the database

            // Use a foreach on myList
            foreach (var ItemModel in myList)
            {
                // Call to the View Model (that is where the datasource is set, and have it then save
                await ItemIndexViewModel.Instance.CreateUpdateAsync(ItemModel);
            }

            // When foreach is done, call to the items view model to set needs refresh to true, so it can refetch the list...
            ItemIndexViewModel.Instance.SetNeedsRefresh(true);

            return myList;
        }
    }
}
