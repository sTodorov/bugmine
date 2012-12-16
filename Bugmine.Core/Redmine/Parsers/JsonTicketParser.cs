using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
using Bugmine.Core.Redmine;
using ServiceStack.Text;

namespace Bugmine.Core.Redmine.Parsers
{
	public class JsonTicketParser : ITicketParser
	{
		public TicketsResult ParseTickets(string tickets)
		{
			return tickets.FromJson<TicketsResult>();
		}
	}
}
