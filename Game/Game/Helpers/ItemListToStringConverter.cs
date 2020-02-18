using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Game.Models;
using Game.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Game.Helpers
{
    /// <summary>
    /// ItemListToStringConverter implements IValueConverter. Its purpose is to help convert a List of ItemModel 
    /// into a string suitable for display on a xaml page
    /// </summary>
    class ItemListToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts List of ItemModel into a string listing the item names with comma delimiter
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value.GetType() != typeof(string))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty((string)value))
            {
                return string.Empty;
            }

            JArray IDs =
                (JArray)JsonConvert.DeserializeObject((string)value);

            List<string> names = new List<string>();
            foreach (JToken itemID in IDs)
            {
                ItemModel item = ItemIndexViewModel.Instance.GetItem(itemID.ToString());
                if (item != null)
                {
                    names.Add(item.Name);
                }
            }
            return string.Join(", ", names);
        }

        /// <summary>
        /// ConvertBack method not implemented.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}