using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;

namespace Bugmine.Core.Redmine.Mappers
{
	public class TicketResultMapper : ITicketResultMapper
	{
		public TicketResultMapper()
		{
			AutoMapper.Mapper.CreateMap<TicketsResult, List<Ticket>>();
		}

		public List<Ticket> MapFromTicketResult(TicketsResult result)
		{
			throw new NotImplementedException();
		}
	}
}
