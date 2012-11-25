using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Bugmine.Core.Repositories.Contracts;

namespace Bugmine.Core.Repositories
{
	public class TicketRepository : BaseRepository, ITicketRepository
	{
		public List<Models.Ticket> GetTickets()
		{
			throw new NotImplementedException();
		}
	}
}
