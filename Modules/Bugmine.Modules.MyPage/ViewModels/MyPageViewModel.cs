﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Services;
using Bugmine.Modules.MyPage.Models;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace Bugmine.Modules.MyPage.ViewModels
{
	public class MyPageViewModel : ReactiveValidatedObject
	{
		/// <summary>
		/// Collection of tickets
		/// </summary>
		public ReactiveCollection<TicketModel> Tickets { get; protected set; }



		/// <summary>
		/// The service which retrieves the tickets
		/// </summary>
		private ITicketService _ticketService;

		public MyPageViewModel() : this(null) { }


		public MyPageViewModel(ITicketService ticketService)
		{
			_ticketService = ticketService;

			LoadTickets = new ReactiveAsyncCommand(null, 0);

			LoadTickets.RegisterAsyncFunction(x => loadTickets().ToObservable().CreateCollection())
				.ToProperty<MyPageViewModel, ReactiveCollection<TicketModel>>(this, x => x.Tickets);

			Observable.Timer(TimeSpan.FromMinutes(5), RxApp.DeferredScheduler)
		.InvokeCommand(LoadTickets);

			//LoadTickets.Execute(null);
		}

		/// <summary>
		/// A command which exposes the load action for the tickets
		/// </summary>
		public ReactiveAsyncCommand LoadTickets { get; private set; }

		private List<TicketModel> loadTickets()
		{
			var ticketModel = new List<TicketModel>() { 
				new TicketModel(){
						Name = "asd",
						TicketNumber= 123
				}
			};

			return ticketModel;
		}
	}
}
