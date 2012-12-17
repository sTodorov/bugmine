using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bugmine.Core.Models;

namespace Bugmine.Core.Redmine.Mappers
{
	public class TicketResultMapper : ITicketResultMapper
	{
		public TicketResultMapper()
		{
			AutoMapper.Mapper.CreateMap<TicketResult, Ticket>()
				.ForMember(c => c.Id, c => c.MapFrom(m => m.id))
				.ForMember(c => c.Name, c => c.MapFrom(m => m.author.name))
				.ForMember(c => c.Priority, c => c.MapFrom(m => m.priority.name))
				.ForMember(c => c.Status, c => c.MapFrom(m => m.status.name))
				.ForMember(c => c.Project, c => c.MapFrom(m => m.project.name))
				.ForMember(c => c.EstimatedHours, c => c.MapFrom(m => m.estimated_hours));

			

		}

		public Page<Ticket> MapFromTicketResult(TicketsResult result)
		{
			return AutoMapper.Mapper.Map<TicketsResult, Page<Ticket>>(result);
		}
	}
}
