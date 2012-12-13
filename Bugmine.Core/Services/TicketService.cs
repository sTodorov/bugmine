using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
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

		public List<Ticket> GetTickets()
		{
			return new List<Ticket>() { 
				new Ticket{
					Id = 1,
					Status= "Assigned",
					EstimatedHours = 6,
					Name = "Some new ticket"
				}
			};
		}
	}
}
