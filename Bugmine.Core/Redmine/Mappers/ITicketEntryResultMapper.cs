using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Models;
using Bugmine.Core.Redmine.Results;

namespace Bugmine.Core.Redmine.Mappers
{
  public interface ITicketEntryResultMapper
  {
    List<TicketEntry> MapFromTicketEntryResult(TicketEntriesResult result);
  }
}
