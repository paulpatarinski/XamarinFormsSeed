using System.Diagnostics;
using Core.Pages;
using Core.Services;
using Core.ViewModels;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Forms.Mvvm;
using XLabs.Ioc;
using XLabs.Platform.Mvvm;

namespace Core
{
  public class App : Application
  {
    public App()
    {
      Init();
      MainPage = GetMainPage();
    }

    public static Page GetMainPage()
    {
      ViewFactory.Register<MainPage, MainPageViewModel>();

      RegisterServices();

      var landingPage = (Page)ViewFactory.CreatePage<MainPageViewModel, MainPage>();

      var mainNavigationPage = new NavigationPage(landingPage);

      return mainNavigationPage;
    }

    private static void RegisterServices()
    {
      var depedencyContainer = Resolver.Resolve<IDependencyContainer>();

      depedencyContainer.Register<ISampleService, SampleService>();
    }

    /// <summary>
    /// Initializes the application.
    /// </summary>
    public static void Init()
    {
      var app = Resolver.Resolve<IXFormsApp>();
      if (app == null)
      {
        return;
      }

      app.Closing += (o, e) => Debug.WriteLine("Application Closing");
      app.Error += (o, e) => Debug.WriteLine("Application Error");
      app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
      app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
      app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
      app.Startup += (o, e) => Debug.WriteLine("Application Startup");
      app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
    }
  }
}