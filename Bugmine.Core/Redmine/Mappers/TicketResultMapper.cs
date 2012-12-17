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
				.ForMember(c => c.Name, c => c.MapFrom(m => m.subject))
				.ForMember(c => c.Priority, c => c.MapFrom(m => m.priority.name))
				.ForMember(c => c.DueDate, c => c.MapFrom(m => m.due_date))
				.ForMember(c => c.Status, c => c.MapFrom(m => m.status.name))
				.ForMember(c => c.Project, c => c.MapFrom(m => m.project.name))
				.ForMember(c => c.EstimatedHours, c => c.MapFrom(m => m.estimated_hours));

			Mapper.CreateMap<TicketsResult, Page<Ticket>>().ConstructUsing(c => new Page<Ticket>(c.offset, c.total_count, c.limit, AutoMapper.Mapper.Map<List<TicketResult>, List<Ticket>>(c.issues)));


		}

		public Page<Ticket> MapFromTicketResult(TicketsResult result)
		{
			return AutoMapper.Mapper.Map<TicketsResult, Page<Ticket>>(result);
		}
	}
}
