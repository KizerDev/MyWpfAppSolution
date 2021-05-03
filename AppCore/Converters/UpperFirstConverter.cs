using System;
using System.Globalization;
using System.Windows.Data;

namespace AppCore.Converters
{
    public class UpperFirstConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return value;
            var castValue = (string)value;
            return char.ToUpper(castValue[0]) + castValue.ToLower().Substring(1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
