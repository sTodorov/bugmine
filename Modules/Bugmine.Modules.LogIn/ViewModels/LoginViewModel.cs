﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Bugmine.Core.Services;
using Bugmine.Modules.ModuleBase;
using Bugmine.UI.Controls;
using Bugmine.UI.Controls.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace Bugmine.Modules.LogIn.ViewModels
{
	public class LoginViewModel : ReactiveValidatedObject
	{
		private string _LoginKey;
		public string LoginKey
		{
			get { return _LoginKey; }
			set { this.RaiseAndSetIfChanged(c => c.LoginKey, value); }
		}

		private int? _UserID;
		public int? UserID
		{
			get { return _UserID; }
			set { this.RaiseAndSetIfChanged(c => c.UserID, value); }
		}


		private ReactiveCommand _loginCommand;
		public ICommand LoginCommand { get { return _loginCommand; } }

		private IRegionManager _regionManager;
		private IUserService _userService;
		private INavigationController _navigation;

		public LoginViewModel() : this(null, null, null) { }

		public LoginViewModel(IRegionManager regionManager, IUserService userService, INavigationController navigationController)
		{
			_regionManager = regionManager;
			_userService = userService;
			_navigation = navigationController;
			_loginCommand = new ReactiveCommand(this.WhenAny(c => c.LoginKey, c => c.UserID,
																													 (key, id) => !string.IsNullOrEmpty(key.Value) && id.Value.HasValue));


			_loginCommand.Subscribe(_ => Login());

		}

		public void Login()
		{
			try
			{
				var isValid = _userService.CheckAndLoginIfValid(LoginKey, UserID.Value);
				_navigation.NavigateToMainView();
			}
			catch (Exception e)
			{
				//display some kind of error
			}
		}

	}

}

