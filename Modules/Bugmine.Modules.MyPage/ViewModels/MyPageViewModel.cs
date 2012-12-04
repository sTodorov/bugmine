using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Services;
using Bugmine.Modules.MyPage.Models;
using ReactiveUI;

namespace Bugmine.Modules.MyPage.ViewModels
{
	public class MyPageViewModel : ReactiveValidatedObject
	{
		public List<TicketModel> Tickets { get; set; }
		private ObservableAsPropertyHelper<List<TicketModel>> _Tickets { get; set; }

		private ITicketService _ticketService;

		public MyPageViewModel() : this(null) { }

		public MyPageViewModel(ITicketService ticketService)
		{
			Tickets = new List<TicketModel>() { 
				new TicketModel{
					Name = "Test ticket 1",
					Status = "Assigned",
					TicketNumber = 1234,
					DueDate = DateTime.Now,
					EstimatedTime = new DateTime().AddHours(6),
					SpentTime = new DateTime().AddHours(4),
					SpentTimeUnCommited = new DateTime().AddHours(1)
				},
				new TicketModel{
					Name = "Test ticket 2",
					Status = "Assigned",
					TicketNumber = 1235,
					DueDate = DateTime.Now,
					EstimatedTime = new DateTime().AddHours(6),
					SpentTime = new DateTime().AddHours(4),
					SpentTimeUnCommited = new DateTime().AddHours(1)
				}
			};
		}
	}
}
