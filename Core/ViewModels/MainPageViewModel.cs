using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.XamForms.UserDialogs;
using Core.Services;
using Xamarin.Forms;

namespace Core.ViewModels
{
  public class MainPageViewModel : ViewModel
  {
    public MainPageViewModel(IUserDialogService dialogService, ISampleService sampleService)
    {
      _dialogService = dialogService;
      _sampleService = sampleService;

      LoadDefaultMessageAsync();
    }

    readonly IUserDialogService _dialogService;
    readonly ISampleService _sampleService;

    string _message;

    public string Message { get { return _message; } set { SetProperty(ref _message, value); } }

    ICommand _refreshCommand;

    public ICommand RefreshCommand
    {
      get
      {
        return _refreshCommand ?? (_refreshCommand = new Command(async () => await RefreshAsync()));
      }
    }

    public async Task RefreshAsync()
    {
      var cancelSrc = new CancellationTokenSource();

      using (var dlg = _dialogService.Loading("Loading"))
      {
        dlg.SetCancel(cancelSrc.Cancel);

        try
        {
          await Task.Delay(TimeSpan.FromSeconds(5), cancelSrc.Token);
        }
        catch
        {
        }
      }

      Message = (cancelSrc.IsCancellationRequested ? "Loading Cancelled" : "Loading Complete");
    }

    public async Task LoadDefaultMessageAsync()
    {
      Message = await _sampleService.GetMessageAsync();
    }
  }
}