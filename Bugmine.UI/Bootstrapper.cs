using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bugmine.Modules.LogIn;
using Bugmine.Modules.MyPage;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace Bugmine.UI
{
	public class Bootstrapper : UnityBootstrapper
	{
		protected override System.Windows.DependencyObject CreateShell()
		{
			return new Shell();
		}

		protected override void InitializeShell()
		{
			base.InitializeShell();

			App.Current.MainWindow = (Window)this.Shell;
			App.Current.MainWindow.Show();
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();			
		}

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();

			ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule(typeof(LoginModule));
		}
	}
}
