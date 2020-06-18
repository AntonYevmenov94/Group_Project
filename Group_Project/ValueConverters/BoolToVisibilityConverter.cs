using System;
using System.Globalization;
using System.Windows;

namespace Group_Project.Converters
{
    /// <summary>
    /// <para>Конвертирует bool значения в значение перечисления Visibility контролов.</para>
    /// true => Visible, false => Collapsed
    /// </summary>
    internal class BoolToVisibilityConverter : ValueConverterMarkupBase<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
