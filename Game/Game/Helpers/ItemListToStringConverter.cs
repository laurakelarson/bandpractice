using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Game.Models;
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
            var items = (List<ItemModel>)value;
            List<string> names = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                names.Add(items[i].Name);
            }
            return string.Join(",", names);
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