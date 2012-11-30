using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public static class ExceptionExtensions
	{
		/// <summary>
		/// Throwns an exception if instance is null
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="message">The message to be used in case the exception <paramref name="e"/>is left out</param>
		/// <param name="e">Exception override. Defaults to InvalidOperationException/></param>
		public static void ThrowIfNull(this object instance, string message = "Object is null", Exception e = null)
		{
			if (instance == null) throw e ?? new InvalidOperationException(message);
		}
	}
}
