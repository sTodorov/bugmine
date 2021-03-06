﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;

namespace Bugmine.Core.Repositories.Contracts
{
	public interface ITicketRepository
	{
		Page<Ticket> GetTickets(int userID, string apiKey);

		List<TicketEntry> GetTicketEntries(int ticketID, string apiKey);
	}
}
