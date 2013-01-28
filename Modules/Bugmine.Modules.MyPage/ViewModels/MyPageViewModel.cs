using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
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
		public List<SortByModel> SortBy
		{
			get { return _SortBy; }

			set { this.RaiseAndSetIfChanged(c => c.SortBy, value); }
		}
		private List<SortByModel> _SortBy;

		private string _redmineBaseUrl;

		public List<TicketModel> Tickets
		{
			get { return _Tickets.Value; }
			set
			{
				{
					Debug.WriteLine("Setter of Tickets called");
					this.RaiseAndSetIfChanged(c => c.Tickets, value);
				}
			}
		}
		private ObservableAsPropertyHelper<List<TicketModel>> _Tickets;

		private ITicketService _ticketService;
		private ITicketMapper _mapper;

		public MyPageViewModel() : this(null, null) { }


		public MyPageViewModel(ITicketService ticketService, ITicketMapper mapper)
		{
			_ticketService = ticketService;
			_mapper = mapper;

			LoadTickets = new ReactiveAsyncCommand(null, 1, RxApp.DeferredScheduler);

			LoadTickets.RegisterAsyncFunction(x => loadTickets())
				.ToProperty(this, x => x.Tickets);

			Observable.Interval(TimeSpan.FromSeconds(10), RxApp.DeferredScheduler)
					.InvokeCommand(LoadTickets);
			LoadTickets.Execute(null);

			_redmineBaseUrl = ConfigurationManager.AppSettings["Redmine.BaseRedmineUrl"];

			SortBy = new List<SortByModel>()
			{
				new SortByModel("Project", c => c.Project),
				new SortByModel("Due date", c=> c.DueDate),
				new SortByModel("Priority", c => c.Priority),		
			};

			SortByCommand = new ReactiveCommand(this.WhenAny(c => c.Tickets,
																											((tickets) => tickets.Value != null && tickets.Value.Count > 0)));

			SortByCommand.Subscribe(c => sortTickets((SortByModel)c));

		}

		public ReactiveAsyncCommand LoadTickets { get; private set; }

		public ReactiveCommand SortByCommand { get; private set; }

		private List<TicketModel> loadTickets()
		{
			var tickets = _ticketService.GetTickets();

			var mapped = _mapper.Map(tickets.Values);

			//todo: better way of doing this
			foreach (var entry in mapped)
			{
				entry.TicketUrl = new Uri(_redmineBaseUrl + "issues/" + entry.TicketNumber);
			}

			return mapped;
		}

		private List<TicketModel> sortTickets(SortByModel model)
		{
			Tickets = Tickets.OrderBy(model.Selector).ToList();
			
			return Tickets;
		}
	}
}
