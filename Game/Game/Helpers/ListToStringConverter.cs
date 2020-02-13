using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Game.Models;
using Xamarin.Forms;

namespace Game.Helpers
{
    class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<ItemModel>) value;
            List<string> names = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                names.Add(items[i].Name);
            }String
            return string.Join(",", names);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}