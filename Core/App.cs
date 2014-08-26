using System.Reflection;
using Acr.XamForms.UserDialogs;
using Autofac;
using Core.Helpers.Autofac;
using Core.Helpers.Extensions;
using Core.ViewModels;
using Xamarin.Forms;

namespace Core
{
  public static class App
  {
    public static IContainer Container { get; private set; }

    private static INavigation _navigator;

    public static void Init()
    {
      if (Container != null)
        return;

      //This call registers all ViewModels, Views, Services and any XamDependecies
      Container = new ContainerBuilder()
        .RegisterMvvmComponents(typeof (App).GetTypeInfo().Assembly)
        .RegisterServices(typeof(App).GetTypeInfo().Assembly)
        .RegisterXamDependency<IUserDialogService>()
        .Build();
    }

    public static Page GetMainPage()
    {
      Init();

      var page = new NavigationPage();

      _navigator = page.Navigation;

      NavigateTo<MainPageViewModel>();

      return page;
    }

    public static void NavigateTo<T>(object args = null) where T : IViewModel
    {
      var page = Container
        .Resolve<IPageLocator>()
        .ResolvePageAndViewModel(typeof (T), args);

      _navigator.PushAsync(page);
    }
  }
}