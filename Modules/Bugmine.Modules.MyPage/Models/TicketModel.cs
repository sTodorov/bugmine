using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Modules.MyPage.Models
{
	public class TicketModel
	{
		public string Name { get; set; }

		public string Status { get; set; }

		public int TicketNumber { get; set; }

		public DateTime? DueDate { get; set; }

		public decimal? EstimatedTime { get; set; }

		public decimal? SpentTime { get; set; }

		public TimeSpan SpentTimeUnCommited { get; set; }

		public string Project { get; set; }

		public Uri TicketUrl { get; set; }
	}
}
