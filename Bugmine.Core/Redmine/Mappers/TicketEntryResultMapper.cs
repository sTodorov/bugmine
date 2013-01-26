using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
using Bugmine.Core.Redmine.Results;

namespace Bugmine.Core.Redmine.Mappers
{
  public class TicketEntryResultMapper : ITicketEntryResultMapper
  {
    public TicketEntryResultMapper()
    {
      //todo: add additional data
      AutoMapper.Mapper.CreateMap<TicketEntryResult, TicketEntry>()
        .ForMember(c => c.Hours, c => c.MapFrom(l => l.hours));

      AutoMapper.Mapper.CreateMap<TicketEntriesResult, List<TicketEntry>>().ConstructUsing(c => new List<TicketEntry>(AutoMapper.Mapper.Map<List<TicketEntryResult>, List<TicketEntry>>(c.time_entries)));
    }

    public List<Models.TicketEntry> MapFromTicketEntryResult(Results.TicketEntriesResult result)
    {
      return AutoMapper.Mapper.Map<List<TicketEntry>>(result);
    }
  }
}
