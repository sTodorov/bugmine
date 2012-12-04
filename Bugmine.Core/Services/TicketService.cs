using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Repositories.Contracts;

namespace Bugmine.Core.Services
{
	public class TicketService : ITicketService
	{
		private ITicketRepository _ticketRepository;

		public TicketService(ITicketRepository ticketRepo)
		{
			_ticketRepository = ticketRepo;
		}

		public List<Models.Ticket> GetTickets()
		{
			throw new NotImplementedException();
		}
	}
}
