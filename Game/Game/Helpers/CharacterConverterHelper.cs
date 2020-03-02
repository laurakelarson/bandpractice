using System;
using System.Globalization;
using System.Linq;
using Game.Models;
using Game.ViewModels;
using Xamarin.Forms;

namespace Game.Helpers
{
    /// <summary>
    /// This Converter is used help display a list of CharacterModel objects within a Picker.
    /// It allows the picker to display the Character name and type.
    /// </summary>
    public class CharacterConverter : IValueConverter
    {
        /// <summary>
        /// Converts data type to visual representation. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            //if (value is CharacterModel)
            if (value.GetType() == typeof(CharacterModel))
            {
                var character = (CharacterModel)value;
                return character.Name + " - " + character.Type.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts visual representation to target data type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                string[] words = ((string)value).Split(' ');
                if (words.Length < 3)
                {
                    return null;
                }
                return CharacterIndexViewModel.Instance.Dataset.Where(
                    a => a.Name == words[0] && a.Type.ToString() == words[2]).FirstOrDefault();
            }

            return null;
        }
    }
}
