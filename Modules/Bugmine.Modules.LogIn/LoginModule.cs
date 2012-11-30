using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Modules.LogIn.ViewModels;
using Bugmine.Modules.LogIn.Views;
using Bugmine.UI.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Bugmine.Modules.LogIn
{
	public class LoginModule : IModule
	{
		private IRegionManager _regionManager;

		public LoginModule(IRegionManager regionManager, IUnityContainer container)
		{
			container.RegisterType<LoginViewModel>();
			_regionManager = regionManager;
		}

		public void Initialize()
		{
			_regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(LoginView));
		}
	}
}
