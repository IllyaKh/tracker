using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace track
{
    namespace Windows.UI.Xaml.Data
    {
        namespace Microsoft.EntityFrameworkCore.Storage
        {

            public class Converters
            {
                [ValueConversion(typeof(bool), typeof(bool))]
                public class invertBooleanConverter : IValueConverter
                {
                    #region IValueConverter Members

                    public object Convert(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
                    {
                        if (targetType != typeof(bool))
                            throw new InvalidOperationException("The target must be a boolean");

                        return !(bool)value;
                    }

                    public object ConvertBack(object value, Type targetType, object parameter,
                        System.Globalization.CultureInfo culture)
                    {
                        throw new NotSupportedException();
                    }

                }

            }
        }
    }
}