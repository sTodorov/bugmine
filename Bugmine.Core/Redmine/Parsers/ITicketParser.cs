using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
using Bugmine.Core.Redmine;

namespace Bugmine.Core.Redmine.Parsers
{
	public interface ITicketParser
	{
		TicketsResult ParseTickets(string tickets);
	}
}
