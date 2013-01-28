using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Modules.MyPage.Models
{
	public class SortByModel
	{
		private string _name;
		public string Name { get { return _name; } }

		private Func<TicketModel, object> _selector;
		public Func<TicketModel, object> Selector { get { return _selector; } }

		public SortByModel(string name, Func<TicketModel, object> selector)
		{
			_selector = selector;
			_name = name;
		}
	}
}
