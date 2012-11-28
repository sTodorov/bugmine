using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bugmine.Core.Services;
using Bugmine.Modules.ModuleBase;
using Bugmine.UI.Controls;
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

		public ICommand LoginCommand { get { return _loginCommand; } }
		private ReactiveAsyncCommand _loginCommand;

		public LoginViewModel()
		{
			_loginCommand = new ReactiveAsyncCommand(this.WhenAny(c => c.LoginKey,
																													 c =>!string.IsNullOrEmpty(c.Value)
																												&& c.Value.Length == 5));
			_loginCommand.RegisterAsyncAction(c => Login());

		}

		private bool Login() {
			return true;
		}

	}

}
#region Implementation with INotifyChanged

//public class LoginViewModel : BaseViewModel
//{
//	public ICommand LoginCommand { get { return _loginCommand; } }
//	private ICommand _loginCommand;

//	private string _loginKey;
//	public string LoginKey
//	{
//		get { return _loginKey; }
//		set
//		{
//			if (value != _loginKey)
//			{
//				_loginKey = value;

//				OnPropertyChanged("LoginKey");
//			}
//		}
//	}

//	public LoginViewModel()
//	{
//		if (_loginCommand == null)
//			_loginCommand = new RelayCommand(c => this.LoginUser(), c => this.CanLoginUser);

//		_regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
//	}

//	private IRegionManager _regionManager;

//	private bool CanLoginUser
//	{
//		get
//		{
//			return !string.IsNullOrEmpty(_loginKey);
//		}
//	}

//	private void LoginUser()
//	{
//		var service = ServiceLocator.Current.GetInstance<IUserService>();

//		var region = _regionManager.Regions["MainRegion"];
//		var loader = new Loader();

//		region.Add(loader);

//		try
//		{
//			var isValid = service.IsApiKeyValid(LoginKey);
//			if (isValid)
//			{
//				_regionManager.RequestNavigate("MainRegion", new Uri("MyPageView", UriKind.Relative));
//			}
//		}
//		catch (Exception e)
//		{
//			LoginKey = "Error: " + e.Message;
//		}
//		region.Remove(loader);
//	}

//}
#endregion

