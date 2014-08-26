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

      LoadMessageAsync();
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
      await LoadMessageAsync();
    }

    public async Task LoadMessageAsync()
    {
      _dialogService.ShowLoading("Getting data from Server...");

      var model =  await _sampleService.GetMessageAsync();

      _dialogService.HideLoading();

      Message = model.Message;
    }
  }
}