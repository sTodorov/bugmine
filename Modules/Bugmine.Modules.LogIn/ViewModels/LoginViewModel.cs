using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Bugmine.Modules.ModuleBase;
using Microsoft.Practices.Prism.Commands;

namespace Bugmine.Modules.LogIn.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public ICommand LoginCommand { get { return _loginCommand; } }
		private ICommand _loginCommand;

		private string _loginKey;
		public string LoginKey
		{
			get { return _loginKey; }
			set
			{
				if (value != _loginKey)
				{
					_loginKey = value;

					OnPropertyChanged("LoginKey");
				}
			}
		}

		public LoginViewModel()
		{
			_loginCommand = new RelayCommand(c => this.LoginUser(), c => this.CanLoginUser);
		}

		private bool CanLoginUser
		{
			get
			{
				return !string.IsNullOrEmpty(_loginKey);
			}
		}

		private void LoginUser()
		{
			//todo : Login via service
		}


	}
}
