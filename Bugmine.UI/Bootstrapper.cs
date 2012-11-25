using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Bugmine.Core.Repositories;
using Bugmine.Core.Repositories.Contracts;
using Bugmine.Core.Services;
using Bugmine.Modules.LogIn;
using Bugmine.Modules.MyPage;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Bugmine.UI
{
	public class Bootstrapper : UnityBootstrapper
	{
		private const string _settingsFileName = "settings.xml";
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
		}

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();

			ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule(typeof(LoginModule));
		}

		//TODO: Abstract this and make the settings strongly typed
		private void InitializeAppDataFile()
		{
			var settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bugmine");
			if (!Directory.Exists(settingsDirectory))
				Directory.CreateDirectory(settingsDirectory);

			var settingFile = Path.Combine(settingsDirectory, _settingsFileName);
			if (!File.Exists(settingFile))
			{
				XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
																				new XElement("Settings", new XElement("ApiKey", string.Empty)));

				doc.Save(settingFile);
			}
		}
	}
}
