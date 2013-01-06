using System;
using Bugmine.Core.Redmine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bugmine.Core.Tests
{
	[TestClass]
	public class RedmineUrlsTests
	{
		private RedmineUrlManager _manager;

		public RedmineUrlsTests()
		{
			_manager = new RedmineUrlManager();
		}

		[TestMethod]
		public void Get_Tickets_Url_Should_Return_A_Valid_Url()
		{
			Assert.IsNotNull(_manager.GetTicketsUrl());
		}

		[TestMethod]
		public void Get_Tickets_Url_With_Parameters_Should_Return_A_Valid_Url()
		{
			Assert.IsNotNull(_manager.GetTicketsUrl(new { assigned_to_id = 52, limit = 1000 }));
		}
	}
}
