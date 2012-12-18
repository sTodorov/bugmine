using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Services;
using Bugmine.Modules.MyPage.Mappers;
using Bugmine.Modules.MyPage.Models;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace Bugmine.Modules.MyPage.ViewModels
{
	public class MyPageViewModel : ReactiveValidatedObject
	{
		public List<TicketModel> Tickets
		{
			get { return _Tickets.Value; }
			set { this.RaiseAndSetIfChanged(c => c.Tickets, value); }
		}

		private ObservableAsPropertyHelper<List<TicketModel>> _Tickets;

		private ITicketService _ticketService;
		private ITicketMapper _mapper;

		public MyPageViewModel() : this(null, null) { }


		public MyPageViewModel(ITicketService ticketService, ITicketMapper mapper)
		{
			_ticketService = ticketService;
			_mapper = mapper;

			LoadTickets = new ReactiveAsyncCommand(null, 0);

			LoadTickets.RegisterAsyncFunction(x => loadTickets())
				.ToProperty(this, x => x.Tickets);

			//TODO: make this work. call command each 5 seconds
			//Observable.Timer(TimeSpan.FromSeconds(5), RxApp.DeferredScheduler).Subscribe(c => LoadTickets.Execute(null));
			//.InvokeCommand(LoadTickets);

			LoadTickets.Execute(null);
		}

		public ReactiveAsyncCommand LoadTickets { get; private set; }

		private List<TicketModel> loadTickets()
		{
			var tickets = _ticketService.GetTickets();

			var mapped = _mapper.Map(tickets.Values);

			return mapped;
		}
	}
}
