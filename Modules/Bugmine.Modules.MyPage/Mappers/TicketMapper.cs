﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
using Bugmine.Modules.MyPage.Models;

namespace Bugmine.Modules.MyPage.Mappers
{
	public class TicketMapper : ITicketMapper
	{
		public TicketMapper()
		{
			AutoMapper.Mapper.CreateMap<Ticket, TicketModel>()
				.ForMember(c => c.TicketNumber, c => c.MapFrom(s => s.Id))
				.ForMember(c => c.EstimatedTime, c => c.MapFrom(s => s.EstimatedHours))
				.ForMember(c => c.SpentTime, c => c.MapFrom(s => s.LoggedHours));

		}

		public List<Models.TicketModel> Map(List<Core.Models.Ticket> Tickets)
		{
			return AutoMapper.Mapper.Map<List<TicketModel>>(Tickets);
		}
	}
}
