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

		public DateTime DueDate { get; set; }

		public TimeSpan EstimatedTime { get; set; }

		public TimeSpan SpentTime { get; set; }

		public TimeSpan SpentTimeUnCommited { get; set; }
	}
}
