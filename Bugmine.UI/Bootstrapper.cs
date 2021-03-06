﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Bugmine.Core.Configuration;
using Bugmine.Core.Redmine.Mappers;
using Bugmine.Core.Redmine.Parsers;
using Bugmine.Core.Repositories;
using Bugmine.Core.Repositories.Contracts;
using Bugmine.Core.Services;
using Bugmine.Modules.LogIn;
using Bugmine.Modules.LogIn.ViewModels;
using Bugmine.Modules.LogIn.Views;
using Bugmine.Modules.MyPage;
using Bugmine.Modules.MyPage.Mappers;
using Bugmine.Modules.MyPage.ViewModels;
using Bugmine.Modules.MyPage.Views;
using Bugmine.UI.Controls;
using Bugmine.UI.Controls.Navigation;
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
      Container.RegisterType<INavigationController, NavigationController>();
      Container.RegisterType<ITicketService, TicketService>();
      Container.RegisterType<ITicketRepository, TicketRepository>();
      Container.RegisterType<ITicketResultMapper, TicketResultMapper>();
      Container.RegisterType<ITicketEntryResultMapper, TicketEntryResultMapper>();
      Container.RegisterType<ITicketMapper, TicketMapper>();


      Container.RegisterType<object, LoginViewModel>();
      Container.RegisterType<object, MyPageViewModel>();

      Container.RegisterType<object, LoginView>(ViewNames.LoginView);
      Container.RegisterType<object, MyPageView>(ViewNames.MyPageView);

    }

    protected override void ConfigureModuleCatalog()
    {
      base.ConfigureModuleCatalog();

      ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
      catalog.AddModule(typeof(LoginModule));
      catalog.AddModule(typeof(MyPageModule));
    }

    private void InitializeAppDataFile()
    {
      ApplicationData.Initialize();
    }

    public override void Run(bool runWithDefaultConfiguration)
    {
      base.Run(runWithDefaultConfiguration);

      //determine which view to navigate to
      var hasLoggedInBefore = !string.IsNullOrEmpty(ApplicationData.GetApiKey());

      var navController = Container.Resolve<INavigationController>();

      if (hasLoggedInBefore)
        navController.NavigateToMainView();
      else
        navController.NavigateToLoginView();
    }
  }
}
