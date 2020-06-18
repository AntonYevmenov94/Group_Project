using System;
using System.Globalization;

namespace Group_Project.Converters
{
    /// <summary>
    /// Конвертирует NULL в false
    /// </summary>
    internal class NullToBoolConverter : ValueConverterMarkupBase<NullToBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return false;
            else
                return true;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
