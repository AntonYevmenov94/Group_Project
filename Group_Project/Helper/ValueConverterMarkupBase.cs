using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Group_Project.Helper
{
    /// <summary>
    /// Базовый класс для конвертеров, который позволяет использовать конвертер в XAML не объявляя его как ресурс.
    /// </summary>
    /// <typeparam name="T">Тип ValueConverter'a, который делается доступным в XAML</typeparam>
    public abstract class ValueConverterMarkupBase<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        /// <summary>
        /// Статический экземпляр конвертера
        /// </summary>
        private static T _converter = null;

        /// <summary>
        /// Возвращает статический экземпляр конвертера
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }


        #region IValueConverter

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
