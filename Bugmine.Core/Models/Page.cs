using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Models
{
	public class Page<T>
		where T : class
	{
		public int Start { get; private set; }

		public int Limit { get; private set; }

		public int Total { get; private set; }

		public List<T> Values { get; private set; }

		public int Count { get { return Values.Count; } }

		public Page(int start, int count, int limit, IEnumerable<T> values)
		{
			Start = start;
			Limit = count;
			Total = limit;
			Values = values.ToList();
		}
	}
}
