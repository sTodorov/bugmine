using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bugmine.Core.Tests
{
	[TestClass]
	public class StringExtensionTests
	{
		[TestMethod]
		public void String_Cap_With_Bigger_Lenght()
		{
			var s = "Dog";
			Assert.AreEqual("Dog", s.Cap(4));
		}

		[TestMethod]
		public void String_Cap_With_Smaller_Length()
		{
			var s = "Dog";
			Assert.AreEqual("Do", s.Cap(2));
		}
	}
}
