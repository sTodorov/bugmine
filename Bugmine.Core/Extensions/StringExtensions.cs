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

		/// <summary>
		/// Caps a string to the desired number of characters.
		/// If <paramref name="capSymbol"/> is specified, the string will include the cap symbol on top of the <paramref name="charCap"/> 
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="charCap"></param>
		/// <param name="capSymbol"></param>
		/// <returns></returns>
		public static string Cap(this string instance, int charCap = 100, string capSymbol = "")
		{
			if (string.IsNullOrEmpty(instance)) return instance;

			return instance.Substring(0, Math.Min(charCap, instance.Length)) + capSymbol;
		}
	}
}
