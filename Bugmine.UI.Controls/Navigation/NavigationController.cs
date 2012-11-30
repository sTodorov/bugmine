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

		public void GoTo(string regionName, object view)
		{
			var region = _regionManager.Regions[regionName];
			
			foreach (var viewName in region.Views)
			{
				region.Remove(viewName);
			}

			region.Add(view);
			region.Activate(view);
		}
	}
}
