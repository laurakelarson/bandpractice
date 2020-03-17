using Game.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Helpers
{
    public static class ItemModelJsonHelper
    {
        /// <summary>
        /// Converts a single object that is a json string into a single ItemModel
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static ItemModel ConvertFromJson(JObject json)
        {
            var myData = new ItemModel();

            myData.Name = JsonHelper.GetJsonString(json, "Name");
            myData.Guid = JsonHelper.GetJsonString(json, "Guid");
            myData.Id = myData.Guid;    // Set to be the same as Guid, does not come down from server, but needed for DB

            myData.Description = JsonHelper.GetJsonString(json, "Description");
            myData.ImageURI = JsonHelper.GetJsonString(json, "ImageURI");

            myData.Value = JsonHelper.GetJsonInteger(json, "Value");
            myData.Range = JsonHelper.GetJsonInteger(json, "Range");
            myData.Damage = JsonHelper.GetJsonInteger(json, "Damage");

            //myData.Category = JsonHelper.GetJsonInteger(json, "Category");

            myData.Location = (ItemLocationEnum)JsonHelper.GetJsonInteger(json, "Location");
            myData.Attribute = (AttributeEnum)JsonHelper.GetJsonInteger(json, "Attribute");

            return myData;
        }
    }
}
