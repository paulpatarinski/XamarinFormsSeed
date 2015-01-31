using Core.ViewModels.Base;
using Xamarin.Forms;

namespace Core.Pages.Base
{
  public class BasePage : ContentPage
  {
    public BasePage()
    {
      this.SetBinding<BaseViewModel>(IsBusyProperty, vm => vm.IsBusy);
    }
  }
}
