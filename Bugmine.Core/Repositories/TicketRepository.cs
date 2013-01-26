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
using Bugmine.Core.Redmine.Mappers;
using Bugmine.Core.Redmine.Parsers;
using Bugmine.Core.Repositories.Contracts;
using ServiceStack.Text;

namespace Bugmine.Core.Repositories
{
  public class TicketRepository : BaseRepository, ITicketRepository
  {
    private ITicketResultMapper _ticketMapper;
    private ITicketEntryResultMapper _ticketResultMapper;

    public TicketRepository(ITicketResultMapper ticketMapper, ITicketEntryResultMapper ticketResultMapper)
    {
      _ticketMapper = ticketMapper;
      _ticketResultMapper = ticketResultMapper;
    }

    public Page<Models.Ticket> GetTickets(int userID, string apiKey)
    {
      var request = ConstructRedmineRequest(RedmineUrlManager.GetTicketsUrl(new { assigned_to_id = userID, limit = 15000 }), apiKey);

      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
          string json = reader.ReadToEnd();

          var tickets = Parser.ParseTicketsResult(json);

          return _ticketMapper.MapFromTicketResult(tickets);
        }
      }
    }


    public List<TicketEntry> GetTicketEntries(int ticketNumber, string apiKey)
    {
      var request = ConstructRedmineRequest(RedmineUrlManager.GetEntryUrl(new { limit = 15000, issue_id = ticketNumber }), apiKey);

      using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
      {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
          string json = reader.ReadToEnd();

          var tickets = Parser.ParseTicketEntries(json);

          return _ticketResultMapper.MapFromTicketEntryResult(tickets);
        }
      }
    }
  }
}
