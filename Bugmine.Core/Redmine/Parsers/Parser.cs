using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Bugmine.Core.Redmine.Parsers
{
	public static class Parser
	{
		public static TicketsResult ParseTickets(string tickets)
		{
			return tickets.FromJson<TicketsResult>();
		}
	}
}
