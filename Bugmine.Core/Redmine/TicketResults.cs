using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Redmine
{
	public class TicketsResult
	{
		public int total_count { get; set; }
		public int limit { get; set; }
		public int offset { get; set; }

		public List<TicketResult> issues { get; set; }
	}

	public class TicketResult
	{
		public DateTime? updated_at { get; set; }
		public AuthorResult author { get; set; }
		public StatusResult status { get; set; }
		public TrackerResult tracker { get; set; }
		public AssignedToResult assigned_to { get; set; }
		public ProjectResult project { get; set; }
		public decimal estimated_hours { get; set; }
		public int done_ration { get; set; }
		public DateTime created_on { get; set; }
		public DateTime? start_date { get; set; }
		public string subject { get; set; }
		public string description { get; set; }
		public int id { get; set; }
		public PriorityResult priority { get; set; }
	}

	public class AuthorResult
	{
		public string name { get; set; }
		public int id { get; set; }
	}

	public class StatusResult
	{
		public string name { get; set; }
		public int id { get; set; }
	}
	public class TrackerResult
	{
		public string name { get; set; }
		public int id { get; set; }
	}

	public class AssignedToResult
	{
		public string name { get; set; }
		public int id { get; set; }
	}

	public class ProjectResult
	{
		public string name { get; set; }
		public int id { get; set; }
	}

	public class PriorityResult
	{
		public string name { get; set; }
		public int id { get; set; }
	}
}
