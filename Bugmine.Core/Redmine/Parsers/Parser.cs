using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Redmine.Results;
using ServiceStack.Text;

namespace Bugmine.Core.Redmine.Parsers
{
  public static class Parser
  {
    internal static TicketsResult ParseTicketsResult(string tickets)
    {
      return tickets.FromJson<TicketsResult>();
    }

    public static CurrentUserResult ParseCurrentUserResult(string userInfo)
    {
      return userInfo.FromJson<CurrentUserResult>();
    }

    public static TicketEntriesResult ParseTicketEntries(string ticketEntries)
    {
      return ticketEntries.FromJson<TicketEntriesResult>();
    }
  }
}
