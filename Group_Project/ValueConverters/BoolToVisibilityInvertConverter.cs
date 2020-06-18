using System;
using System.Globalization;
using System.Windows;

namespace Group_Project.Converters
{
    /// <summary>
    /// <para>Конвертирует bool в инвертированное значение перечисления Visibility контролов.</para>
    /// true => Collapsed, false => Visible
    /// </summary>
    internal class BoolToVisibilityInvertConverter : ValueConverterMarkupBase<BoolToVisibilityInvertConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return false;
            else
                return true;
        }
    }
}
