using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Redmine.Results
{
  public class TicketEntriesResult
  {
    public List<TicketEntryResult> time_entries { get; set; }
  }

  public class TicketEntryResult
  {
    public DateTime created_on { get; set; }

    public DateTime spent_on { get; set; }

    public decimal hours { get; set; }
  }
}
