using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class StringExtensions
	{
		public static void ThrowIfNullOrEmpty(this string instance, string message = null)
		{
			if (string.IsNullOrEmpty(instance))
				throw new InvalidOperationException(message ?? "String can't be null or empty");
		}

		public static string Cap(this string instance, int charCap = 100)
		{
			if (string.IsNullOrEmpty(instance)) return instance;

			return instance.Substring(0, Math.Min(charCap, instance.Length));
		}
	}
}
