using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;

namespace Bugmine.Core.Redmine.Mappers
{
	public interface ITicketResultMapper
	{
		List<Ticket> MapFromTicketResult(TicketsResult result);
 	}
}
