using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bugmine.UI.Controls.Converters
{
	public class CappedStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int capLength;
			if (!int.TryParse(parameter.ToString(), out capLength))
				capLength = 300; //default to 300

			return value.ToString().Cap(capLength, "...");
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
