using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Bugmine.UI.Controls.Navigation
{
	public class NavigationController : INavigationController
	{
		private IRegionManager _regionManager;
		private IUnityContainer _container;

		public NavigationController(IRegionManager regionManager, IUnityContainer container)
		{
			_regionManager = regionManager;
			_container = container;
		}

		public void NavigateToMainView()
		{
			foreach (var view in _regionManager.Regions[RegionNames.MainRegion].Views)
			{
				_regionManager.Regions[RegionNames.MainRegion].Remove(view);
			}
			_regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.MyPageView, UriKind.Relative));
		}
	}
}
