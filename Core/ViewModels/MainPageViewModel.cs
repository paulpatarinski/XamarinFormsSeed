using System.Threading.Tasks;
using System.Windows.Input;
using Core.Services;
using Xamarin.Forms;
using XLabs.Ioc;

namespace Core.ViewModels
{
  public class MainPageViewModel : BaseViewModel
  {
    public MainPageViewModel()
    {
      _sampleService = Resolver.Resolve<ISampleService>();
    }

    readonly ISampleService _sampleService;

    string _message;

    public string Message
    {
      get { return _message; }
      set { SetField(ref _message, value); }
    }

    ICommand _refreshCommand;

    public ICommand LoadMessageCommand
    {
      get
      {
        return _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteLoadMessageAsync()));
      }
    }

    public async Task ExecuteLoadMessageAsync()
    {
      IsBusy = true;

      var result = await _sampleService.LoadMessageAsync();

      Message = result.Message;

      IsBusy = false;
    }
  }
}