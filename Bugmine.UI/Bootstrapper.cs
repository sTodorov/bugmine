using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Bugmine.Core.Configuration;
using Bugmine.Core.Repositories;
using Bugmine.Core.Repositories.Contracts;
using Bugmine.Core.Services;
using Bugmine.Modules.LogIn;
using Bugmine.Modules.LogIn.Views;
using Bugmine.Modules.MyPage;
using Bugmine.Modules.MyPage.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Bugmine.UI
{
	public class Bootstrapper : UnityBootstrapper
	{

		protected override System.Windows.DependencyObject CreateShell()
		{
			return new Shell();
		}

		public Bootstrapper()
			: base()
		{
			InitializeAppDataFile();
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

			Container.RegisterType<IUserService, UserService>();
			Container.RegisterType<IUserRepository, UserRepository>();
			Container.RegisterType<object, LoginView>("LoginView");
			Container.RegisterType<object, MyPageView>("MyPageView");
		}

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();

			ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule(typeof(LoginModule));
		}

		private void InitializeAppDataFile()
		{
			ApplicationData.Initialize();
		}
	}
}
