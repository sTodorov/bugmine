using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Models
{
	public class TicketEntry
	{
		public Ticket Ticket { get; set; }

		public string User { get; set; }

		public decimal Hours { get; set; }

		public DateTime Date { get; set; }

		public string Comment { get; set; }

		public string Activity { get; set; }
	}
}
