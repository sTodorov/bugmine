using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Bugmine.Core.Models;
using Bugmine.Core.Redmine;
using Bugmine.Core.Redmine.Parsers;
using Bugmine.Core.Repositories.Contracts;
using ServiceStack.Text;

namespace Bugmine.Core.Repositories
{
	public class TicketRepository : BaseRepository, ITicketRepository
	{
		private ITicketParser _ticketParser;

		public TicketRepository(ITicketParser ticketParser)
		{
			_ticketParser = ticketParser;
		}

		public List<Models.Ticket> GetTickets(int userID, string apiKey)
		{
			var request = ConstructWebRequest(string.Format("{0}?assigned_to_id={1};limit=15000", RedmineUrls.tickets, userID), apiKey);

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					string json = reader.ReadToEnd();

					var tickets = _ticketParser.ParseTickets(json);

					//map tickets results to ticket
					List<Ticket> result = new List<Ticket>();
					return result;
				}
			}
		}
	}
}
