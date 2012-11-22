using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Modules.MyPage.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Bugmine.Modules.MyPage
{
	public class MyPageModule : IModule
	{
		private IRegionManager _regionManager;

		public MyPageModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}

		public void Initialize()
		{
			_regionManager.RegisterViewWithRegion("MainRegion", typeof(MyPageView));
		}
	}
}
