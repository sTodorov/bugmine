using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Modules.LogIn.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Bugmine.Modules.LogIn
{
	public class LoginModule : IModule
	{
		private IRegionManager _regionManager;

		public LoginModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void Initialize()
		{
			_regionManager.RegisterViewWithRegion("MainRegion", typeof(LoginView));
		}
	}
}
