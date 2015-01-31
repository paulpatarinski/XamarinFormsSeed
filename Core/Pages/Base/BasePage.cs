using Core.ViewModels;
using Xamarin.Forms;

namespace Core.Pages
{
  public class BasePage : ContentPage
  {
    public BasePage()
    {
      this.SetBinding<BaseViewModel>(IsBusyProperty, vm => vm.IsBusy);
    }
  }
}
