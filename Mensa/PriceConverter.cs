using System;
using System.Globalization;
using Italbytz.Ports.Meal;

namespace Mensa
{
    public class PriceConverter : IValueConverter
    {
        public PriceConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var price = Settings.Status switch
            {
                0 => (double?)((IPrice)value).Students ?? 0.0,
                1 => (double?)((IPrice)value).Employees ?? 0.0,
                2 => (double?)((IPrice)value).Others ?? 0.0,
                _ => 0.0,
            };
            var cultureInfo = CultureInfo.GetCultureInfo("de-DE");
            return String.Format(cultureInfo, "{0:C}", price);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
