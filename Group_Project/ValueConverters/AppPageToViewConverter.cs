using Group_Project.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Group_Project.Converters
{
    internal class AppPageToViewConverter : ValueConverterMarkupBase<AppPageToViewConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is AppPage))
            {
                throw new ArgumentException($"Converter works doesn't work with type {value.GetType()}");
            }
           
            var appPage = (AppPage)value;
            
            switch (appPage)
            {
                case AppPage.AuthPage:
                    return new Views.AuthPage();
                case AppPage.MainPage:
                    return new Views.MainPage();
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
