using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
using Bugmine.Modules.MyPage.Models;

namespace Bugmine.Modules.MyPage.Mappers
{
	public interface ITicketMapper
	{
		List<TicketModel> Map(List<Ticket> Tickets);
	}
}
