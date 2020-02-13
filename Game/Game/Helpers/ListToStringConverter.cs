using System;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Game.Helpers
{
    class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //            return string.Join(",", value);
            return "item";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}