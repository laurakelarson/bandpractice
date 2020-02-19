using System;
using System.Globalization;
using Xamarin.Forms;

namespace Game.Helpers
{
    // This converter is used by the Pickers, to change from the picker value to the string value etc.
    // This allows the convert in the picker to be data bound back and forth the model
    // The picker requires this because the picker must be a string, but the enum is a value...

    /// <summary>
    /// Converts from an Int to an Enum value
    /// </summary>
    public class IntStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts String to Int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is String)
            {
                return int.Parse((string)value);
            }

            return 0;
        }

        /// <summary>
        /// Converts from Int to String
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return value.ToString();
            }

            return 0;
        }
    }
}