using Android.App;
using Android.Content.PM;
using Android.OS;
using Core;
using Xamarin.Forms;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Mvvm;

namespace ThatConfXamarin.Android
{
	[Activity (MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
    /// <summary>
    /// Called when [create].
    /// </summary>
    /// <param name="bundle">The bundle.</param>
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      if (!Resolver.IsSet)
      {
        this.SetIoc();
      }
      else
      {
        var app = Resolver.Resolve<IXFormsApp>() as IXFormsApp<XFormsApplicationDroid>;
        app.AppContext = this;
      }

      Forms.Init(this, bundle);

      App.Init();

      LoadApplication(new App());
    }

    /// <summary>
    /// Sets the IoC.
    /// </summary>
    private void SetIoc()
    {
      var resolverContainer = new SimpleContainer();

      var app = new XFormsAppDroid();

      app.Init(this);

      resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
        .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
        .Register<IDependencyContainer>(resolverContainer)
        .Register<IXFormsApp>(app);

      Resolver.SetResolver(resolverContainer.GetResolver());
    }
	}
}

