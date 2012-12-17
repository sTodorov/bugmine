﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Configuration;
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

		public Page<Ticket> GetTickets()
		{
			string apiKey = ApplicationData.GetApiKey();
			int userID = ApplicationData.GetUserID();

			return _ticketRepository.GetTickets(userID, apiKey);
		}
	}
}
