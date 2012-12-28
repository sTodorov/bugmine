﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

			LoadTickets = new ReactiveAsyncCommand(null, 0, RxApp.DeferredScheduler);

			LoadTickets.RegisterAsyncFunction(x => loadTickets())
				.ToProperty(this, x => x.Tickets);

			Observable.Interval(TimeSpan.FromSeconds(10), RxApp.DeferredScheduler)
					.Subscribe(_ =>
									Debug.WriteLine("Can execute in timer " + LoadTickets.CanExecute(null))
									);

			///.InvokeCommand(LoadTickets);

			Debug.WriteLine("Can execute : " + LoadTickets.CanExecute(this));
			LoadTickets.Execute(null);
			Debug.WriteLine("Can execute after execution: " + LoadTickets.CanExecute(this));

		}

		public ReactiveAsyncCommand LoadTickets { get; private set; }

		private List<TicketModel> loadTickets()
		{
			Debug.WriteLine("loadTickets");
			var tickets = _ticketService.GetTickets();

			var mapped = _mapper.Map(tickets.Values);

			return mapped;
		}
	}
}
