using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();
		}
	}
}
