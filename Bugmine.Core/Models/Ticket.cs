using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Models
{
	public class Ticket
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Project { get; set; }

		public string Status { get; set; }

		public decimal EstimatedHours { get; set; }

		public decimal LoggedHours { get; set; }

		public string Priority { get; set; }
	}
}
